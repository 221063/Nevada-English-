using UnityEngine;

public class ScoreTracker : MonoBehaviour
{
    public PlayerStats playerStats;    // Referencia a PlayerStats
    public PlayerFeedback playerFeedback; // Referencia a PlayerFeedback

    void Start()
    {
        if (playerStats == null || playerFeedback == null)
        {
            Debug.LogError("Asigna PlayerStats y PlayerFeedback en el Inspector.");
        }
    }

    public void UpdateScore(string tone)
    {
        if (tone == "excited")
        {
            playerStats.AddScore(10); // +10 puntos por buen tono
            Debug.Log("Puntuación actualizada: " + playerStats.score);
        }
        else if (tone == "calm")
        {
            playerStats.AddScore(-5); // -5 puntos por tono incorrecto
            Debug.Log("Puntuación penalizada: " + playerStats.score);
        }
    }
}
