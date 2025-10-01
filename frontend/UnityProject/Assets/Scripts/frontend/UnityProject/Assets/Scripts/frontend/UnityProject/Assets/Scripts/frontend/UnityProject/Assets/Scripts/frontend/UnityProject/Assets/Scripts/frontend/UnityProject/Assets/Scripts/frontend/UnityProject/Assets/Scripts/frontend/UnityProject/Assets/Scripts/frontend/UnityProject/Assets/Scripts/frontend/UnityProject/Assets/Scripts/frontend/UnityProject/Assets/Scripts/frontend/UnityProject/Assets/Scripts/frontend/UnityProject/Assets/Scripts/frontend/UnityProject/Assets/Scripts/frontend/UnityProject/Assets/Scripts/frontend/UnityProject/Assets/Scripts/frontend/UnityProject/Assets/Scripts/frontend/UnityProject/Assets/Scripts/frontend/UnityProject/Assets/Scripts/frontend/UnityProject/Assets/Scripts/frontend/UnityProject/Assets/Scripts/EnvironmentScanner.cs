using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class EnvironmentScanner : MonoBehaviour
{
    public ARRaycastManager arRaycastManager; // Referencia al ARRaycastManager
    public GameStateManager gameStateManager; // Referencia al GameStateManager
    public UIManager uiManager;               // Referencia al UIManager

    void Start()
    {
        if (arRaycastManager == null || gameStateManager == null || uiManager == null)
        {
            Debug.LogError("Asigna ARRaycastManager, GameStateManager y UIManager en el Inspector.");
        }
        ScanEnvironment();
    }

    public void ScanEnvironment()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            int surfaceCount = hits.Count;
            AdjustGameBasedOnEnvironment(surfaceCount);
        }
        else
        {
            uiManager.UpdateUI("No se detectaron superficies. Busca un área adecuada.");
        }
    }

    private void AdjustGameBasedOnEnvironment(int surfaceCount)
    {
        if (surfaceCount > 2)
        {
            uiManager.UpdateUI("Espacio amplio detectado. Dificultad aumentada.");
            gameStateManager.SetState(GameStateManager.GameState.Combat); // Inicia combate
        }
        else
        {
            uiManager.UpdateUI("Espacio limitado. Modo tutorial activado.");
            gameStateManager.SetState(GameStateManager.GameState.Menu); // Vuelve al menú
        }
    }
}
