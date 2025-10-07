using UnityEngine;

public class QuizGenerator : MonoBehaviour
{
    public LessonManager lessonManager;    // Referencia al LessonManager
    public VocabularyTrainer vocabularyTrainer; // Referencia al VocabularyTrainer
    public UIManager uiManager;            // Referencia al UIManager
    public NarrativeTrigger narrativeTrigger; // Nueva referencia

    private string currentQuestion;        // Pregunta actual
    private string correctAnswer;          // Respuesta correcta
    private string[] options = new string[4]; // Opciones de respuesta (para tipo múltiple)
    private enum QuestionType { MultipleChoice, Written, Audio, ImageMatch } // Tipos de preguntas
    private QuestionType currentType;      // Tipo de pregunta actual

    void Start()
    {
        if (lessonManager == null || vocabularyTrainer == null || uiManager == null || narrativeTrigger == null)
        {
            Debug.LogError("Asigna todas las referencias en el Inspector.");
        }
        GenerateQuiz();
    }

    public void GenerateQuiz()
    {
        string currentLesson = lessonManager.GetCurrentLessonName();
        string targetWord = vocabularyTrainer.GetRandomVocabulary();
        correctAnswer = targetWord;

        currentType = (QuestionType)Random.Range(0, System.Enum.GetValues(typeof(QuestionType)).Length);
        switch (currentType)
        {
            case QuestionType.MultipleChoice:
                currentQuestion = "Traduce: " + targetWord;
                options[0] = targetWord + " (correcto)";
                options[1] = "Wrong1";
                options[2] = "Wrong2";
                options[3] = "Wrong3";
                ShuffleOptions();
                DisplayQuiz();
                break;

            case QuestionType.Written:
                currentQuestion = "Escribe la traducción de: " + targetWord;
                DisplayQuiz();
                break;

            case QuestionType.Audio:
                currentQuestion = "Pronuncia: " + targetWord;
                DisplayQuiz();
                break;

            case QuestionType.ImageMatch:
                currentQuestion = "Asocia la imagen con: " + targetWord;
                options[0] = targetWord + " (correcto)";
                options[1] = "Wrong1";
                options[2] = "Wrong2";
                options[3] = "Wrong3";
                ShuffleOptions();
                DisplayQuiz();
                break;
        }
    }

    private void ShuffleOptions()
    {
        for (int i = 0; i < options.Length; i++)
        {
            int r = Random.Range(i, options.Length);
            string temp = options[i];
            options[i] = options[r];
            options[r] = temp;
        }
    }

    private void DisplayQuiz()
    {
        string quizText = currentQuestion + "\n";
        if (currentType == QuestionType.MultipleChoice || currentType == QuestionType.ImageMatch)
        {
            quizText += "Opciones: ";
            foreach (string option in options)
            {
                quizText += option + " ";
            }
        }
        uiManager.UpdateUI(quizText);
    }

    public void CheckAnswer(string selectedOption)
    {
        bool isCorrect = false;
        string currentLesson = lessonManager.GetCurrentLessonName();
        switch (currentType)
        {
            case QuestionType.MultipleChoice:
            case QuestionType.ImageMatch:
                isCorrect = selectedOption.Contains("(correcto)");
                break;

            case QuestionType.Written:
                isCorrect = selectedOption.ToLower() == correctAnswer.ToLower();
                break;

            case QuestionType.Audio:
                AudioClip clip = Microphone.Start(null, false, 5, 44100); // Graba 5 segundos
                isCorrect = vocabularyTrainer.VerifyPronunciation(clip, correctAnswer);
                Microphone.End(null); // Detiene la grabación
                break;
        }

        if (isCorrect)
        {
            uiManager.UpdateUI("¡Correcto! +10 puntos.");
            vocabularyTrainer.playerStats.AddScore(10);
            if (narrativeTrigger != null)
            {
                narrativeTrigger.TriggerOnQuizSuccess(currentLesson, currentType); // Llama al evento narrativo
            }
        }
        else
        {
            uiManager.UpdateUI("Incorrecto. Intenta de nuevo.");
        }
        GenerateQuiz(); // Nueva pregunta
    }
}
