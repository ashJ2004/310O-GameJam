using Cinemachine;
using StarterAssets;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlowerPot : MonoBehaviour, IInteractable,IRideable
{
    [SerializeField] private string _prompt;
    [SerializeField] public GameObject player;
    public string InteractionPrompt => _prompt;
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
        if (Keyboard.current.zKey.wasPressedThisFrame)
        {
            /*exit object
             * 
             */
            player.SetActive(true);
            player.transform.position = this.transform.parent.Find("ExitLocation").position;
            this.GetComponentInParent<PlayerInput>().enabled = false;
            player.GetComponent<PlayerInput>().enabled = true;
            GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>().Follow = player.transform.Find("PlayerCameraRoot");
        }
    }
}
