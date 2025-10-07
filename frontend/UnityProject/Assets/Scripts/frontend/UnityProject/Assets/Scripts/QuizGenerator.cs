using UnityEngine;

public class QuizGenerator : MonoBehaviour
{
    public LessonManager lessonManager;    // Referencia al LessonManager
    public VocabularyTrainer vocabularyTrainer; // Referencia al VocabularyTrainer
    public UIManager uiManager;            // Referencia al UIManager
    private string currentQuestion;        // Pregunta actual
    private string[] options = new string[4]; // Opciones de respuesta

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
        currentQuestion = "Traduce: " + targetWord;
        options[0] = targetWord + " (correcto)"; // Correcta
        options[1] = "Wrong1";
        options[2] = "Wrong2";
        options[3] = "Wrong3";
        ShuffleOptions();
        DisplayQuiz();
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
        string quizText = currentQuestion + "\nOpciones: ";
        foreach (string option in options)
        {
            quizText += option + " ";
        }
        uiManager.UpdateUI(quizText);
    }

    public void CheckAnswer(string selectedOption)
    {
        if (selectedOption.Contains("(correcto)"))
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
