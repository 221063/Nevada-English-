using UnityEngine;

public class LearningAnalytics : MonoBehaviour
{
    public ProgressTracker progressTracker; // Referencia al ProgressTracker
    public VocabularyTrainer vocabularyTrainer; // Referencia al VocabularyTrainer
    public SaveSystem saveSystem;           // Referencia al SaveSystem
    private int wordsFailed;                // Contador de palabras falladas
    private float avgTimePerLesson;         // Tiempo promedio por lección

    void Start()
    {
        if (progressTracker == null || vocabularyTrainer == null || saveSystem == null)
        {
            Debug.LogError("Asigna ProgressTracker, VocabularyTrainer y SaveSystem en el Inspector.");
        }
        LoadAnalytics();
    }

    public void RecordFailure()
    {
        wordsFailed++;
        UpdateAnalytics();
        SaveAnalytics();
    }

    public void UpdateAnalytics()
    {
        float totalTime = progressTracker.playTime;
        int lessonsCompleted = progressTracker.wordsLearned / 5; // Asume 5 palabras por lección
        avgTimePerLesson = lessonsCompleted > 0 ? totalTime / lessonsCompleted : 0f;
        string analyticsText = "Análisis: " + wordsFailed + " fallos, " + avgTimePerLesson.ToString("F2") + " seg/lección";
        Debug.Log(analyticsText); // Temporal; conectar con UI después
    }

    private void SaveAnalytics()
    {
        PlayerPrefs.SetInt("WordsFailed", wordsFailed);
        PlayerPrefs.SetFloat("AvgTimePerLesson", avgTimePerLesson);
        saveSystem.SaveData(); // Guarda otros datos
    }

    private void LoadAnalytics()
    {
        wordsFailed = PlayerPrefs.GetInt("WordsFailed", 0);
        avgTimePerLesson = PlayerPrefs.GetFloat("AvgTimePerLesson", 0f);
        UpdateAnalytics();
    }
}
