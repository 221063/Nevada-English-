using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARInteractionHandler : MonoBehaviour
{
    public ARRaycastManager arRaycastManager; // Referencia al ARRaycastManager
    public ARContentSpawner arContentSpawner; // Referencia al ARContentSpawner
    public VocabularyTrainer vocabularyTrainer; // Referencia al VocabularyTrainer
    public InputHandler inputHandler;          // Referencia al InputHandler

    void Update()
    {
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.gameObject.CompareTag("ARObject"))
                {
                    HandleARInteraction(hit.collider.gameObject);
                }
            }
        }
    }

    private void HandleARInteraction(GameObject arObject)
    {
        string wordToPronounce = arObject.GetComponent<TextMesh>().text; // Asume TextMesh
        vocabularyTrainer.uiManager.UpdateUI("Pronuncia: " + wordToPronounce);
        inputHandler.StartRecording(); // Inicia grabación para verificar pronunciación
        // Lógica futura para verificar resultado (a implementar)
    }
}
