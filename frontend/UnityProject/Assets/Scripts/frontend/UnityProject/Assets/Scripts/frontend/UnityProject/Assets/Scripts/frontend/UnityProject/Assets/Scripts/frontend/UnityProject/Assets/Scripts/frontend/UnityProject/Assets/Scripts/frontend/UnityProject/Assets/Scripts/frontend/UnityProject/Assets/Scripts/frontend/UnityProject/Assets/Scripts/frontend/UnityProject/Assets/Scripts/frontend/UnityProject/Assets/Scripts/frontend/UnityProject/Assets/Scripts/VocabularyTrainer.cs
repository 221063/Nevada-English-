using UnityEngine;

public class VocabularyTrainer : MonoBehaviour
{
    public LessonManager lessonManager;    // Referencia al LessonManager
    public UIManager uiManager;            // Referencia al UIManager
    public NarrativeTrigger narrativeTrigger; // Nueva referencia
    public PlayerStats playerStats;        // Referencia a PlayerStats (asumido)

    void Start()
    {
        if (lessonManager == null || uiManager == null || narrativeTrigger == null || playerStats == null)
        {
            Debug.LogError("Asigna todas las referencias en el Inspector.");
        }
    }

    public string GetRandomVocabulary()
    {
        // Lógica para devolver una palabra aleatoria (placeholder)
        return "Hello"; // Ejemplo
    }

    public bool VerifyPronunciation(AudioClip clip, string targetWord)
    {
        // Lógica de verificación de pronunciación (placeholder)
        return Random.value > 0.3f; // 70% de probabilidad de éxito
    }

    public void TrainVocabulary()
    {
        string currentLesson = lessonManager.GetCurrentLessonName();
        string targetWord = GetRandomVocabulary();
        uiManager.UpdateUI("Practica: " + targetWord);

        // Simulación de entrenamiento (puede incluir entrada de voz o texto)
        bool isPronunciationSuccess = VerifyPronunciation(Microphone.Start(null, false, 5, 44100), targetWord);
        Microphone.End(null); // Detiene la grabación

        if (isPronunciationSuccess || Random.value > 0.2f) // 80% de éxito general
        {
            uiManager.UpdateUI("¡Correcto! +5 puntos por " + targetWord);
            playerStats.AddScore(5);
            if (narrativeTrigger != null)
            {
                narrativeTrigger.TriggerOnVocabularySuccess(currentLesson, isPronunciationSuccess); // Llama al evento narrativo
            }
        }
        else
        {
            uiManager.UpdateUI("Incorrecto. Intenta de nuevo con " + targetWord);
            learningAnalytics.RecordFailure(); // Asume que está accesible
        }
    }
}
