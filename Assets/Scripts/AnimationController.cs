using System.Collections;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public Animator animator;
    public OxygenCounter oxygenCounter;
    public AudioSource flapAudio;

    public int triggerThreshold = 98;
    public float flapAudioDuration = 8f;

    private bool hasFlapped = false;

    void Update()
    {
        int o2 = oxygenCounter.oxygenLevel;

        if (!hasFlapped && o2 < triggerThreshold)
        {
            PlayFlapSequence();
            hasFlapped = true;
        }

        if (hasFlapped && o2 >= triggerThreshold)
        {
            hasFlapped = false;
        }
    }

    void PlayFlapSequence()
    {
        animator.SetTrigger("Flap");     
        flapAudio.Play();                
        StartCoroutine(StopSoundAfter(flapAudioDuration)); 
    }

    IEnumerator StopSoundAfter(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        flapAudio.Stop();
    }
}
