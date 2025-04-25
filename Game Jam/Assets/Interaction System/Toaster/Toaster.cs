using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class Toaster : MonoBehaviour, IInteractable, IRideable
{
    [SerializeField] private string _prompt;
    [SerializeField] public GameObject player;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        setPlayerPosition(interactor);
        this.gameObject.GetComponentInParent<PlayerInput>().enabled = true;
        Debug.Log("Entering Toaster!");
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
            player.transform.position = this.transform.parent.Find("ToasterExitLocation").position;
            Debug.Log("Exit Location Parent: " + this.transform.parent.Find("ToasterExitLocation").name);
            Vector3 forwardOffset = this.transform.parent.Find("ToasterExitLocation").forward * 0.6f;
            player.transform.position += forwardOffset;
            this.GetComponentInParent<PlayerInput>().enabled = false;
            player.GetComponent<PlayerInput>().enabled = true;
            GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>().Follow = player.transform.Find("PlayerCameraRoot");
        }
    }
}
