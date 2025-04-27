using UnityEngine;
using UnityEngine.SceneManagement;

public class UiManager2 : MonoBehaviour
{
    [SerializeField] private GameObject GameLostPanel;


    private void Start()
    {
        GameLostPanel.SetActive(false);
    }


    public void ShowGameLostPanel()
    {
        ShowMouseOnCanvas();
        GameLostPanel.SetActive(true);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }

    private void ShowMouseOnCanvas()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        Time.timeScale = 0f;
    }

    public void ShowGameWonPanel()
    {
        Debug.Log("Game Won!");
    }
}