using UnityEngine;

public class Key : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;
    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        interactor.HasKey = true;
        this.gameObject.SetActive(false);
        return true;
    }
}
