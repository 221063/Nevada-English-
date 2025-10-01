using UnityEngine;

public class LessonManager : MonoBehaviour
{
    public ProgressManager progressManager; // Referencia a ProgressManager
    private string[] lessons = { "Basico 1", "Basico 2", "Intermedio 1" }; // Lecciones por nivel

    void Start()
    {
        if (progressManager == null)
        {
            Debug.LogError("Asigna ProgressManager en el Inspector.");
        }
        LoadCurrentLesson();
    }

    public void LoadCurrentLesson()
    {
        int currentLevel = progressManager.playerStats.level;
        if (currentLevel >= 0 && currentLevel < lessons.Length)
        {
            Debug.Log("Lección actual: " + lessons[currentLevel]);
        }
        else
        {
            Debug.Log("¡Has completado todas las lecciones!");
        }
    }

    public string GetCurrentLesson()
    {
        int currentLevel = progressManager.playerStats.level;
        return currentLevel < lessons.Length ? lessons[currentLevel] : "Completado";
    }
}
