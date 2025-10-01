using UnityEngine;

public class LeaderboardManager : MonoBehaviour
{
    public PlayerStats playerStats;      // Referencia a PlayerStats
    public MultiplayerSync multiplayerSync; // Referencia al MultiplayerSync
    public UIManager uiManager;          // Referencia al UIManager
    private string[] leaderboardEntries = new string[5]; // Simula 5 posiciones

    void Start()
    {
        if (playerStats == null || multiplayerSync == null || uiManager == null)
        {
            Debug.LogError("Asigna PlayerStats, MultiplayerSync y UIManager en el Inspector.");
        }
        UpdateLeaderboard();
    }

    public void UpdateLeaderboard()
    {
        // Simula datos de la tabla (placeholder)
        leaderboardEntries[0] = "Jugador1: 1000";
        leaderboardEntries[1] = "Jugador2: 800";
        leaderboardEntries[2] = "Tú: " + playerStats.score;
        leaderboardEntries[3] = "Oponente: " + PlayerPrefs.GetInt(multiplayerSync.opponentScoreKey, 0);
        leaderboardEntries[4] = "Jugador3: 500";

        string leaderboardText = "Tabla de clasificación:\n";
        foreach (string entry in leaderboardEntries)
        {
            leaderboardText += entry + "\n";
        }
        uiManager.UpdateUI(leaderboardText);
    }

    public void SubmitScore()
    {
        // Simula enviar puntuación (placeholder)
        uiManager.UpdateUI("Puntuación enviada: " + playerStats.score);
        UpdateLeaderboard();
    }
}
