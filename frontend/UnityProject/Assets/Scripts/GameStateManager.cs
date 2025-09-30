using UnityEngine;

public class GameStateManager : MonoBehaviour
{
    public enum GameState { Menu, Combat, Paused }
    private GameState currentState = GameState.Menu;
    public GameManager gameManager;  // Referencia al GameManager

    void Start()
    {
        if (gameManager == null)
        {
            Debug.LogError("Asigna GameManager en el Inspector.");
        }
        UpdateGameState(currentState);
    }

    public void SetState(GameState newState)
    {
        currentState = newState;
        UpdateGameState(currentState);
    }

    private void UpdateGameState(GameState state)
    {
        switch (state)
        {
            case GameState.Combat:
                gameManager.StartCombat();
                break;
            case GameState.Menu:
                // Lógica para menú (a implementar)
                break;
            case GameState.Paused:
                // Lógica para pausa (a implementar)
                break;
        }
    }

    public GameState GetCurrentState()
    {
        return currentState;
    }
}
