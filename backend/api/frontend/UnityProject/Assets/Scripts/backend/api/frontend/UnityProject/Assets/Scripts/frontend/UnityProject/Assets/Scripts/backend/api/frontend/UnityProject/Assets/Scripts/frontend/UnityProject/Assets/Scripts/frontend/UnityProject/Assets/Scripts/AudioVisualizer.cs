using UnityEngine;

public class AudioVisualizer : MonoBehaviour
{
    public RectTransform bar;  // Referencia a un RectTransform (e.g., una barra UI)
    public float maxHeight = 200f;  // Altura máxima de la barra
    private VoiceProcessor voiceProcessor;  // Referencia al VoiceProcessor

    void Start()
    {
        if (bar == null)
        {
            Debug.LogError("Asigna un RectTransform (barra UI) en el Inspector.");
        }
        voiceProcessor = GetComponent<VoiceProcessor>(); // Asume que está en el mismo objeto
        if (voiceProcessor == null)
        {
            Debug.LogError("Asigna VoiceProcessor o añádelo al mismo objeto.");
        }
    }

    public void VisualizeAudio(AudioClip clip)
    {
        if (clip != null)
        {
            float amplitude = voiceProcessor.GetAmplitude(clip);
            float barHeight = amplitude * maxHeight; // Escala la amplitud a la altura
            bar.sizeDelta = new Vector2(bar.sizeDelta.x, Mathf.Clamp(barHeight, 0, maxHeight));
        }
    }
}
