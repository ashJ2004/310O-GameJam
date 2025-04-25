using UnityEngine;
using UnityEngine.InputSystem;

public class Hazard : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject player;

    private PlayerInput playerController;
    private int waterLevel = 3;

    void Start()
    {
        playerController = player.GetComponent<PlayerInput>();
    }
    private void OnTriggerEnter(Collider other)
    {
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
        Debug.Log("LOWERING WATER LEVEL");
        waterLevel--;
        if (waterLevel == 2)
        {
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
            this.gameObject.SetActive(false);
        }
    }
}
