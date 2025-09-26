using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;

public class ARManager : MonoBehaviour
{
    private ARRaycastManager arRaycastManager;
    private ARPlaneManager arPlaneManager;
    public GameObject combatTargetPrefab; // Prefab del objetivo del combate

    void Awake()
    {
        arRaycastManager = GetComponent<ARRaycastManager>();
        arPlaneManager = GetComponent<ARPlaneManager>();
        arPlaneManager.enabled = true;
    }

    void Update()
    {
        // Detecta superficies y coloca un objetivo al tocar la pantalla
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            List<ARRaycastHit> hits = new List<ARRaycastHit>();
            if (arRaycastManager.Raycast(Input.GetTouch(0).position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                Instantiate(combatTargetPrefab, hitPose.position, Quaternion.identity);
            }
        }
    }

    void OnEnable()
    {
        arPlaneManager.planesChanged += OnPlanesChanged;
    }

    void OnDisable()
    {
        arPlaneManager.planesChanged -= OnPlanesChanged;
    }

    void OnPlanesChanged(ARPlanesChangedEventArgs args)
    {
        // Actualiza planos detectados (puedes expandir esto)
        foreach (var plane in args.added)
        {
            plane.gameObject.SetActive(true);
        }
    }
}
