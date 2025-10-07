using UnityEngine;

public class LessonProgressReport : MonoBehaviour
{
    public ProgressTracker progressTracker; // Referencia al ProgressTracker
    public LearningAnalytics learningAnalytics; // Referencia al LearningAnalytics
    public UIManager uiManager;             // Referencia al UIManager

    void Start()
    {
        if (progressTracker == null || learningAnalytics == null || uiManager == null)
        {
            Debug.LogError("Asigna ProgressTracker, LearningAnalytics y UIManager en el Inspector.");
        }
        GenerateReport();
    }

    public void GenerateReport()
    {
        int wordsLearned = progressTracker.wordsLearned;
        int wordsFailed = learningAnalytics.wordsFailed;
        float avgTimePerLesson = learningAnalytics.avgTimePerLesson;
        string report = "Reporte de Progreso:\n" +
                        "- Palabras aprendidas: " + wordsLearned + "\n" +
                        "- Palabras falladas: " + wordsFailed + "\n" +
                        "- Tiempo promedio por lección: " + avgTimePerLesson.ToString("F2") + " segundos";
        uiManager.UpdateUI(report);
    }

    public void UpdateReport()
    {
        GenerateReport(); // Actualiza el reporte en tiempo real
    }
}
