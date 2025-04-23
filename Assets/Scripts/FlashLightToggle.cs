using UnityEngine;

public class FlashLightToggle : MonoBehaviour
{
    [Header("Flashlight Settings")]
    public Light flashlight;
    public KeyCode toggleKey = KeyCode.F;

    private bool isOn = false;

    void Start()
    {
        if (flashlight != null)
        {
            flashlight.enabled = isOn;
        }
        else
        {
            Debug.LogWarning("Flashlight not assigned in the Inspector.");
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(toggleKey) && flashlight != null)
        {
            isOn = !isOn;
            flashlight.enabled = isOn;
        }
    }
}
