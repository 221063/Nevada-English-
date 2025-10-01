using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState { Menu, Combat, Paused, GameOver }
    public GameState currentState = GameState.Menu; // Estado inicial
    public CombatController combatController;      // Referencia al CombatController
    public UIManager uiManager;                    // Referencia al UIManager

    void Start()
    {
        if (combatController == null || uiManager == null)
        {
            Debug.LogError("Asigna CombatController y UIManager en el Inspector.");
        }
        UpdateGameState();
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        UpdateGameState();
    }

    private void UpdateGameState()
    {
        switch (currentState)
        {
            case GameState.Menu:
                uiManager.UpdateUI("En el menú principal. ¡Presiona para empezar!");
                break;
            case GameState.Combat:
                uiManager.UpdateUI("¡Combate iniciado!");
                combatController.StartCombatSequence();
                break;
            case GameState.Paused:
                uiManager.UpdateUI("Juego pausado. Presiona para continuar.");
                Time.timeScale = 0f; // Pausa el juego
                break;
            case GameState.GameOver:
                uiManager.UpdateUI("¡Juego terminado! Puntuación guardada.");
                break;
        }
    }

    public void ResumeGame()
    {
        if (currentState == GameState.Paused)
        {
            SetState(GameState.Combat); // Vuelve al combate
            Time.timeScale = 1f;       // Reanuda el tiempo
        }
    }
}
