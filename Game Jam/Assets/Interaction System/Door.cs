using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        if (interactor.HasKey)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = false;
            this.gameObject.SetActive(false);
            return true;
        }
        return false;
    }
}
