using UnityEngine;

public class VocabularyTrainer : MonoBehaviour
{
    public LessonManager lessonManager;    // Referencia al LessonManager
    public VoiceProcessor voiceProcessor;  // Referencia al VoiceProcessor
    public UIManager uiManager;            // Referencia al UIManager
    private string[] vocabulary = { "Hello", "Goodbye", "Thank you" }; // Palabras por lección (a expandir)

    void Start()
    {
        if (lessonManager == null || voiceProcessor == null || uiManager == null)
        {
            Debug.LogError("Asigna LessonManager, VoiceProcessor y UIManager en el Inspector.");
        }
        SetCurrentVocabulary();
    }

    private void SetCurrentVocabulary()
    {
        string currentLesson = lessonManager.GetCurrentLesson();
        uiManager.UpdateUI("Practica la lección: " + currentLesson + ". Palabra: " + GetRandomVocabulary());
    }

    private string GetRandomVocabulary()
    {
        int index = Random.Range(0, vocabulary.Length);
        return vocabulary[index];
    }

    public void CheckPronunciation(AudioClip clip)
    {
        if (clip != null)
        {
            float amplitude = voiceProcessor.GetAmplitude(clip);
            string tone = voiceProcessor.AnalyzeTone(amplitude);
            string targetWord = GetRandomVocabulary();
            if (tone == "excited" && amplitude > 0.1f) // Simplificación: tono excitado = correcto
            {
                uiManager.UpdateUI("¡Correcto! Pronunciaste '" + targetWord + "' bien.");
            }
            else
            {
                uiManager.UpdateUI("Intenta de nuevo con '" + targetWord + "'.");
            }
        }
    }
}
