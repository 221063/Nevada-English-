using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public ChallengeGenerator challengeGenerator; // Referencia al ChallengeGenerator
    public PlayerStats playerStats;              // Referencia a PlayerStats
    public AchievementManager achievementManager; // Referencia al AchievementManager
    public UIManager uiManager;                  // Referencia al UIManager

    void Start()
    {
        if (challengeGenerator == null || playerStats == null || achievementManager == null || uiManager == null)
        {
            Debug.LogError("Asigna ChallengeGenerator, PlayerStats, AchievementManager y UIManager en el Inspector.");
        }
    }

    public void GrantReward(AudioClip clip)
    {
        string challengeType = GetCurrentChallengeType();
        if (challengeGenerator.VerifyChallenge(clip, challengeType))
        {
            int rewardPoints = GetRewardPoints(challengeType);
            playerStats.AddScore(rewardPoints);
            uiManager.UpdateUI("¡Desafío completado! + " + rewardPoints + " puntos.");
            achievementManager.CheckAchievements();
        }
        else
        {
            uiManager.UpdateUI("Desafío fallido. Intenta de nuevo.");
        }
    }

    private string GetCurrentChallengeType()
    {
        // Simula obtener el tipo de desafío actual (a implementar con guardado)
        return challengeGenerator.challengeTypes[Random.Range(0, challengeGenerator.challengeTypes.Length)];
    }

    private int GetRewardPoints(string challengeType)
    {
        switch (challengeType)
        {
            case "Repetir 3 veces":
                return 20;
            case "Rápido":
                return 15;
            case "Con gesto":
                return 25;
            default:
                return 10;
        }
    }
}
