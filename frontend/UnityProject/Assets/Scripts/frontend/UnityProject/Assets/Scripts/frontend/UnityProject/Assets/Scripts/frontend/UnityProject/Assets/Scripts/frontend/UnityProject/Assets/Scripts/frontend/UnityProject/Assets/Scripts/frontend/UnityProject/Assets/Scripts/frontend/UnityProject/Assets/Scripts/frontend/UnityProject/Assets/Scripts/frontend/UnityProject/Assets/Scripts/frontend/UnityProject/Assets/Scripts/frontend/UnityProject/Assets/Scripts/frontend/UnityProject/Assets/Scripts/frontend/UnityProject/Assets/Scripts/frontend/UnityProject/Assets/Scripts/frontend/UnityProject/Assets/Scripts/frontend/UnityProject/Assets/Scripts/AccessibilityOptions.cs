using UnityEngine;

public class AccessibilityOptions : MonoBehaviour
{
    public UIManager uiManager;         // Referencia al UIManager
    public SettingsManager settingsManager; // Referencia al SettingsManager
    private float textScale = 1.0f;     // Escala inicial del texto (1 = normal)
    private bool voiceCommands = false; // Estado de comandos de voz

    void Start()
    {
        if (uiManager == null || settingsManager == null)
        {
            Debug.LogError("Asigna UIManager y SettingsManager en el Inspector.");
        }
        ApplyAccessibilityOptions();
    }

    public void IncreaseTextSize()
    {
        textScale += 0.2f;
        if (textScale > 2.0f) textScale = 2.0f; // Límite máximo
        uiManager.UpdateTextScale(textScale);   // Método hipotético en UIManager
        uiManager.UpdateUI("Tamaño de texto ajustado a: " + (textScale * 100) + "%");
    }

    public void ToggleVoiceCommands()
    {
        voiceCommands = !voiceCommands;
        settingsManager.SetLanguage(voiceCommands ? "VoiceEnabled" : "Default"); // Placeholder
        uiManager.UpdateUI("Comandos de voz: " + (voiceCommands ? "Activados" : "Desactivados"));
    }

    private void ApplyAccessibilityOptions()
    {
        uiManager.UpdateTextScale(textScale);
        uiManager.UpdateUI("Opciones de accesibilidad aplicadas: Texto " + (textScale * 100) + "%, Voz " + (voiceCommands ? "Activada" : "Desactivada"));
    }
}
