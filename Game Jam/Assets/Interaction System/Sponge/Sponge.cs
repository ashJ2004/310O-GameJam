using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Sponge : MonoBehaviour, IInteractable, IRideable
{
    [SerializeField] private string _prompt;
    [SerializeField] public GameObject player;
    public string InteractionPrompt => _prompt;
    public GameObject water;
    private bool isInWater = false;
    private bool isInSink = false;
    private bool isFull = false;
    public bool Interact(Interactor interactor)
    {
        setPlayerPosition(interactor);
        this.gameObject.GetComponentInParent<PlayerInput>().enabled = true;
        return true;
    }
    public void setPlayerPosition(Interactor interactor)
    {
        interactor.GetComponent<PlayerInput>().enabled = false;
        interactor.GetComponent<Interactor>().RideObject(this.gameObject);
    }
    public void Update()
    {
        if (Keyboard.current.zKey.wasPressedThisFrame && this.transform.parent.GetComponent<PlayerInput>().isActiveAndEnabled)
        {

            player.SetActive(true);
            player.transform.position = this.transform.parent.Find("SpongeExitLocation").position;
            Vector3 forwardOffset = this.transform.parent.Find("SpongeExitLocation").forward * 0.6f;
            player.transform.position += forwardOffset;
            this.GetComponentInParent<PlayerInput>().enabled = false;
            player.GetComponent<PlayerInput>().enabled = true;
            GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>().Follow = player.transform.Find("PlayerCameraRoot");
        }
        if(Input.GetKey(KeyCode.F) && this.transform.parent.GetComponent<PlayerInput>().isActiveAndEnabled && isInWater && !isFull)
        {
            isFull = true;
            Debug.Log("FIlling Sponge");
            water.GetComponent<Hazard>().LowerWaterLevel();
        }
        else if (Input.GetKey(KeyCode.F) && this.transform.parent.GetComponent<PlayerInput>().isActiveAndEnabled && isInSink && isFull)
        {
            Debug.Log("FIlling Drain");
            isFull = false;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Water"))
        {
            Debug.Log("SPONGE IN WATER");
            isInWater = true;
        }
        if (other.CompareTag("Drain"))
        {
            isInSink = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        Debug.Log("SPONGE OUT OF WATER");
        if (other.CompareTag("Water"))
        {
            isInWater = false;
        }
        if (other.CompareTag("Drain"))
        {
            isInSink = false;
        }
    }
}
