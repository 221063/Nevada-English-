using UnityEngine;

public class Storyteller : MonoBehaviour
{
    public UIManager uiManager;         // Referencia al UIManager
    public LessonManager lessonManager; // Referencia al LessonManager
    private string[] storyLines = {
        "Bienvenido a Nevada-English. ¡Empecemos con lo básico!",
        "¡Bien hecho! Ahora aprende más palabras básicas.",
        "¡Subiste de nivel! Explora el inglés intermedio."
    }; // Líneas de historia por nivel

    void Start()
    {
        if (uiManager == null || lessonManager == null)
        {
            Debug.LogError("Asigna UIManager y LessonManager en el Inspector.");
        }
        TellStory();
    }

    public void TellStory()
    {
        int currentLevel = lessonManager.progressManager.playerStats.level;
        if (currentLevel >= 0 && currentLevel < storyLines.Length)
        {
            uiManager.UpdateUI("Narrador: " + storyLines[currentLevel]);
        }
        else
        {
            uiManager.UpdateUI("Narrador: ¡Has completado la aventura! Eres un maestro.");
        }
    }

    public void AdvanceStory()
    {
        TellStory(); // Actualiza la historia al avanzar de nivel o evento
    }
}
