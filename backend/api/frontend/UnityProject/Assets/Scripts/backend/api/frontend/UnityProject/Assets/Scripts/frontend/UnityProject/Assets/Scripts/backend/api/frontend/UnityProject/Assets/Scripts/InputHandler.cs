using UnityEngine;

public class InputHandler : MonoBehaviour
{
    public GameManager gameManager;    // Referencia al GameManager
    public NetworkManager networkManager;  // Referencia al NetworkManager

    void Start()
    {
        if (gameManager == null || networkManager == null)
        {
            Debug.LogError("Asigna GameManager y NetworkManager en el Inspector.");
        }
    }

    void Update()
    {
        // Iniciar combate con tecla Space y enviar datos al backend
        if (Input.GetKeyDown(KeyCode.Space))
        {
            gameManager.StartCombat();
            networkManager.SendPhoneticData("excited", "combat"); // Ejemplo de datos
        }

        // Terminar combate con tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.EndCombat();
        }
    }
}
