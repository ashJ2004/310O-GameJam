using UnityEngine;

public class FlowerPot : MonoBehaviour, IInteractable
{
    [SerializeField] private string _prompt;

    public string InteractionPrompt => _prompt;
    public bool Interact(Interactor interactor)
    {
        Debug.Log("Entering Flower Pot!");
        return true;
    }
}
