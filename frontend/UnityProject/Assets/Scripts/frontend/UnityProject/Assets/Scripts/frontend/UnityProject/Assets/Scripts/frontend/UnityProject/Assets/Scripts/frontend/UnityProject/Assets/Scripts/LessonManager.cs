using UnityEngine;

public class LessonManager : MonoBehaviour
{
    public ProgressManager progressManager; // Referencia a ProgressManager
    private string[,] lessons = new string[3, 30]; // 3 niveles, 30 lecciones cada uno
    public NarrativeTrigger narrativeTrigger; // Nueva referencia

    void Start()
    {
        if (progressManager == null || narrativeTrigger == null)
        {
            Debug.LogError("Asigna ProgressManager y NarrativeTrigger en el Inspector.");
        }
        InitializeLessons();
        LoadCurrentLesson();
    }

    private void InitializeLessons()
    {
        // Inicializar lecciones para cada nivel
        string[] basicLessons = GenerateLessons("Básico", 30);
        string[] intermediateLessons = GenerateLessons("Intermedio", 30);
        string[] advancedLessons = GenerateLessons("Avanzado", 30);

        for (int i = 0; i < 30; i++)
        {
            lessons[0, i] = basicLessons[i];         // Nivel Básico
            lessons[1, i] = intermediateLessons[i];   // Nivel Intermedio
            lessons[2, i] = advancedLessons[i];       // Nivel Avanzado
        }
    }

    private string[] GenerateLessons(string levelPrefix, int count)
    {
        string[] lessonArray = new string[count];
        for (int i = 0; i < count; i++)
        {
            lessonArray[i] = $"{levelPrefix} {i + 1}";
        }
        return lessonArray;
    }

    public void LoadCurrentLesson()
    {
        int currentLevelIndex = progressManager.playerStats.level / 30; // Nivel (0-2)
        int lessonIndex = progressManager.playerStats.level % 30;       // Lección dentro del nivel (0-29)
        if (progressManager.playerStats.level >= 0 && progressManager.playerStats.level < 90)
        {
            Debug.Log("Lección actual: " + lessons[currentLevelIndex, lessonIndex]);
        }
        else
        {
            Debug.Log("¡Has completado todos los niveles!");
        }
    }

    public string GetCurrentLesson()
    {
        int currentLevelIndex = progressManager.playerStats.level / 30; // Nivel (0-2)
        int lessonIndex = progressManager.playerStats.level % 30;       // Lección dentro del nivel (0-29)
        return progressManager.playerStats.level < 90 ? lessons[currentLevelIndex, lessonIndex] : "Completado";
    }

    public void AdvanceToNextLesson()
    {
        int currentLevel = progressManager.playerStats.level;
        if (currentLevel < 89) // Máximo 89 (29 en el nivel Avanzado)
        {
            progressManager.playerStats.level++; // Avanza al siguiente nivel o lección
            progressManager.playerStats.score = 0; // Reinicia el score para la nueva lección
            LoadCurrentLesson();
            if (narrativeTrigger != null)
            {
                narrativeTrigger.OnLessonCompleted(GetCurrentLesson()); // Notifica a NarrativeTrigger
            }
        }
    }
}
