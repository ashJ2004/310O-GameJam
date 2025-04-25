using UnityEngine;

public class Button : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ammo"))
        {
            Debug.Log("Button Has been Hit");
        }
    }
}
