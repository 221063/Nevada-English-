using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int score = 0;        // Puntuación inicial
    public int level = 1;        // Nivel inicial
    public UIManager uiManager;  // Referencia a la UI

    void Start()
    {
        if (uiManager == null)
        {
            Debug.LogError("Asigna UIManager en el Inspector.");
        }
        UpdateUI();
    }

    public void AddScore(int points)
    {
        score += points;
        if (score >= level * 100)
        {
            level++;
        }
        UpdateUI();
    }

    public void ResetStats()
    {
        score = 0;
        level = 1;
        UpdateUI();
    }

    private void UpdateUI()
    {
        uiManager.UpdateUI($"Puntuación: {score} | Nivel: {level}");
    }
}
