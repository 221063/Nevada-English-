using UnityEngine;

public class ProgressTracker : MonoBehaviour
{
    public PlayerStats playerStats;      // Referencia a PlayerStats
    public LessonManager lessonManager;  // Referencia al LessonManager
    public SaveSystem saveSystem;        // Referencia al SaveSystem
    private float playTime;              // Tiempo total jugado
    private int wordsLearned;            // Palabras aprendidas

    void Start()
    {
        if (playerStats == null || lessonManager == null || saveSystem == null)
        {
            Debug.LogError("Asigna PlayerStats, LessonManager y SaveSystem en el Inspector.");
        }
        LoadProgress();
    }

    void Update()
    {
        playTime += Time.deltaTime;
    }

    public void RecordWordLearned()
    {
        wordsLearned++;
        playerStats.AddScore(5); // Recompensa por palabra aprendida
        SaveProgress();
        UpdateUI();
    }

    private void UpdateUI()
    {
        string status = "Progreso: " + wordsLearned + " palabras, " + Mathf.Floor(playTime) + " segundos";
        // Asume que UIManager tiene un método para mostrar progreso
        // uiManager.UpdateUI(status); // Descomentar y asignar UIManager si lo usas
        Debug.Log(status);
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("WordsLearned", wordsLearned);
        PlayerPrefs.SetFloat("PlayTime", playTime);
        saveSystem.SaveData(); // Guarda otros datos
    }

    private void LoadProgress()
    {
        wordsLearned = PlayerPrefs.GetInt("WordsLearned", 0);
        playTime = PlayerPrefs.GetFloat("PlayTime", 0f);
        UpdateUI();
    }
}
