using UnityEngine;

public class UISettingsPanel : MonoBehaviour
{
    public UIManager uiManager;              // Referencia al UIManager
    public AccessibilityOptions accessibilityOptions; // Referencia al AccessibilityOptions
    public AudioManager audioManager;        // Referencia al AudioManager
    public GameObject settingsPanel;         // Panel de configuraciones en la UI

    void Start()
    {
        if (uiManager == null || accessibilityOptions == null || audioManager == null || settingsPanel == null)
        {
            Debug.LogError("Asigna UIManager, AccessibilityOptions, AudioManager y settingsPanel en el Inspector.");
        }
        settingsPanel.SetActive(false); // Panel oculto al inicio
    }

    public void ToggleSettingsPanel()
    {
        bool isActive = settingsPanel.activeSelf;
        settingsPanel.SetActive(!isActive);
        uiManager.UpdateUI("Panel de configuraciones " + (!isActive ? "abierto" : "cerrado"));
    }

    public void IncreaseTextSize()
    {
        accessibilityOptions.IncreaseTextSize();
    }

    public void ToggleVoiceCommands()
    {
        accessibilityOptions.ToggleVoiceCommands();
    }

    public void AdjustVolume(float volume)
    {
        audioManager.SetMasterVolume(volume);
    }
}
