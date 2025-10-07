using UnityEngine;

public class NarrativeTrigger : MonoBehaviour
{
    public Storyteller storyteller;        // Referencia al Storyteller
    public LessonManager lessonManager;    // Referencia al LessonManager
    public ProgressTracker progressTracker; // Referencia al ProgressTracker
    public TeamChallengeManager teamChallengeManager; // Referencia al TeamChallengeManager
    public LearningAnalytics learningAnalytics; // Referencia al LearningAnalytics
    public UIManager uiManager;            // Referencia al UIManager
    public QuizGenerator quizGenerator;    // Referencia al QuizGenerator

    void Start()
    {
        if (storyteller == null || lessonManager == null || progressTracker == null || 
            teamChallengeManager == null || learningAnalytics == null || uiManager == null || quizGenerator == null)
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

            case "Lección 4: Comida":
                if (wordsLearned >= 15)
                {
                    TriggerNarrative("¡Aprendiste 15 palabras de comida! Un chef te invita a una fiesta narrativa.");
                }
                else if (wordsFailed >= 4)
                {
                    TriggerNarrative("Fallaste 4 palabras de comida... El chef te da una receta fácil.");
                }
                break;

            case "Lección 5: Colores":
                if (wordsLearned >= 8)
                {
                    TriggerNarrative("¡Dominaste los colores! Un artista pinta tu historia.");
                }
                else if (playTime >= 1800) // 30 minutos
                {
                    TriggerNarrative("¡Llevas 30 minutos con colores! El artista te da un consejo.");
                }
                break;

            case "Lección 6: Verbos":
                if (teamScore >= 150)
                {
                    TriggerNarrative("¡Tu equipo llegó a 150 puntos con verbos! Un héroe narra tu hazaña.");
                }
                else if (wordsFailed >= 6)
                {
                    TriggerNarrative("Fallaste 6 verbos... Un maestro te enseña un truco narrativo.");
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
            case "Lección 4: Comida":
                narrativeEvent = "¡Acertaste una palabra de comida en el quiz! El chef te ofrece un plato especial.";
                break;
            case "Lección 5: Colores":
                narrativeEvent = "¡Acertaste un color en el quiz! El artista te da un pincel narrativo.";
                break;
            case "Lección 6: Verbos":
                narrativeEvent = "¡Acertaste un verbo en el quiz! El héroe te elogia en la historia.";
                break;
        }
        if (!string.IsNullOrEmpty(narrativeEvent))
        {
            TriggerNarrative(narrativeEvent);
        }
    }

    public void TriggerOnVocabularySuccess(string lessonName, bool isPronunciationSuccess)
    {
        string narrativeEvent = "";
        switch (lessonName)
        {
            case "Lección 1: Saludos":
                narrativeEvent = isPronunciationSuccess ? 
                    "¡Tu pronunciación de un saludo fue impecable! El personaje te felicita." : 
                    "¡Practicaste un saludo con éxito! El personaje te anima.";
                break;
            case "Lección 2: Números":
                narrativeEvent = isPronunciationSuccess ? 
                    "¡Pronunciaste un número perfectamente! El mercader te recompensa." : 
                    "¡Repetiste un número con éxito! El mercader te guiña un ojo.";
                break;
            case "Lección 3: Familia":
                narrativeEvent = isPronunciationSuccess ? 
                    "¡Tu pronunciación familiar fue genial! La familia te abraza." : 
                    "¡Aprendiste un término familiar! La familia te saluda.";
                break;
            case "Lección 4: Comida":
                narrativeEvent = isPronunciationSuccess ? 
                    "¡Pronunciaste una palabra de comida perfectamente! El chef te aplaude." : 
                    "¡Practicaste comida con éxito! El chef te da una receta.";
                break;
            case "Lección 5: Colores":
                narrativeEvent = isPronunciationSuccess ? 
                    "¡Tu pronunciación de un color fue perfecta! El artista te pinta." : 
                    "¡Aprendiste un color con éxito! El artista te guiña.";
                break;
            case "Lección 6: Verbos":
                narrativeEvent = isPronunciationSuccess ? 
                    "¡Pronunciaste un verbo impecable! El héroe te nombra aprendiz." : 
                    "¡Practicaste un verbo con éxito! El héroe te anima.";
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
