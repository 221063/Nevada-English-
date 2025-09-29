using UnityEngine;

public class GameManager : MonoBehaviour
{
    public UIManager uiManager; // Referencia a la UI
    public PlayerController player; // Referencia al jugador
    private bool isCombatActive = false;

    void Start()
    {
        if (uiManager == null || player == null)
        {
            Debug.LogError("Asigna UIManager y PlayerController en el Inspector.");
        }
        uiManager.UpdateUI("¡Juego iniciado!");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isCombatActive)
        {
            StartCombat();
        }
    }

    void StartCombat()
    {
        isCombatActive = true;
        uiManager.UpdateUI("¡Combate iniciado! Pronuncia 'excited'.");
        player.StartCombat(null); // Simula interacción (ajustar con AR)
    }

    public void EndCombat()
    {
        isCombatActive = false;
        uiManager.ResetDifficulty();
        uiManager.UpdateUI("¡Combate terminado!");
    }
}
