using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
public class FInishLine : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI _winCanvas;
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //play end game cinematic
            Debug.Log("Timer started");
            other.gameObject.GetComponent<PlayerInput>().enabled = false;
            StartCoroutine(DelayQuit(3f));
            Debug.Log("Timer Ended");
        }
    }
    private IEnumerator DelayQuit(float delay)
    {
        _winCanvas.text = "You Win!";
        yield return new WaitForSeconds(delay);
        QuitGame(); // This can be a regular void function
    }
    public void QuitGame()
    {
        // save any game data here
        #if UNITY_EDITOR
                // Application.Quit() does not work in the editor so
                // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }
}

