import unittest
from backend.api.models import EmotionAnalysis, FeedbackResponse

class TestModels(unittest.TestCase):
    def test_emotion_analysis(self):
        emotion = EmotionAnalysis(tone="happy", context="lesson", confidence=0.95)
        self.assertEqual(emotion.tone, "happy")
        self.assertEqual(emotion.context, "lesson")
        self.assertEqual(emotion.confidence, 0.95)
        self.assertEqual(emotion.to_dict(), {
            'tone': 'happy',
            'context': 'lesson',
            'confidence': 0.95
        })

    def test_feedback_response(self):
        feedback = FeedbackResponse(feedback="Buen trabajo", success=False)
        self.assertEqual(feedback.feedback, "Buen trabajo")
        self.assertFalse(feedback.success)
        self.assertEqual(feedback.to_dict(), {
            'feedback': 'Buen trabajo',
            'success': False
        })

if __name__ == '__main__':
    unittest.main()
