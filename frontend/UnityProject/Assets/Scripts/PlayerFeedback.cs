using UnityEngine;

public class PlayerFeedback : MonoBehaviour
{
    public UIManager uiManager;    // Referencia a la UI para mostrar mensajes
    public AudioSource audioSource; // Referencia al AudioSource para sonidos
    public AudioClip successSound;  // Sonido de éxito
    public AudioClip failSound;     // Sonido de fallo

    void Start()
    {
        if (uiManager == null || audioSource == null)
        {
            Debug.LogError("Asigna UIManager y AudioSource en el Inspector.");
        }
        if (successSound == null || failSound == null)
        {
            Debug.LogWarning("Asigna sonidos de éxito y fallo en el Inspector.");
        }
    }

    public void ProvideFeedback(string tone)
    {
        if (tone == "excited")
        {
            uiManager.UpdateUI("¡Gran pronunciación! +10 puntos");
            if (successSound != null) audioSource.PlayOneShot(successSound);
        }
        else if (tone == "calm")
        {
            uiManager.UpdateUI("Intenta con más energía.");
            if (failSound != null) audioSource.PlayOneShot(failSound);
        }
        else
        {
            uiManager.UpdateUI("Tono no reconocido, ¡intenta de nuevo!");
        }
    }
}
