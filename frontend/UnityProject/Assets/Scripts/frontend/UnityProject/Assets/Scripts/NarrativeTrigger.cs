using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    public Storyteller storyteller;        // Referencia al Storyteller
    public LessonManager lessonManager;    // Referencia al LessonManager
    public ProgressTracker progressTracker; // Referencia al ProgressTracker
    public TeamChallengeManager teamChallengeManager; // Referencia al TeamChallengeManager
    public LearningAnalytics learningAnalytics; // Referencia al LearningAnalytics
    public UIManager uiManager;            // Referencia al UIManager

    void Start()
    {
        if (storyteller == null || lessonManager == null || progressTracker == null || 
            teamChallengeManager == null || learningAnalytics == null || uiManager == null)
        {
            Debug.LogError("Asigna todas las referencias en el Inspector.");
        }
        CheckNarrativeTriggers();
    }

    void Update()
    {
        CheckNarrativeTriggers(); // Verifica continuamente
    }

    private void CheckNarrativeTriggers()
    {
        string currentLesson = lessonManager.GetCurrentLessonName(); // Asume este método
        int wordsLearned = progressTracker.wordsLearned;
        int teamScore = teamChallengeManager != null ? teamChallengeManager.teamScore : 0;
        float playTime = progressTracker.playTime;
        int wordsFailed = learningAnalytics.wordsFailed;

        // Condiciones por lección
        switch (currentLesson)
        {
            case "Lección 1: Saludos":
                if (wordsLearned >= 5)
                {
                    TriggerNarrative("¡Has dominado los saludos! Un personaje te saluda en la historia.");
                }
                break;

            case "Lección 2: Números":
                if (wordsLearned >= 10)
                {
                    TriggerNarrative("¡Contaste hasta 10! Un mercader te ofrece un trato narrativo.");
                }
                else if (wordsFailed >= 3)
                {
                    TriggerNarrative("Has fallado 3 números... Un guía te ayuda a practicar.");
                }
                break;

            case "Lección 3: Familia":
                if (teamScore >= 50)
                {
                    TriggerNarrative("¡Tu equipo ayudó con la familia! Un nuevo miembro se une a la narrativa.");
                }
                break;
        }

        // Condiciones generales
        if (playTime >= 3600)
        {
            TriggerNarrative("¡Has jugado 1 hora! La historia celebra tu dedicación.");
        }
    }

    public void TriggerOnQuizSuccess(string lessonName, QuizGenerator.QuestionType questionType)
    {
        string narrativeEvent = "";
        switch (lessonName)
        {
            case "Lección 1: Saludos":
                narrativeEvent = "¡Acertaste un saludo en el quiz! El personaje te da una bienvenida especial.";
                break;
            case "Lección 2: Números":
                if (questionType == QuizGenerator.QuestionType.MultipleChoice)
                    narrativeEvent = "¡Acertaste un número en el quiz! El mercader te confía un secreto.";
                else if (questionType == QuizGenerator.QuestionType.Audio)
                    narrativeEvent = "¡Tu pronunciación fue perfecta! El mercader te aplaude.";
                break;
            case "Lección 3: Familia":
                narrativeEvent = "¡Acertaste un término familiar en el quiz! La familia te agradece.";
                break;
        }
        if (!string.IsNullOrEmpty(narrativeEvent))
        {
            TriggerNarrative(narrativeEvent);
        }
    }

    private void TriggerNarrative(string eventMessage)
    {
        storyteller.AdvanceStory(); // Actualiza la narrativa
        uiManager.UpdateUI(eventMessage); // Muestra el mensaje
    }
}
