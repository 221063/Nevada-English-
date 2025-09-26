using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using TMPro;

public class PhoneticCombatTracker : MonoBehaviour
{
    public TMP_Text feedbackText; // Campo para mostrar retroalimentación
    private string apiUrl = "http://127.0.0.1:5000/analyze_emotion"; // URL del backend
    private float difficulty = 1.0f; // Dificultad inicial

    void Start()
    {
        if (feedbackText == null)
        {
            Debug.LogError("Asigna un TextMeshPro texto en el Inspector.");
        }
        StartCoroutine(CheckBiofeedback());
    }

    void Update()
    {
        // Simula entrada de pronunciación (reemplazar con micrófono real)
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SendPhoneticInput("excited", "combat");
        }
    }

    IEnumerator CheckBiofeedback()
    {
        while (true)
        {
            yield return new WaitForSeconds(2.0f); // Chequea cada 2 segundos
            StartCoroutine(GetBiofeedback());
        }
    }

    IEnumerator GetBiofeedback()
    {
        UnityWebRequest request = UnityWebRequest.Get(apiUrl);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            UpdateDifficulty(response);
        }
        else
        {
            Debug.LogError("Error al conectar con el backend: " + request.error);
        }
    }

    void SendPhoneticInput(string tone, string context)
    {
        StartCoroutine(PostPhoneticData(tone, context));
    }

    IEnumerator PostPhoneticData(string tone, string context)
    {
        WWWForm form = new WWWForm();
        form.AddField("tone", tone);
        form.AddField("context", context);

        UnityWebRequest request = UnityWebRequest.Post(apiUrl, form);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string response = request.downloadHandler.text;
            feedbackText.text = "Reacción: " + response;
        }
        else
        {
            Debug.LogError("Error al enviar datos: " + request.error);
        }
    }

    void UpdateDifficulty(string response)
    {
        // Simula ajuste de dificultad basado en biofeedback (reemplazar con lógica real)
        difficulty += 0.1f;
        feedbackText.text = "Dificultad: " + difficulty.ToString("F1");
    }
}
