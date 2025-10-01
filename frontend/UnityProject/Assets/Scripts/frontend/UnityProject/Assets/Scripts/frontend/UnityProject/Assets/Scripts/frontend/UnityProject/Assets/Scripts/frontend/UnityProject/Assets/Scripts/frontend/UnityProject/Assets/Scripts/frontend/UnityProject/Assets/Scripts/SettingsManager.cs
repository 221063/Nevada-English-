using UnityEngine;

public class SettingsManager : MonoBehaviour
{
    public AudioManager audioManager;  // Referencia al AudioManager
    public UIManager uiManager;        // Referencia a UIManager
    private float masterVolume = 0.5f; // Volumen maestro (0 a 1)
    private string language = "English"; // Idioma por defecto

    void Start()
    {
        if (audioManager == null || uiManager == null)
        {
            Debug.LogError("Asigna AudioManager y UIManager en el Inspector.");
        }
        ApplySettings();
    }

    public void SetVolume(float volume)
    {
        masterVolume = Mathf.Clamp01(volume); // Asegura que esté entre 0 y 1
        audioManager.SetMasterVolume(masterVolume);
        uiManager.UpdateUI("Volumen ajustado a: " + (masterVolume * 100) + "%");
    }

    public void SetLanguage(string lang)
    {
        language = lang;
        uiManager.UpdateUI("Idioma cambiado a: " + language);
        // Lógica para cambiar texto/voz según idioma (a implementar)
    }

    private void ApplySettings()
    {
        audioManager.SetMasterVolume(masterVolume);
        uiManager.UpdateUI("Configuración aplicada: Volumen " + (masterVolume * 100) + "%, Idioma " + language);
    }
}
