using UnityEngine;

public class CombatController : MonoBehaviour
{
    public InputHandler inputHandler;    // Referencia al InputHandler
    public VoiceProcessor voiceProcessor; // Referencia al VoiceProcessor
    public PlayerFeedback playerFeedback; // Referencia al PlayerFeedback

    void Start()
    {
        if (inputHandler == null || voiceProcessor == null || playerFeedback == null)
        {
            Debug.LogError("Asigna InputHandler, VoiceProcessor y PlayerFeedback en el Inspector.");
        }
    }

    public void StartCombatSequence()
    {
        // Inicia la grabación a través de InputHandler
        inputHandler.StartRecording();
    }

    public void ProcessCombatResult(AudioClip clip)
    {
        // Procesa el audio y da retroalimentación
        if (clip != null)
        {
            float amplitude = voiceProcessor.GetAmplitude(clip);
            string tone = voiceProcessor.AnalyzeTone(amplitude);
            playerFeedback.ProvideFeedback(tone);
        }
    }
}
