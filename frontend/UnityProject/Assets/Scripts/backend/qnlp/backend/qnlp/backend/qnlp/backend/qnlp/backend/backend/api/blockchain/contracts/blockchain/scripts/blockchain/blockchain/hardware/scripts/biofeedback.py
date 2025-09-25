import random
import time

class BiofeedbackSensor:
    def __init__(self):
        self.heart_rate = 70  # Simulación de frecuencia cardíaca inicial
        self.facial_expression = "neutral"

    def read_heart_rate(self):
        # Simula variación aleatoria en la frecuencia cardíaca
        self.heart_rate += random.uniform(-5, 5)
        return max(40, min(120, self.heart_rate))  # Rango realista

    def read_facial_expression(self):
        # Simula cambio aleatorio en la expresión facial
        expressions = ["happy", "sad", "angry", "neutral"]
        self.facial_expression = random.choice(expressions)
        return self.facial_expression

    def get_data(self):
        return {
            "timestamp": time.time(),
            "heart_rate": self.read_heart_rate(),
            "facial_expression": self.read_facial_expression()
        }

if __name__ == "__main__":
    sensor = BiofeedbackSensor()
    while True:
        data = sensor.get_data()
        print(f"Biofeedback Data: {data}")
        time.sleep(2)  # Actualiza cada 2 segundos
