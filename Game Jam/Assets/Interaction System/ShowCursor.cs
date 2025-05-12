using UnityEngine;

public class MouseCursorToggle : MonoBehaviour
{
    private bool _cursorLocked = true; // Initial state

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
                Cursor.lockState = CursorLockMode.None; // Unlock cursor
                Cursor.visible = true; // Show cursor
        }
        if (Input.GetMouseButtonDown(0))
        {
            Cursor.lockState = CursorLockMode.Locked; // Lock cursor
            Cursor.visible = false; // Hide cursor
        }
    }
}
