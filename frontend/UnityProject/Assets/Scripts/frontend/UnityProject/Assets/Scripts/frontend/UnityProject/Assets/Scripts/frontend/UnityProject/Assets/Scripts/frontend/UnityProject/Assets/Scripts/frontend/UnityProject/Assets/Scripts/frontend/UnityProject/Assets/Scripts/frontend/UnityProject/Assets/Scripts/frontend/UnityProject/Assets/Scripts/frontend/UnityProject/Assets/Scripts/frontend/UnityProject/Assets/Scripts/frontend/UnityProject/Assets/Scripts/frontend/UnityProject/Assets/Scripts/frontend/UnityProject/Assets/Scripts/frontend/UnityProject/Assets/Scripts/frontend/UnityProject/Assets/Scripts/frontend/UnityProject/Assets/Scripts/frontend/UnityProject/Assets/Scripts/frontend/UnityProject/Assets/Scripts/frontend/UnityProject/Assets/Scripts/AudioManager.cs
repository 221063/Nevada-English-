using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public UIManager uiManager;           // Referencia al UIManager
    public SettingsManager settingsManager; // Referencia al SettingsManager
    public AudioSource audioSource;       // Referencia al AudioSource
    public AudioClip successSound;        // Sonido de éxito
    public AudioClip failureSound;        // Sonido de fallo

    void Start()
    {
        if (uiManager == null || settingsManager == null || audioSource == null)
        {
            Debug.LogError("Asigna UIManager, SettingsManager y AudioSource en el Inspector.");
        }
        ApplyVolume();
    }

    public void PlaySuccessSound()
    {
        audioSource.clip = successSound;
        audioSource.Play();
        uiManager.UpdateUI("¡Sonido de éxito reproducido!");
    }

    public void PlayFailureSound()
    {
        audioSource.clip = failureSound;
        audioSource.Play();
        uiManager.UpdateUI("Sonido de fallo reproducido.");
    }

    public void SetMasterVolume(float volume)
    {
        audioSource.volume = volume;
        uiManager.UpdateUI("Volumen ajustado a: " + (volume * 100) + "%");
    }

    private void ApplyVolume()
    {
        SetMasterVolume(settingsManager.masterVolume); // Aplica el volumen inicial
    }
}
