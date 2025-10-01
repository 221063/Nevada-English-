using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public PlayerStats playerStats; // Referencia a PlayerStats

    void Start()
    {
        if (playerStats == null)
        {
            Debug.LogError("Asigna PlayerStats en el Inspector.");
        }
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Score", playerStats.score);
        PlayerPrefs.SetInt("Level", playerStats.level);
        PlayerPrefs.Save();
        Debug.Log("Datos guardados: Puntuación " + playerStats.score + ", Nivel " + playerStats.level);
    }

    public void LoadData()
    {
        playerStats.score = PlayerPrefs.GetInt("Score", 0);
        playerStats.level = PlayerPrefs.GetInt("Level", 0);
        Debug.Log("Datos cargados: Puntuación " + playerStats.score + ", Nivel " + playerStats.level);
    }

    public void ResetData()
    {
        PlayerPrefs.DeleteAll();
        LoadData();
        Debug.Log("Datos reiniciados.");
    }
}
