using Cinemachine;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _interactionPoint;
    [SerializeField] private float _interactionPointRadius;
    [SerializeField] private LayerMask _interactableMask;
    [SerializeField] private InteractionCameraUI _interactionPromptUI;

    private readonly Collider[] _colliders = new Collider[3];
    [SerializeField] private int numFound;
    private GameObject objectRiding = null;

    private IInteractable interactable;
    private IRideable rideable;

    public bool HasKey = false;

    private void Update()
    {

        numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if (numFound > 0)
        {
            interactable = _colliders[0].GetComponent<IInteractable>();
            rideable = _colliders[0].GetComponent<IRideable>();
            if (interactable != null)
            {
                if (!_interactionPromptUI.isDisplayed) _interactionPromptUI.SetUp(interactable.InteractionPrompt);
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
                    if (rideable != null)
                    {
                        objectRiding = _colliders[0].gameObject;
                    }
                    interactable.Interact(this);
                }
                
            }
        }
        else
        {
            if (interactable != null) interactable = null;
            if (_interactionPromptUI.isDisplayed) _interactionPromptUI.Close();
        }
    }
    public void RideObject(GameObject follow)
    {
        this.gameObject.transform.position = follow.GetComponent<Transform>().position;
        GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>().Follow = follow.transform.parent.Find(follow.transform.parent.name + "ExitLocation/RideableCameraRoot");

        this.gameObject.SetActive(false);
    }
}
