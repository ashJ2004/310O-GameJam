using UnityEngine;
using UnityEngine.InputSystem;

public class Hazard : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;
    [SerializeField] private TMPro.TextMeshProUGUI _promptText;
    [SerializeField] private string _prompt;
    public string text => _prompt;

    private PlayerInput playerController;
    private int waterLevel = 3;

    void Start()
    {
        playerController = player.GetComponent<PlayerInput>();
    }
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Colliding With: " + other.gameObject.name);
        if (other.gameObject.CompareTag("Player"))
        {
            if (playerController.isActiveAndEnabled)
            {
                player.SetActive(false);
                player.transform.position = spawnPoint.position;
                player.SetActive(true);
            }
        }
    }
    public void LowerWaterLevel()
    {
        Debug.Log("LOWERING WATER LEVEL: CURRENT LEVEL: " + waterLevel);
        waterLevel--;
        if (waterLevel == 2)
        {
            _promptText.text = _prompt;
            this.gameObject.transform.localScale = new Vector3(this.transform.localScale.x, 0.6f, this.transform.localScale.z);
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 0.2f, this.transform.localPosition.z);
            
        }
        else if(waterLevel == 1)
        {
            this.gameObject.transform.localScale = new Vector3(this.transform.localScale.x, 0.3f, this.transform.localScale.z);
            this.transform.localPosition = new Vector3(this.transform.localPosition.x, this.transform.localPosition.y - 0.2f, this.transform.localPosition.z);
        }
        else
        {
            _promptText.text = "The water is all gone! Now I can grab the key.";
            this.gameObject.SetActive(false);
        }
    }
}
