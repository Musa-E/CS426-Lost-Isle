using UnityEngine;

public class FlashingLight : MonoBehaviour
{
    public Light flashingLight;
    public float flashSpeed = 2f; // How fast it flashes

    private void Update()
    {
        if (flashingLight != null)
        {
            flashingLight.intensity = Mathf.Abs(Mathf.Sin(Time.time * flashSpeed)) * 3f; 
            // Multiply by max intensity you want
        }
    }
}
