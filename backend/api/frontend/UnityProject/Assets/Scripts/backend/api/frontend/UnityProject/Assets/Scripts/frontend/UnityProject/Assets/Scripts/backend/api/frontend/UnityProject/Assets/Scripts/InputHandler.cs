using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InputHandler : MonoBehaviour
{
    public GameManager gameManager;    // Referencia al GameManager
    public NetworkManager networkManager;  // Referencia al NetworkManager
    private AudioClip recordedClip;    // Clip de audio grabado
    private const int RECORDING_TIME = 2;  // Tiempo de grabación en segundos
    private bool isRecording = false;

    void Start()
    {
        if (gameManager == null || networkManager == null)
        {
            Debug.LogError("Asigna GameManager y NetworkManager en el Inspector.");
        }
    }

    void Update()
    {
        // Iniciar grabación y combate con tecla Space
        if (Input.GetKeyDown(KeyCode.Space) && !isRecording)
        {
            StartRecording();
        }

        // Terminar combate con tecla Escape
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            gameManager.EndCombat();
        }
    }

    private void StartRecording()
    {
        isRecording = true;
        string microphone = Microphone.devices[0]; // Usa el primer micrófono disponible
        recordedClip = Microphone.Start(microphone, false, RECORDING_TIME, 44100); // 44.1kHz
        Debug.Log("Grabando desde: " + microphone);

        // Espera la grabación y procesa
        StartCoroutine(StopRecordingAfterDelay());
    }

    private IEnumerator StopRecordingAfterDelay()
    {
        yield return new WaitForSeconds(RECORDING_TIME);
        Microphone.End(Microphone.devices[0]);
        isRecording = false;

        // Simula procesamiento y envía datos (puedes ajustar según backend)
        if (recordedClip != null)
        {
            gameManager.StartCombat();
            SendAudioToBackend(recordedClip);
        }
    }

    private void SendAudioToBackend(AudioClip clip)
    {
        // Convertir audio a formato enviable (simplificado)
        float[] samples = new float[clip.samples];
        clip.GetData(samples, 0);
        string audioData = System.Convert.ToBase64String(System.BitConverter.GetBytes(samples[0])); // Ejemplo básico

        // Enviar al backend (ajusta según necesidades reales)
        networkManager.SendPhoneticData(audioData, "combat");
        Debug.Log("Audio enviado al backend: " + audioData.Substring(0, 10) + "...");
    }
}
