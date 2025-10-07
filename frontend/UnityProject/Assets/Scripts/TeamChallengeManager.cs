using UnityEngine;

public class TeamChallengeManager : MonoBehaviour
{
    public MultiplayerSync multiplayerSync; // Referencia al MultiplayerSync
    public ChallengeGenerator challengeGenerator; // Referencia al ChallengeGenerator
    public UIManager uiManager;             // Referencia al UIManager
    private string currentTeamChallenge;    // Desafío actual del equipo
    private int teamScore;                  // Puntuación del equipo

    void Start()
    {
        if (multiplayerSync == null || challengeGenerator == null || uiManager == null)
        {
            Debug.LogError("Asigna MultiplayerSync, ChallengeGenerator y UIManager en el Inspector.");
        }
        StartNewTeamChallenge();
    }

    public void StartNewTeamChallenge()
    {
        currentTeamChallenge = challengeGenerator.GenerateChallenge().ToString();
        teamScore = 0;
        uiManager.UpdateUI("Nuevo desafío de equipo: " + currentTeamChallenge + " | Puntuación: " + teamScore);
        multiplayerSync.SendChallengeToOpponent(); // Notifica a los oponentes
    }

    public void SubmitTeamResult(bool success)
    {
        if (success)
        {
            teamScore += 20; // Recompensa por éxito en equipo
            uiManager.UpdateUI("¡Desafío completado! Puntuación de equipo: " + teamScore);
            multiplayerSync.ReceiveChallengeResult(true); // Sincroniza éxito
        }
        else
        {
            uiManager.UpdateUI("Desafío fallido. Intenta de nuevo.");
            multiplayerSync.ReceiveChallengeResult(false); // Sincroniza fallo
        }
        StartNewTeamChallenge(); // Nuevo desafío
    }
}
