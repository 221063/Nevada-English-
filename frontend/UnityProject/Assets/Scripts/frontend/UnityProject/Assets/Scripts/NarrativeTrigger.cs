using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    public Storyteller storyteller;        // Referencia al Storyteller
    public ProgressTracker progressTracker; // Referencia al ProgressTracker
    public TeamChallengeManager teamChallengeManager; // Referencia al TeamChallengeManager
    public LearningAnalytics learningAnalytics; // Referencia al LearningAnalytics
    public UIManager uiManager;            // Referencia al UIManager

    void Start()
    {
        if (storyteller == null || progressTracker == null || teamChallengeManager == null ||
            learningAnalytics == null || uiManager == null)
        {
            Debug.LogError("Asigna Storyteller, ProgressTracker, TeamChallengeManager, LearningAnalytics y UIManager en el Inspector.");
        }
        CheckNarrativeTriggers();
    }

    void Update()
    {
        CheckNarrativeTriggers(); // Verifica continuamente
    }

    private void CheckNarrativeTriggers()
    {
        int wordsLearned = progressTracker.wordsLearned;
        int teamScore = teamChallengeManager != null ? teamChallengeManager.teamScore : 0;
        float playTime = progressTracker.playTime;
        int wordsFailed = learningAnalytics.wordsFailed;

        // Condiciones narrativas
        if (wordsLearned >= 10 && wordsLearned < 20)
        {
            TriggerNarrative("¡Has aprendido 10 palabras! La historia avanza a un nuevo capítulo.");
        }
        else if (wordsLearned >= 20)
        {
            TriggerNarrative("¡Maestro del inglés! Nueva misión desbloqueada en tu viaje.");
        }
        else if (teamScore >= 100)
        {
            TriggerNarrative("¡Tu equipo ha alcanzado 100 puntos! Un aliado se une a la narrativa.");
        }
        else if (playTime >= 3600) // 1 hora en segundos
        {
            TriggerNarrative("¡Has jugado 1 hora! La historia celebra tu dedicación.");
        }
        else if (wordsFailed >= 5)
        {
            TriggerNarrative("Has fallado 5 veces... Un mentor aparece para guiarte.");
        }
    }

    private void TriggerNarrative(string eventMessage)
    {
        storyteller.AdvanceStory(); // Actualiza la narrativa
        uiManager.UpdateUI(eventMessage); // Muestra el mensaje
    }
}
