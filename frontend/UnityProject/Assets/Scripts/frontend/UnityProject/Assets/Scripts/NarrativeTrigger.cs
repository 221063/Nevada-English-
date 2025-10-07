using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    public Storyteller storyteller;        // Referencia al Storyteller
    public ProgressTracker progressTracker; // Referencia al ProgressTracker
    public UIManager uiManager;            // Referencia al UIManager

    void Start()
    {
        if (storyteller == null || progressTracker == null || uiManager == null)
        {
            Debug.LogError("Asigna Storyteller, ProgressTracker y UIManager en el Inspector.");
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
        if (wordsLearned >= 10 && wordsLearned < 20)
        {
            TriggerNarrative("¡Has aprendido 10 palabras! La historia avanza.");
        }
        else if (wordsLearned >= 20)
        {
            TriggerNarrative("¡Maestro del inglés! Nueva misión desbloqueada.");
        }
    }

    private void TriggerNarrative(string eventMessage)
    {
        storyteller.AdvanceStory(); // Actualiza la narrativa
        uiManager.UpdateUI(eventMessage); // Muestra el mensaje
    }
}
