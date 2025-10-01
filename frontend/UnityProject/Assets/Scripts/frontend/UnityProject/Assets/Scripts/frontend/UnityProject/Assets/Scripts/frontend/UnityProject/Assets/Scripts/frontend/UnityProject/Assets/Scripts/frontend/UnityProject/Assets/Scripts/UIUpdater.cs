using UnityEngine;
using UnityEngine.UI;

public class UIUpdater : MonoBehaviour
{
    public Text scoreText;      // Referencia al Text para la puntuación
    public Text levelText;      // Referencia al Text para el nivel
    public Text lessonText;     // Referencia al Text para la lección
    public PlayerStats playerStats;    // Referencia a PlayerStats
    public ProgressManager progressManager; // Referencia a ProgressManager
    public LessonManager lessonManager;    // Referencia a LessonManager

    void Start()
    {
        if (scoreText == null || levelText == null || lessonText == null ||
            playerStats == null || progressManager == null || lessonManager == null)
        {
            Debug.LogError("Asigna todos los componentes en el Inspector.");
        }
        UpdateUI();
    }

    public void UpdateUI()
    {
        scoreText.text = "Puntuación: " + playerStats.score.ToString();
        levelText.text = "Nivel: " + progressManager.playerStats.level.ToString();
        lessonText.text = "Lección: " + lessonManager.GetCurrentLesson();
    }
}
