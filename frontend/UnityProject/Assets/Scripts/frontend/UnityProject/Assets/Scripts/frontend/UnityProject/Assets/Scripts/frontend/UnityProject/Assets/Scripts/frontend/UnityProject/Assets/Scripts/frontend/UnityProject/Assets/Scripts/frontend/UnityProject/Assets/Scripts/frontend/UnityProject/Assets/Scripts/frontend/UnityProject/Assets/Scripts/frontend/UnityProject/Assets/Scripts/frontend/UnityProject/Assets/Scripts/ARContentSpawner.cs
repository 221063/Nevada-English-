using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class ARContentSpawner : MonoBehaviour
{
    public ARRaycastManager arRaycastManager; // Referencia al ARRaycastManager
    public LessonManager lessonManager;      // Referencia al LessonManager
    public GameObject wordPrefab;            // Prefab a instanciar (e.g., texto 3D)

    void Start()
    {
        if (arRaycastManager == null || lessonManager == null || wordPrefab == null)
        {
            Debug.LogError("Asigna ARRaycastManager, LessonManager y wordPrefab en el Inspector.");
        }
    }

    public void SpawnContent()
    {
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        List<ARRaycastHit> hits = new List<ARRaycastHit>();
        if (arRaycastManager.Raycast(screenCenter, hits, UnityEngine.XR.ARSubsystems.TrackableType.PlaneWithinPolygon))
        {
            Pose hitPose = hits[0].pose;
            GameObject spawnedObject = Instantiate(wordPrefab, hitPose.position, hitPose.rotation);
            spawnedObject.GetComponent<TextMesh>().text = lessonManager.GetCurrentLesson(); // Asume TextMesh
            Debug.Log("Contenido AR spawnado: " + lessonManager.GetCurrentLesson());
        }
        else
        {
            Debug.Log("No se detectó superficie para spawn.");
        }
    }
}
