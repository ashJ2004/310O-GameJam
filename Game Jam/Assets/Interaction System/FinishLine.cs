using UnityEngine;
public class FInishLine : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            //play end game cinematic
            Debug.Log("Timer started");
            new WaitForSeconds(30.0f);
            Debug.Log("Timer Ended");
            QuitGame();
        }
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

