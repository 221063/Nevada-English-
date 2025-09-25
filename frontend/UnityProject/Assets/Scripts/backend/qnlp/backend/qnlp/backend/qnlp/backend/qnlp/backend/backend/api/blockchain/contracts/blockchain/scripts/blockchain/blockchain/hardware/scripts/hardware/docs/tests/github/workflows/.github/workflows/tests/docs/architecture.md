# Arquitectura de Nevada-English

## Descripción General
Nevada-English es un videojuego educativo multidimensional que utiliza IA cuántica, AR (Realidad Aumentada), blockchain y hardware para enseñar inglés de forma inmersiva.

## Componentes Principales
1. **Frontend (Unity)**:
   - Ubicación: `frontend/UnityProject/`
   - Descripción: Incluye `PhoneticCombatTracker.cs` para el combate fonético basado en AR.
   - Integración: Recibe datos de biofeedback y responde a la API del backend.

2. **Backend (Python/Flask)**:
   - Ubicación: `backend/`
   - Descripción: Contiene `server.py` para la API y `qnlp/emotion_analyzer.py` para el análisis de emociones.
   - Integración: Procesa datos de biofeedback y envía respuestas al frontend.

3. **Blockchain (Solidity/Hardhat)**:
   - Ubicación: `blockchain/`
   - Descripción: Incluye `GrammarNFT.sol` para NFTs de logros y `deploy.js` para despliegue.
   - Integración: Registra logros gramaticales como NFTs.

4. **Hardware**:
   - Ubicación: `hardware/`
   - Descripción: `biofeedback.py` simula datos de frecuencia cardíaca y expresiones faciales.
   - Integración: Envía datos al backend para ajustar la experiencia.

## Flujo de Datos
1. El hardware (`biofeedback.py`) captura datos y los envía al backend (`server.py`).
2. El backend usa QNLP (`emotion_analyzer.py`) para analizar emociones y responde al frontend.
3. El frontend (`PhoneticCombatTracker.cs`) ajusta el juego según los datos y registra logros en blockchain (`GrammarNFT.sol`).

## Tecnologías
- Python (Flask, Qutip, Pytest)
- Unity (C#)
- Solidity (OpenZeppelin)
- Hardhat
- GitHub Actions (CI/CD)

## Notas
- La integración completa requiere pruebas adicionales.
- El hardware simulado será reemplazado por sensores reales en futuras iteraciones.
