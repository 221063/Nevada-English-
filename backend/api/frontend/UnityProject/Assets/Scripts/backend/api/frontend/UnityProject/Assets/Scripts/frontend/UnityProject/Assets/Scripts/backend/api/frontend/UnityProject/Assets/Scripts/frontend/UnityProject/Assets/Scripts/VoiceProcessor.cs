using UnityEngine;

public class VoiceProcessor : MonoBehaviour
{
    public float GetAmplitude(AudioClip clip)
    {
        float[] samples = new float[clip.samples];
        clip.GetData(samples, 0);
        float sum = 0f;
        for (int i = 0; i < samples.Length; i++)
        {
            sum += Mathf.Abs(samples[i]);
        }
        return sum / samples.Length; // Amplitud promedio como métrica simple
    }

    public string AnalyzeTone(float amplitude)
    {
        // Lógica básica: amplitud alta = "excited", baja = "calm"
        if (amplitude > 0.1f)
        {
            return "excited";
        }
        return "calm";
    }
}
