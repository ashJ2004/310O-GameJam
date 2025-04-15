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

    private IInteractable interactable;

    private void Update()
    {

        numFound = Physics.OverlapSphereNonAlloc(_interactionPoint.position, _interactionPointRadius, _colliders, _interactableMask);
        if (numFound > 0)
        {
            interactable = _colliders[0].GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (!_interactionPromptUI.isDisplayed) _interactionPromptUI.SetUp(interactable.InteractionPrompt);
                if (Keyboard.current.eKey.wasPressedThisFrame)
                {
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
}
