using UnityEngine;

public class PlayerCustomization : MonoBehaviour
{
    public UIManager uiManager;          // Referencia al UIManager
    public SaveSystem saveSystem;        // Referencia al SaveSystem
    public GameObject playerAvatar;      // Referencia al avatar del jugador
    private int colorIndex = 0;          // Índice del color actual
    private string[] colors = { "Red", "Blue", "Green", "Yellow" }; // Opciones de color

    void Start()
    {
        if (uiManager == null || saveSystem == null || playerAvatar == null)
        {
            Debug.LogError("Asigna UIManager, SaveSystem y playerAvatar en el Inspector.");
        }
        LoadCustomization();
    }

    public void ChangeColor()
{
    colorIndex = (colorIndex + 1) % colors.Length;
    ApplyColor();
    uiManager.UpdateUI("Color cambiado a: " + colors[colorIndex]);
    SaveCustomization();
}

    private void ApplyColor()
{
    switch (colors[colorIndex])
    {
        case "Red":
            playerAvatar.GetComponent<Renderer>().material.color = Color.red;
            break;
        case "Blue":
            playerAvatar.GetComponent<Renderer>().material.color = Color.blue;
            break;
        case "Green":
            playerAvatar.GetComponent<Renderer>().material.color = Color.green;
            break;
        case "Yellow":
            playerAvatar.GetComponent<Renderer>().material.color = Color.yellow;
            break;
    }
}

    private void SaveCustomization()
{
    PlayerPrefs.SetInt("ColorIndex", colorIndex);
    saveSystem.SaveData(); // Guarda otros datos
}

    private void LoadCustomization()
{
    colorIndex = PlayerPrefs.GetInt("ColorIndex", 0);
    ApplyColor();
    uiManager.UpdateUI("Personalización cargada: " + colors[colorIndex]);
}
