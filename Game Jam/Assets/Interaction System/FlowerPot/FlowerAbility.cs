using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class FlowerAbility : MonoBehaviour
{
    public float raiseSpeed = 0.4f;
    public Transform objectToRaise;
    public Transform objectToScale;
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && this.GetComponent<PlayerInput>().isActiveAndEnabled)
        {

            float delta = raiseSpeed * Time.deltaTime;
            GrowPlant(delta);
        }
        if(Input.GetKey(KeyCode.LeftShift) && this.GetComponent<PlayerInput>().isActiveAndEnabled && this.transform.Find("FlowerPotExitLocation").position.y > 3)
        {
            float delta = -raiseSpeed * Time.deltaTime;
            GrowPlant(delta);
        }
    }
    void GrowPlant(float delta)
    {
        // Raise object in Y
        objectToRaise.position += Vector3.up * delta;

        // Scale other object in +Z direction
        Vector3 scale = objectToScale.localScale;
        scale.z += delta/60;
        objectToScale.localScale = scale;

        // Move to stretch in +Z only
        objectToScale.position += objectToScale.forward * (delta / 2f);
    }
}
