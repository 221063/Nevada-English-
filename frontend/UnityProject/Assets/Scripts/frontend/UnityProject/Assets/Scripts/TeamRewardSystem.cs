using UnityEngine;

public class TeamRewardSystem : MonoBehaviour
{
    public TeamChallengeManager teamChallengeManager; // Referencia al TeamChallengeManager
    public PlayerStats playerStats;                  // Referencia a PlayerStats
    public UIManager uiManager;                      // Referencia al UIManager
    private int teamLevel;                           // Nivel del equipo
    private bool hasSpecialReward;                   // Estado de recompensa especial

    void Start()
    {
        if (teamChallengeManager == null || playerStats == null || uiManager == null)
        {
            Debug.LogError("Asigna TeamChallengeManager, PlayerStats y UIManager en el Inspector.");
        }
        teamLevel = 1;
        hasSpecialReward = false;
        CheckRewards();
    }

    public void CheckRewards()
    {
        int teamScore = teamChallengeManager.teamScore;
        if (teamScore >= 100 && teamLevel < 5)
        {
            teamLevel++;
            playerStats.AddScore(50); // Recompensa para todos
            uiManager.UpdateUI("¡Equipo subió a nivel " + teamLevel + "! +50 puntos por miembro.");
        }
        if (teamScore >= 200 && !hasSpecialReward)
        {
            hasSpecialReward = true;
            uiManager.UpdateUI("¡Desbloqueado: Recompensa especial para el equipo!");
            // Lógica futura para desbloqueo (e.g., nuevo desafío)
        }
    }

    public void OnChallengeCompleted(bool success)
    {
        if (success)
        {
            CheckRewards();
        }
    }
}
