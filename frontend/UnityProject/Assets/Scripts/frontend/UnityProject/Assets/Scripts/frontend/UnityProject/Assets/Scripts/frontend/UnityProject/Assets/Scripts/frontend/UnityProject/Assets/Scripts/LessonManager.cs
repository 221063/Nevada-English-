using UnityEngine;

public class LessonManager : MonoBehaviour
{
    public ProgressManager progressManager; // Referencia a ProgressManager
    private string[,] lessons = new string[3, 30]; // 3 niveles, 30 lecciones cada uno
    public NarrativeTrigger narrativeTrigger; // Nueva referencia

    void Start()
    {
        if (progressManager == null || narrativeTrigger == null)
        {
            Debug.LogError("Asigna ProgressManager y NarrativeTrigger en el Inspector.");
        }
        InitializeLessons();
        LoadCurrentLesson();
    }

    private void InitializeLessons()
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

    // Inicializar lecciones para cada nivel
    string[] basicLessons = GenerateLessons("Básico", 30);
    string[] intermediateLessons = GenerateLessons("Intermedio", 30);
    string[] advancedLessons = GenerateLessons("Avanzado", 30);

    for (int i = 0; i < 30; i++)
    {
        lessons[0, i] = basicLessons[i];         // Nivel Básico
        lessons[1, i] = intermediateLessons[i];   // Nivel Intermedio
        lessons[2, i] = advancedLessons[i];       // Nivel Avanzado
    }
}
  private string[] GenerateLessons(string levelPrefix, int count)
    {
        string[] lessonArray = new string[count];
        for (int i = 0; i < count; i++)
        {
            lessonArray[i] = $"{levelPrefix} {i + 1}";
        }
        return lessonArray;
    }

    public void LoadCurrentLesson()
    {
        int currentLevelIndex = progressManager.playerStats.level / 30; // Nivel (0-2)
        int lessonIndex = progressManager.playerStats.level % 30;       // Lección dentro del nivel (0-29)
        if (progressManager.playerStats.level >= 0 && progressManager.playerStats.level < 90)
        {
            Debug.Log("Lección actual: " + lessons[currentLevelIndex, lessonIndex]);
        }
        else
        {
            Debug.Log("¡Has completado todos los niveles!");
        }
    }

    public string GetCurrentLesson()
    {
        int currentLevelIndex = progressManager.playerStats.level / 30; // Nivel (0-2)
        int lessonIndex = progressManager.playerStats.level % 30;       // Lección dentro del nivel (0-29)
        return progressManager.playerStats.level < 90 ? lessons[currentLevelIndex, lessonIndex] : "Completado";
    }

    public void AdvanceToNextLesson()
    {
        int currentLevel = progressManager.playerStats.level;
        if (currentLevel < 89) // Máximo 89 (29 en el nivel Avanzado)
        {
            progressManager.playerStats.level++; // Avanza al siguiente nivel o lección
            progressManager.playerStats.score = 0; // Reinicia el score para la nueva lección
            LoadCurrentLesson();
            if (narrativeTrigger != null)
            {
                narrativeTrigger.OnLessonCompleted(GetCurrentLesson()); // Notifica a NarrativeTrigger
            }
        }
    }
}
