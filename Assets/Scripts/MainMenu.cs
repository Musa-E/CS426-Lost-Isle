using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame() {
        // Increment to the next scene
        Debug.Log("Starting Game...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void quitGame() {
        Debug.Log("Quitting...");
        Application.Quit();
    }

    public void getCredits() {
        Debug.Log("Displaying Credits...");
    }
}
