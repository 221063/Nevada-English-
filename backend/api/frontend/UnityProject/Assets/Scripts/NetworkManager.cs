using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class NetworkManager : MonoBehaviour
{
    private const string BASE_URL = "http://127.0.0.1:5000";

    public void SendPhoneticData(string tone, string context)
    {
        StartCoroutine(PostRequest(tone, context));
    }

    private IEnumerator PostRequest(string tone, string context)
    {
        WWWForm form = new WWWForm();
        form.AddField("tone", tone);
        form.AddField("context", context);

        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + "/analyze_emotion", form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                string response = www.downloadHandler.text;
                Debug.Log("Respuesta del servidor: " + response);
            }
            else
            {
                Debug.LogError("Error: " + www.error);
            }
        }
    }
}
