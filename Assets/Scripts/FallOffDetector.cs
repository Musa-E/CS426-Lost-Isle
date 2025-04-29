using UnityEngine;

public class FallOffDetector : MonoBehaviour
{
    private UiManager2 uiManager;
    private void Start()
    {
        uiManager = FindObjectOfType<UiManager2>();

        if (uiManager == null)
        {
            Debug.LogError("UIManager2 script not found in the scene.");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            uiManager.ShowGameLostPanel();
        }
    }
}
