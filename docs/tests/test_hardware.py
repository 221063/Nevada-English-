import pytest
import importlib.util
import sys

# Cargar dinámicamente biofeedback.py para pruebas
spec = importlib.util.spec_from_file_location("biofeedback", "hardware/scripts/biofeedback.py")
biofeedback_module = importlib.util.module_from_spec(spec)
sys.modules["biofeedback"] = biofeedback_module
spec.loader.exec_module(biofeedback_module)

def test_biofeedback_data():
    sensor = biofeedback_module.BiofeedbackSensor()
    data = sensor.get_data()

    # Verificar que los datos tengan las claves esperadas
    assert "timestamp" in data, "Falta timestamp en los datos"
    assert "heart_rate" in data, "Falta heart_rate en los datos"
    assert "facial_expression" in data, "Falta facial_expression en los datos"

    # Verificar rangos realistas
    assert 40 <= data["heart_rate"] <= 120, "Frecuencia cardíaca fuera del rango [40, 120]"
    assert data["facial_expression"] in ["happy", "sad", "angry", "neutral"], "Expresión facial inválida"

if __name__ == "__main__":
    pytest.main([__file__])
