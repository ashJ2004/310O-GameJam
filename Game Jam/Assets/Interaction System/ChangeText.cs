using UnityEngine;

public class ChangeText : MonoBehaviour
{
    [SerializeField] private string _prompt;
    [SerializeField] public GameObject player;
    [SerializeField] private Transform checkpoint;
    public string text => _prompt;

    [SerializeField] private TMPro.TextMeshProUGUI _promptText;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            _promptText.text = text;
            other.GetComponent<Interactor>()._currentCheckpoint = checkpoint;
        }
    }
}
