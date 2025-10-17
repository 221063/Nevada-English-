public void GenerateQuiz()
{
    // Tabla de contenido para Nevada-English
    // | Nivel      | Lección | Tema/Enfoque                                      |
    // |------------|---------|---------------------------------------------------|
    // | **Básico** | 1       | Introducción: Saludos y presentaciones            |
    // | **Básico** | 2       | Números del 1 al 10                              |
    // | **Básico** | 3       | Colores básicos                                   |
    // | **Básico** | 4       | Familia y relaciones básicas                      |
    // | **Básico** | 5       | Días de la semana                                 |
    // | **Básico** | 6       | Meses del año                                     |
    // | **Básico** | 7       | Alfabeto y pronunciación básica                   |
    // | **Básico** | 8       | Objetos del aula                                  |
    // | **Básico** | 9       | Comida básica (frutas y verduras)                 |
    // | **Básico** | 10      | Bebidas comunes                                   |
    // | **Básico** | 11      | Ropa básica                                       |
    // | **Básico** | 12      | Partes del cuerpo                                 |
    // | **Básico** | 13      | Verbos básicos (ser, estar, tener)                |
    // | **Básico** | 14      | Preguntas simples (¿Qué?, ¿Dónde?)                |
    // | **Básico** | 15      | Respuestas cortas (sí/no)                         |
    // | **Básico** | 16      | Horas y tiempo básico                             |
    // | **Básico** | 17      | Adjetivos básicos (grande, pequeño)               |
    // | **Básico** | 18      | Animales domésticos                               |
    // | **Básico** | 19      | Transportes básicos                               |
    // | **Básico** | 20      | Lugares en la ciudad                              |
    // | **Básico** | 21      | Compras básicas (precios)                         |
    // | **Básico** | 22      | Comidas del día                                   |
    // | **Básico** | 23      | Pronunciación: vocales                            |
    // | **Básico** | 24      | Conversación: Pedir ayuda                         |
    // | **Básico** | 25      | Números del 11 al 20                              |
    // | **Básico** | 26      | Verbos de acción (caminar, correr)                |
    // | **Básico** | 27      | Presente simple (afirmativo)                      |
    // | **Básico** | 28      | Pronombres personales                             |
    // | **Básico** | 29      | Revisión: Vocabulario básico                      |
    // | **Básico** | 30      | Proyecto: Presentación personal                   |
    // | **Intermedio** | 1       | Saludos formales e informales                     |
    // | **Intermedio** | 2       | Números del 21 al 100                             |
    // | **Intermedio** | 3       | Colores avanzados                                 |
    // | **Intermedio** | 4       | Familia extendida                                 |
    // | **Intermedio** | 5       | Tiempo (clima)                                    |
    // | **Intermedio** | 6       | Profesiones y trabajos                            |
    // | **Intermedio** | 7       | Comida (platos típicos)                           |
    // | **Intermedio** | 8       | Ropa para ocasiones especiales                    |
    // | **Intermedio** | 9       | Verbos reflexivos                                  |
    // | **Intermedio** | 10      | Preguntas con "how" y "why"                       |
    // | **Intermedio** | 11      | Presente continuo                                 |
    // | **Intermedio** | 12      | Adjetivos comparativos                            |
    // | **Intermedio** | 13      | Animales salvajes                                 |
    // | **Intermedio** | 14      | Transporte público                                |
    // | **Intermedio** | 15      | Direcciones y mapas                               |
    // | **Intermedio** | 16      | Compras (negociación)                             |
    // | **Intermedio** | 17      | Restaurantes (pedir comida)                       |
    // | **Intermedio** | 18      | Pronunciación: consonantes                        |
    // | **Intermedio** | 19      | Conversación: Hacer planes                        |
    // | **Intermedio** | 20      | Pasado simple (afirmativo)                        |
    // | **Intermedio** | 21      | Números del 101 al 1000                           |
    // | **Intermedio** | 22      | Verbos irregulares básicos                        |
    // | **Intermedio** | 23      | Adjetivos superlativos                            |
    // | **Intermedio** | 24      | Deportes y actividades                            |
    // | **Intermedio** | 25      | Tecnología y dispositivos                         |
    // | **Intermedio** | 26      | Salud y cuerpo (enfermedades)                     |
    // | **Intermedio** | 27      | Futuro con "going to"                             |
    // | **Intermedio** | 28      | Pronombres posesivos                              |
    // | **Intermedio** | 29      | Revisión: Gramática intermedia                    |
    // | **Intermedio** | 30      | Proyecto: Descripción de un lugar                 |
    // | **Avanzado** | 1       | Conversación formal (negocios)                    |
    // | **Avanzado** | 2       | Números grandes (miles, millones)                 |
    // | **Avanzado** | 3       | Colores y emociones                               |
    // | **Avanzado** | 4       | Relaciones complejas                              |
    // | **Avanzado** | 5       | Pronóstico del tiempo avanzado                    |
    // | **Avanzado** | 6       | Entrevistas de trabajo                            |
    // | **Avanzado** | 7       | Gastronomía internacional                         |
    // | **Avanzado** | 8       | Moda y tendencias                                 |
    // | **Avanzado** | 9       | Verbos frasales                                   |
    // | **Avanzado** | 10      | Preguntas indirectas                              |
    // | **Avanzado** | 11      | Presente perfecto                                 |
    // | **Avanzado** | 12      | Comparativos y superlativos complejos             |
    // | **Avanzado** | 13      | Ecología y medio ambiente                         |
    // | **Avanzado** | 14      | Viajes y culturas                                 |
    // | **Avanzado** | 15      | Negociaciones avanzadas                           |
    // | **Avanzado** | 16      | Restaurantes (quejas y sugerencias)               |
    // | **Avanzado** | 17      | Pronunciación: entonación                         |
    // | **Avanzado** | 18      | Debates y opiniones                               |
    // | **Avanzado** | 19      | Pasado perfecto                                   |
    // | **Avanzado** | 20      | Condicionales (if clauses)                        |
    // | **Avanzado** | 21      | Vocabulario académico                             |
    // | **Avanzado** | 22      | Verbos modales (should, must)                     |
    // | **Avanzado** | 23      | Narración de historias                            |
    // | **Avanzado** | 24      | Cultura y tradiciones                             |
    // | **Avanzado** | 25      | Tecnología avanzada                               |
    // | **Avanzado** | 26      | Salud mental y bienestar                          |
    // | **Avanzado** | 27      | Futuro perfecto                                   |
    // | **Avanzado** | 28      | Redacción formal                                  |
    // | **Avanzado** | 29      | Revisión: Temas avanzados                         |
    // | **Avanzado** | 30      | Proyecto: Presentación profesional                |

    string currentLesson = lessonManager.GetCurrentLesson();
    string targetWord = vocabularyTrainer.GetRandomVocabulary();
    correctAnswer = targetWord;

    currentType = (QuestionType)Random.Range(0, System.Enum.GetValues(typeof(QuestionType)).Length);
    switch (currentType)
    {
        case QuestionType.MultipleChoice:
            currentQuestion = "Traduce: " + targetWord;
            options[0] = targetWord + " (correcto)";
            switch (currentLesson)
            {
                case "Básico 1": // Saludos y presentaciones
                    options[1] = "Adiós"; options[2] = "Bienvenido"; options[3] = "Hasta pronto";
                    break;
                case "Básico 2": // Números del 1 al 10
                    options[1] = "3"; options[2] = "7"; options[3] = "9";
                    break;
                case "Básico 3": // Colores básicos
                    options[1] = "Rojo"; options[2] = "Verde"; options[3] = "Azul"; 
                    break;
                case "Básico 4": // Familia y relaciones básicas
                    options[1] = "Madre"; options[2] = "Hermano"; options[3] = "Hijo";
                    break;
                case "Básico 5": // Días de la semana
                    options[1] = "Jueves"; options[2] = "Domingo"; options[3] = "Martes";
                    break;
                // Añade más casos según la tabla
            }
            ShuffleOptions();
            DisplayQuiz();
            break;

        case QuestionType.Written:
            currentQuestion = "Escribe la traducción de: " + targetWord;
            switch (currentLesson)
            {
                case "Básico 1": // Saludos y presentaciones
                    currentQuestion = "Escribe un saludo: " + targetWord;
                    break;
                case "Básico 2": // Números del 1 al 10
                    currentQuestion = "Escribe un número: " + targetWord;
                    break;
                case "Básico 3": // Colores básicos
                    currentQuestion = "Escribe un color: " + targetWord;
                    break;
                case "Básico 4": // Familia y relaciones básicas
                    currentQuestion = "Escribe un miembro de la familia: " + targetWord;
                    break;
                case "Básico 5": // Días de la semana
                    currentQuestion = "Escribe un día de la semana: " + targetWord;
                    break;
                // Añade más
            }
            DisplayQuiz();
            break;

        case QuestionType.Audio:
            currentQuestion = "Pronuncia: " + targetWord;
            switch (currentLesson)
            {
                case "Básico 1": // Saludos y presentaciones
                    currentQuestion = "Pronuncia un saludo: " + targetWord;
                    break;
                case "Básico 2": // Números del 1 al 10
                    currentQuestion = "Pronuncia un número: " + targetWord;
                    break;
                case "Básico 3": // Colores básicos
                    currentQuestion = "Pronuncia un color: " + targetWord;
                    break;
                case "Básico 4": // Familia y relaciones básicas
                    currentQuestion = "Pronuncia un miembro de la familia: " + targetWord;
                    break;
                case "Básico 5": // Días de la semana
                    currentQuestion = "Pronuncia un día de la semana: " + targetWord;
                    break;
                // Añade más
            }
            DisplayQuiz();
            break;

        case QuestionType.ImageMatch:
            currentQuestion = "Asocia la imagen con: " + targetWord;
            options[0] = targetWord + " (correcto)";
            switch (currentLesson)
            {
                case "Básico 1": // Saludos y presentaciones
                    options[1] = "Adiós"; options[2] = "Bienvenido"; options[3] = "Mucho gusto";
                    break;
                case "Básico 2": // Números del 1 al 10
                    options[1] = "3"; options[2] = "7"; options[3] = "9";
                    break;
                case "Básico 3": // Colores básicos
                    options[1] = "Rojo"; options[2] = "Verde"; options[3] = "Azul";
                    break;
                case "Básico 4": // Familia y relaciones básicas
                    options[1] = "Hija"; options[2] = "Hermano"; options[3] = "Madre";
                    break;
                case "Básico 5": // Días de la semana
                    options[1] = "Jueves"; options[2] = "Martes"; options[3] = "Viernes";
                    break;
                // Añade más
            }
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
        string currentLesson = lessonManager.GetCurrentLesson();
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
