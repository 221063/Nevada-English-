import pytest
from backend.qnlp.emotion_analyzer import quantumEmotionAnalyzer

def test_emotion_analyzer():
    # Prueba con tono "excited" y contexto "restaurant order"
    reaction, score = quantumEmotionAnalyzer("excited", "restaurant order")
    assert reaction in ["enthusiastic", "smile", "neutral", "ignore"], "Reacción inválida"
    assert 0.0 <= score <= 1.0, "Puntuación fuera de rango [0, 1]"

    # Prueba con tono "angry" y contexto "conversation"
    reaction, score = quantumEmotionAnalyzer("angry", "conversation")
    assert reaction in ["enthusiastic", "smile", "neutral", "ignore"], "Reacción inválida"
    assert 0.0 <= score <= 1.0, "Puntuación fuera de rango [0, 1]"

if __name__ == "__main__":
    pytest.main([__file__])
