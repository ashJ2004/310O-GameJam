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
                    Debug.Log("E key has been pressed, interacting with object");
                    if (rideable != null)
                    {
                        objectRiding = _colliders[0].gameObject;
                        Debug.Log("Entering Object");
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
        this.gameObject.SetActive(false);
        GameObject.Find("PlayerFollowCamera").GetComponent<CinemachineVirtualCamera>().Follow = follow.GetComponentInParent<Transform>();
    }
}
