using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARLessonVisualizer : MonoBehaviour
{
    public LessonManager lessonManager;    // Referencia al LessonManager
    public ARContentSpawner arContentSpawner; // Referencia al ARContentSpawner
    public UIManager uiManager;            // Referencia al UIManager
    public GameObject lessonPrefab;        // Prefab para visualizar la lección

    void Start()
    {
        if (lessonManager == null || arContentSpawner == null || uiManager == null || lessonPrefab == null)
        {
            Debug.LogError("Asigna LessonManager, ARContentSpawner, UIManager y lessonPrefab en el Inspector.");
        }
        VisualizeLesson();
    }

    public void VisualizeLesson()
    {
        string currentLesson = lessonManager.GetCurrentLesson();
        uiManager.UpdateUI("Visualizando lección: " + currentLesson);
        arContentSpawner.wordPrefab = lessonPrefab; // Asigna el prefab
        arContentSpawner.SpawnContent(); // Instancia el objeto AR
    }

    public void UpdateVisualization()
    {
        VisualizeLesson(); // Actualiza la visualización si cambia la lección
    }
}
