using UnityEngine;

public class ProgressManager : MonoBehaviour
{
    public PlayerStats playerStats;    // Referencia a PlayerStats
    public GameStateManager gameStateManager; // Referencia a GameStateManager
    private int requiredScorePerLevel = 100; // Puntos necesarios por nivel

    void Start()
    {
        if (playerStats == null || gameStateManager == null)
        {
            Debug.LogError("Asigna PlayerStats y GameStateManager en el Inspector.");
        }
        CheckProgress();
    }

    public void CheckProgress()
    {
        int currentLevel = playerStats.level;
        int requiredScore = currentLevel * requiredScorePerLevel;

        if (playerStats.score >= requiredScore)
        {
            playerStats.level++;
            Debug.Log("¡Nivel desbloqueado! Nivel actual: " + playerStats.level);
            // Opcional: Cambiar a estado de menú o victoria
            gameStateManager.SetState(GameStateManager.GameState.Menu);
        }
    }
}
