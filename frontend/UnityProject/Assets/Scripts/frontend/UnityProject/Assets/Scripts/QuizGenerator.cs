using UnityEngine;

public class QuizGenerator : MonoBehaviour
{
    public LessonManager lessonManager;    // Referencia al LessonManager
    public VocabularyTrainer vocabularyTrainer; // Referencia al VocabularyTrainer
    public UIManager uiManager;            // Referencia al UIManager
    private string currentQuestion;        // Pregunta actual
    private string correctAnswer;          // Respuesta correcta
    private string[] options = new string[4]; // Opciones de respuesta (para tipo múltiple)
    private enum QuestionType { MultipleChoice, Written, Audio, ImageMatch } // Tipos de preguntas
    private QuestionType currentType;      // Tipo de pregunta actual

    void Start()
    {
        if (lessonManager == null || vocabularyTrainer == null || uiManager == null)
        {
            Debug.LogError("Asigna LessonManager, VocabularyTrainer y UIManager en el Inspector.");
        }
        GenerateQuiz();
    }

    public void GenerateQuiz()
    {
        string currentLesson = lessonManager.GetCurrentLesson();
        string targetWord = vocabularyTrainer.GetRandomVocabulary();
        correctAnswer = targetWord;

        // Selecciona un tipo de pregunta aleatoriamente
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
        // Simulación simple de mezcla
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
                // Placeholder: Asume que VocabularyTrainer verifica el audio
                AudioClip clip = Microphone.Start(null, false, 5, 44100); // Graba 5 segundos
                isCorrect = vocabularyTrainer.VerifyPronunciation(clip, correctAnswer);
                Microphone.End(null); // Detiene la grabación
                break;
        }

        if (isCorrect)
        {
            uiManager.UpdateUI("¡Correcto! +10 puntos.");
            vocabularyTrainer.playerStats.AddScore(10); // Asume que PlayerStats está en VocabularyTrainer
        }
        else
        {
            uiManager.UpdateUI("Incorrecto. Intenta de nuevo.");
        }
        GenerateQuiz(); // Nueva pregunta
    }
}
