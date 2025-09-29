using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameManager gameManager;  // Referencia al GameManager

    void Start()
    {
        if (gameManager == null)
        {
            Debug.LogError("Asigna GameManager en el Inspector.");
        }
    }

    void Update()
    {
        // Ejemplo: Iniciar combate con tecla Space
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.StartCombat();
        }

        // Ejemplo: Terminar combate con tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.EndCombat();
        }
    }
}
