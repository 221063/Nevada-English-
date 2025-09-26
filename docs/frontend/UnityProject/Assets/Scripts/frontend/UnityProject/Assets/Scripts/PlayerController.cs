using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Vector3 movement;
    public PhoneticCombatTracker combatTracker; // Referencia al tracker
    public ARManager arManager; // Referencia al manager AR

    void Update()
    {
        // Movimiento básico con el joystick virtual o teclas (reemplazar con AR)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");
        movement = new Vector3(moveX, 0.0f, moveZ).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime, Space.World);

        // Interactúa con objetivos al tocar
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("CombatTarget"))
                {
                    StartCombat(hit.collider.gameObject);
                }
            }
        }
    }

    void StartCombat(GameObject target)
    {
        if (combatTracker != null)
        {
            combatTracker.SendPhoneticInput("excited", "combat");
            Destroy(target, 1.0f); // Destruye el objetivo después de 1 segundo
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("CombatTarget"))
        {
            StartCombat(other.gameObject);
        }
    }
}
