using UnityEngine;
using UnityEngine.UI;

public class OxygenBlinkUI : MonoBehaviour
{
    public Image warningImage;

    public Image sliderFillImage;

    private Color originalFillColor;

    // For playing the low O2 warning sound
    public AudioSource warningAudio;


    public OxygenCounter oxygenCounter;
    public float blinkSpeed = 4f;
    public float maxAlpha = 0.4f;
    public int criticalOxygen = 30;

    private float alpha = 0f;
    private bool fadeIn = true;

    void Start() {
        originalFillColor = sliderFillImage.color;
    }

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

            // Update O2 Bar's Fill color to be RED when critical
            sliderFillImage.color = new Color(1f, 0f, 0f, originalFillColor.a);

            if (!warningAudio.isPlaying) {
                warningAudio.Play();
            }
        }
        else
        {
            // Reset when oxygen is normal
            Color c = warningImage.color;
            c.a = Mathf.Lerp(c.a, 0f, Time.deltaTime * blinkSpeed);
            warningImage.color = c;

            // Reset O2 bar to normal color
            sliderFillImage.color = new Color(
                originalFillColor.r,
                originalFillColor.g,
                originalFillColor.b,
                originalFillColor.a
            );  // #89D4FF

            if (warningAudio.isPlaying) {
                warningAudio.Stop();
            }

        }
    }
}
