using UnityEngine;
using UnityEngine.InputSystem;

public class Canon : MonoBehaviour
{
    public GameObject bread;
    public Transform firingLocation;

    public float force;
    public float rotateSpeed = 1.0f;
    public float fireCooldown = 0.5f;

    private float cooldownTimer = 0f;
    // Update is called once per frame
    void Update()
    {
        if (this.GetComponentInParent<PlayerInput>().isActiveAndEnabled)
        {
            float xRotation = this.transform.localEulerAngles.x;
            xRotation = (xRotation > 180f) ? xRotation - 360f : xRotation;
            cooldownTimer -= Time.deltaTime;
            if (Input.GetKey(KeyCode.Space) && cooldownTimer <= 0f)
            {
                GameObject projectile = Instantiate(bread, firingLocation.position, firingLocation.rotation);
                projectile.GetComponent<Rigidbody>().linearVelocity = firingLocation.forward * force * Time.deltaTime;
                cooldownTimer = fireCooldown;
            }
            if (Input.GetKey(KeyCode.UpArrow) && xRotation <= 80)
            {
                this.transform.Rotate(Vector3.right * rotateSpeed * Time.deltaTime);
            }
            if (Input.GetKey(KeyCode.DownArrow) && xRotation >= 0)
            {
                this.transform.Rotate(Vector3.left * rotateSpeed * Time.deltaTime);
            }
        }
        
    }
}
