using UnityEngine;
using UnityEngine.UI;

public class OxygenBlinkUI : MonoBehaviour
{
    public Image warningImage;
    public OxygenCounter oxygenCounter;
    public float blinkSpeed = 4f;
    public float maxAlpha = 0.4f;
    public int criticalOxygen = 30;

    private float alpha = 0f;
    private bool fadeIn = true;

    void Update()
    {
        if (oxygenCounter.oxygenLevel < criticalOxygen)
        {
            // Blink red effect
            Color c = warningImage.color;

            if (fadeIn)
                alpha += Time.deltaTime * blinkSpeed;
            else
                alpha -= Time.deltaTime * blinkSpeed;

            alpha = Mathf.Clamp(alpha, 0f, maxAlpha);
            c.a = alpha;
            warningImage.color = c;

            if (alpha >= maxAlpha) fadeIn = false;
            if (alpha <= 0f) fadeIn = true;
        }
        else
        {
            // Reset when oxygen is normal
            Color c = warningImage.color;
            c.a = Mathf.Lerp(c.a, 0f, Time.deltaTime * blinkSpeed);
            warningImage.color = c;
        }
    }
}
