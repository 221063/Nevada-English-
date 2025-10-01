using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARIntegration : MonoBehaviour
{
    public ARRaycastManager arRaycastManager; // Referencia al ARRaycastManager
    public InputHandler inputHandler;        // Referencia al InputHandler
    public UIManager uiManager;              // Referencia al UIManager

    void Start()
    {
        if (arRaycastManager == null || inputHandler == null || uiManager == null)
        {
            Debug.LogError("Asigna ARRaycastManager, InputHandler y UIManager en el Inspector.");
        }
    }

    public void PlaceContentOnSurface()
    {
        // Simula detección de superficie (requiere AR configurado)
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            uiManager.UpdateUI("Superficie detectada, ¡prepara tu pronunciación!");
            // Aquí podrías instanciar un objeto AR (a implementar)
        }
        else
        {
            uiManager.UpdateUI("Busca una superficie para AR...");
        }
    }

    public void StartVoiceAR()
    {
        inputHandler.StartRecording(); // Inicia grabación para AR interactivo
        PlaceContentOnSurface();       // Intenta colocar contenido
    }
}
