using UnityEngine;

public class ChallengeGenerator : MonoBehaviour
{
    public LessonManager lessonManager;    // Referencia al LessonManager
    public VocabularyTrainer vocabularyTrainer; // Referencia al VocabularyTrainer
    public UIManager uiManager;            // Referencia al UIManager
    private string[] challengeTypes = { "Repetir 3 veces", "Con gesto", "Rápido" }; // Tipos de desafío

    void Start()
    {
        if (lessonManager == null || vocabularyTrainer == null || uiManager == null)
        {
            Debug.LogError("Asigna LessonManager, VocabularyTrainer y UIManager en el Inspector.");
        }
        GenerateChallenge();
    }

    public void GenerateChallenge()
    {
        string currentLesson = lessonManager.GetCurrentLesson();
        string targetWord = vocabularyTrainer.GetRandomVocabulary();
        string challengeType = challengeTypes[Random.Range(0, challengeTypes.Length)];
        string challenge = currentLesson + ": " + targetWord + " (" + challengeType + ")";
        uiManager.UpdateUI("Nuevo desafío: " + challenge);
        // Aquí podrías guardar el desafío para verificarlo
    }

    public bool VerifyChallenge(AudioClip clip, string challengeType)
    {
        if (clip != null)
        {
            float amplitude = vocabularyTrainer.voiceProcessor.GetAmplitude(clip);
            string tone = vocabularyTrainer.voiceProcessor.AnalyzeTone(amplitude);
            if (tone == "excited" && amplitude > 0.1f) // Simplificación
            {
                if (challengeType == "Repetir 3 veces")
                {
                    // Lógica futura para contar repeticiones (a implementar)
                    return true; // Placeholder
                }
                else if (challengeType == "Rápido")
                {
                    // Lógica futura para medir velocidad (a implementar)
                    return amplitude > 0.15f; // Placeholder
                }
                return true; // Para "Con gesto" (a implementar)
            }
        }
        return false;
    }
}
