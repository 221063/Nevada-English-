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
        string currentLesson = lessonManager.GetCurrentLesson(); // Usa LessonManager
        int lessonProgress = progressTracker.wordsLearned; // Temporal hasta integrar progreso por lección
        int teamScore = teamChallengeManager != null ? teamChallengeManager.teamScore : 0;
        float playTime = progressTracker.playTime;
        int wordsFailed = learningAnalytics.wordsFailed;

        // Determinar el nivel actual
        int currentLevelIndex = progressManager.playerStats.level / 30;

        // Condiciones por lección basadas en progreso
        switch (currentLesson)
        {
            case string lesson when lesson.StartsWith("Básico"):
                if (lessonProgress >= 5 && int.Parse(lesson.Split(' ')[1]) % 10 == 0) // Cada 10 lecciones
                {
                    TriggerNarrative($"¡Completaste {lesson}! Un amigo te guía al siguiente paso.");
                }
                else if (wordsFailed >= 3)
                {
                    TriggerNarrative($"Fallaste 3 veces en {lesson}... Un guía te ayuda.");
                }
                break;

            case string lesson when lesson.StartsWith("Intermedio"):
                if (lessonProgress >= 10 && int.Parse(lesson.Split(' ')[1]) % 10 == 0) // Cada 10 lecciones
                {
                    TriggerNarrative($"¡Dominaste {lesson}! Un mercader te recompensa.");
                }
                else if (wordsFailed >= 5)
                {
                    TriggerNarrative($"Fallaste 5 veces en {lesson}... Un experto te apoya.");
                }
                break;

            case string lesson when lesson.StartsWith("Avanzado"):
                if (teamScore >= 50 && int.Parse(lesson.Split(' ')[1]) % 10 == 0) // Cada 10 lecciones
                {
                    TriggerNarrative($"¡Tu equipo brilló en {lesson}! Un héroe te elogia.");
                }
                else if (wordsFailed >= 7)
                {
                    TriggerNarrative($"Fallaste 7 veces en {lesson}... Un maestro te enseña.");
                }
                break;
        }

        // Condiciones generales
        if (playTime >= 3600)
        {
            TriggerNarrative("¡Has jugado 1 hora! La historia celebra tu dedicación.");
        }
    }

    public void OnLessonCompleted(string lessonName)
    {
        string narrativeEvent = "";
        if (lessonName == "Completado")
        {
            narrativeEvent = "¡Has terminado todos los niveles! La historia te corona como maestro.";
        }
        else
        {
            int lessonNumber = int.Parse(lessonName.Split(' ')[1]);
            string level = lessonName.Split(' ')[0];
            if (lessonNumber % 10 == 0 && lessonNumber <= 30) // Fin de cada decena en Básico
            {
                narrativeEvent = $"¡Completaste {lessonName}! El amigo te nombra avanzando a {level} {lessonNumber + 1}.";
            }
            else if (lessonNumber % 10 == 0 && lessonNumber <= 60) // Fin de cada decena en Intermedio
            {
                narrativeEvent = $"¡Masterizaste {lessonName}! El mercader te da un regalo.";
            }
            else if (lessonNumber % 10 == 0 && lessonNumber <= 90) // Fin de cada decena en Avanzado
            {
                narrativeEvent = $"¡Conquistaste {lessonName}! El héroe te honra.";
            }
        }
        if (!string.IsNullOrEmpty(narrativeEvent))
        {
            TriggerNarrative(narrativeEvent);
        }
    }

    public void TriggerOnQuizSuccess(string lessonName, QuizGenerator.QuestionType questionType)
    {
        string narrativeEvent = "";
        if (lessonName.StartsWith("Básico"))
        {
            narrativeEvent = $"¡Acertaste en {lessonName}! El amigo te anima.";
        }
        else if (lessonName.StartsWith("Intermedio"))
        {
            if (questionType == QuizGenerator.QuestionType.MultipleChoice)
                narrativeEvent = $"¡Acertaste en {lessonName}! El mercader te confía un secreto.";
            else if (questionType == QuizGenerator.QuestionType.Audio)
                narrativeEvent = $"¡Pronunciación perfecta en {lessonName}! El mercader te aplaude.";
        }
        else if (lessonName.StartsWith("Avanzado"))
        {
            narrativeEvent = $"¡Acertaste en {lessonName}! El héroe te elogia.";
        }
        else if (lessonName == "Completado")
        {
            narrativeEvent = "¡Sigue brillando tras completar todo! La historia te aplaude.";
        }
        if (!string.IsNullOrEmpty(narrativeEvent))
        {
            TriggerNarrative(narrativeEvent);
        }
    }

    public void TriggerOnVocabularySuccess(string lessonName, bool isPronunciationSuccess)
    {
        string narrativeEvent = "";
        if (lessonName.StartsWith("Básico"))
        {
            narrativeEvent = isPronunciationSuccess ? 
                $"¡Pronunciación impecable en {lessonName}! El amigo te felicita." : 
                $"¡Practicaste bien en {lessonName}! El amigo te anima.";
        }
        else if (lessonName.StartsWith("Intermedio"))
        {
            narrativeEvent = isPronunciationSuccess ? 
                $"¡Pronunciaste perfecto en {lessonName}! El mercader te recompensa." : 
                $"¡Repetiste bien en {lessonName}! El mercader te guiña.";
        }
        else if (lessonName.StartsWith("Avanzado"))
        {
            narrativeEvent = isPronunciationSuccess ? 
                $"¡Pronunciación genial en {lessonName}! El héroe te abraza." : 
                $"¡Aprendiste bien en {lessonName}! El héroe te saluda.";
        }
        else if (lessonName == "Completado")
        {
            narrativeEvent = isPronunciationSuccess ? 
                "¡Pronunciación maestra tras completar! La historia te ovaciona." : 
                "¡Sigue practicando tras completar! La historia te anima.";
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
