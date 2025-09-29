using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioSource audioSource; // Referencia al componente AudioSource
    public AudioClip successClip;   // Clip de sonido para éxito
    public AudioClip failureClip;   // Clip de sonido para fallo

    void Start()
    {
        if (audioSource == null)
        {
            Debug.LogError("Asigna un AudioSource en el Inspector.");
        }
    }

    public void PlaySuccess()
    {
        if (successClip != null)
        {
            audioSource.PlayOneShot(successClip);
        }
    }

    public void PlayFailure()
    {
        if (failureClip != null)
        {
            audioSource.PlayOneShot(failureClip);
        }
    }
}
