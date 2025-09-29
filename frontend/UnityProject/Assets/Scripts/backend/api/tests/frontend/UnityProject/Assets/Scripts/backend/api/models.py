class EmotionAnalysis:
    def __init__(self, tone, context, confidence=0.9):
        self.tone = tone  # e.g., "excited", "calm"
        self.context = context  # e.g., "combat", "lesson"
        self.confidence = confidence  # Nivel de certeza del análisis

    def to_dict(self):
        return {
            'tone': self.tone,
            'context': self.context,
            'confidence': self.confidence
        }

class FeedbackResponse:
    def __init__(self, feedback, success=True):
        self.feedback = feedback  # Mensaje de retroalimentación
        self.success = success  # Indicador de éxito

    def to_dict(self):
        return {
            'feedback': self.feedback,
            'success': self.success
        }
