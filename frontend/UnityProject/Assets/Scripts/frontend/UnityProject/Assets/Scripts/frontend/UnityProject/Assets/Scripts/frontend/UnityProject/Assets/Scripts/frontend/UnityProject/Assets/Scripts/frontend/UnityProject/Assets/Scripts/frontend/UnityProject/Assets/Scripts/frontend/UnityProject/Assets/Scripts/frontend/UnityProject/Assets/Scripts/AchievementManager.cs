using UnityEngine;

public class AchievementManager : MonoBehaviour
{
    public PlayerStats playerStats;    // Referencia a PlayerStats
    public UIManager uiManager;        // Referencia a UIManager

    void Start()
    {
        if (playerStats == null || uiManager == null)
        {
            Debug.LogError("Asigna PlayerStats y UIManager en el Inspector.");
        }
        CheckAchievements();
    }

    public void CheckAchievements()
    {
        if (playerStats.score >= 500)
        {
            UnlockAchievement("Maestro de Pronunciación");
        }
        if (playerStats.level >= 3)
        {
            UnlockAchievement("Explorador de Niveles");
        }
    }

    private void UnlockAchievement(string achievementName)
    {
        uiManager.UpdateUI("¡Logro desbloqueado: " + achievementName + "!");
        Debug.Log("Logro desbloqueado: " + achievementName);
        // Aquí podrías guardar el logro (e.g., con SaveSystem)
    }
}
