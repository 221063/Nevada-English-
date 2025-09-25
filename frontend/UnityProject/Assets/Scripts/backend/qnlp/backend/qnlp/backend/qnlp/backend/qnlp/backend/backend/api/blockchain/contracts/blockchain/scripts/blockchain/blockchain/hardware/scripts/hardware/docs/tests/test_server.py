import pytest
import requests
import json

# URL de la API (ajusta según tu entorno local)
API_URL = "http://127.0.0.1:5000/analyze_emotion"

def test_api_emotion_analysis():
    # Datos de prueba
    test_data = {
        "tone": "excited",
        "context": "restaurant order"
    }

    # Enviar solicitud POST
    response = requests.post(API_URL, json=test_data)

    # Verificar respuesta
    assert response.status_code == 200, "La API debería devolver 200 OK"
    result = response.json()
    assert "reaction" in result, "Debería incluir una reacción"
    assert "score" in result, "Debería incluir una puntuación"
    assert 0.0 <= result["score"] <= 1.0, "Puntuación fuera de rango [0, 1]"
    assert result["reaction"] in ["enthusiastic", "smile", "neutral", "ignore"], "Reacción inválida"

if __name__ == "__main__":
    pytest.main([__file__])
