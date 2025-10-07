using UnityEngine;

public class TeamRewardSystem : MonoBehaviour
{
    public TeamChallengeManager teamChallengeManager; // Referencia al TeamChallengeManager
    public PlayerStats playerStats;                  // Referencia a PlayerStats
    public UIManager uiManager;                      // Referencia al UIManager

    [System.Serializable] // Para mostrar en el Inspector
    public class RewardCondition
    {
        public int scoreThreshold; // Umbral de puntuación
        public int rewardPoints;   // Puntos a otorgar
        public string rewardMessage; // Mensaje de recompensa
        public bool isSpecial;     // Indica si es una recompensa especial
    }

    [SerializeField] // Permite editar en el Inspector
    private RewardCondition[] rewardConditions = new RewardCondition[]
    {
        new RewardCondition { scoreThreshold = 100, rewardPoints = 50, rewardMessage = "¡Equipo subió a nivel 2! +50 puntos por miembro.", isSpecial = false },
        new RewardCondition { scoreThreshold = 200, rewardPoints = 0, rewardMessage = "¡Desbloqueado: Recompensa especial para el equipo!", isSpecial = true }
    };

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
        foreach (RewardCondition condition in rewardConditions)
        {
            if (teamScore >= condition.scoreThreshold)
            {
                ApplyReward(condition);
            }
        }
    }

    private void ApplyReward(RewardCondition condition)
    {
        if (condition.isSpecial && hasSpecialReward) return; // Evita recompensas especiales duplicadas
        if (condition.isSpecial) hasSpecialReward = true;
        if (condition.rewardPoints > 0) playerStats.AddScore(condition.rewardPoints);
        uiManager.UpdateUI(condition.rewardMessage);
        if (!condition.isSpecial && teamLevel < 5) teamLevel++; // Incrementa nivel solo para no especiales
    }

    public void OnChallengeCompleted(bool success)
    {
        if (success)
        {
            CheckRewards();
        }
    }
}
