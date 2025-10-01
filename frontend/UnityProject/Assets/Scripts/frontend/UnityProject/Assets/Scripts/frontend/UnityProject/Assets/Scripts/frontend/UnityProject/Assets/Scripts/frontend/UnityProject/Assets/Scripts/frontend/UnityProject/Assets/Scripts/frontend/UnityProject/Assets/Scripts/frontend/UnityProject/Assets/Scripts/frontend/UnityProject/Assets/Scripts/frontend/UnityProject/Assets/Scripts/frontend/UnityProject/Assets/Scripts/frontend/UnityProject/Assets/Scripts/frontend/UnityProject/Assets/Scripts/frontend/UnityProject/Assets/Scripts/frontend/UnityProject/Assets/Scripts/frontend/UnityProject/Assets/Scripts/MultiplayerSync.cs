using UnityEngine;

public class MultiplayerSync : MonoBehaviour
{
    public PlayerStats playerStats;         // Referencia a PlayerStats
    public ChallengeGenerator challengeGenerator; // Referencia al ChallengeGenerator
    public UIManager uiManager;             // Referencia al UIManager
    private string opponentScoreKey = "OpponentScore"; // Clave para simular datos del oponente

    void Start()
    {
        if (playerStats == null || challengeGenerator == null || uiManager == null)
        {
            Debug.LogError("Asigna PlayerStats, ChallengeGenerator y UIManager en el Inspector.");
        }
        SyncWithOpponent();
    }

    public void SyncWithOpponent()
    {
        // Simula sincronización con un oponente (placeholder)
        int opponentScore = PlayerPrefs.GetInt(opponentScoreKey, 0);
        uiManager.UpdateUI("Tu puntuación: " + playerStats.score + " | Puntuación oponente: " + opponentScore);
        if (playerStats.score > opponentScore)
        {
            uiManager.UpdateUI("¡Lideras la tabla!");
        }
        else if (playerStats.score < opponentScore)
        {
            uiManager.UpdateUI("¡El oponente lidera! Supéralo.");
        }
    }

    public void SendChallengeToOpponent()
    {
        string challenge = challengeGenerator.GenerateChallenge().ToString(); // Placeholder
        uiManager.UpdateUI("Desafío enviado al oponente: " + challenge);
        // Lógica futura para enviar via red (a implementar)
    }

    public void ReceiveChallengeResult(bool success)
    {
        if (success)
        {
            playerStats.AddScore(10); // Recompensa por desafío recibido
            uiManager.UpdateUI("¡Desafío del oponente completado! +10 puntos.");
        }
        else
        {
            uiManager.UpdateUI("Fallaste el desafío del oponente.");
        }
        SyncWithOpponent();
    }
}
