using UnityEngine;

public class Button : MonoBehaviour
{
    public GameObject water;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            water.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }
}
