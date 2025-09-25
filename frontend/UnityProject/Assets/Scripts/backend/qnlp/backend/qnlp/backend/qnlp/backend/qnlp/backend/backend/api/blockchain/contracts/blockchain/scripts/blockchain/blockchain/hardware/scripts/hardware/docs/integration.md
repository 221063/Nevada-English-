# Integración del Hardware en Nevada-English

## Descripción
Este documento detalla la integración del módulo de hardware, que captura datos de biofeedback (frecuencia cardíaca y expresiones faciales) para mejorar la experiencia de aprendizaje en Nevada-English.

## Requisitos
- Script: `hardware/scripts/biofeedback.py`
- Backend: `backend/api/server.py` para recibir datos
- Frontend: `frontend/UnityProject/Assets/Scripts/PhoneticCombatTracker.cs` para procesar datos

## Pasos de Integración
1. **Ejecutar el Sensor**:
   - Corre `biofeedback.py` en un entorno Python.
   - Esto genera datos simulados (frecuencia cardíaca y expresiones faciales) cada 2 segundos.

2. **Conectar con la API**:
   - Modifica `server.py` para aceptar datos de `biofeedback.py` (pendiente de implementación).
   - Usa una solicitud POST a `/analyze_emotion` con los datos de biofeedback.

3. **Integrar en Unity**:
   - Actualiza `PhoneticCombatTracker.cs` para recibir datos de la API y ajustar el combate fonético.

## Notas
- Actualmente, `biofeedback.py` simula datos. Para hardware real, necesitarás conectar sensores (e.g., Muse EEG) y ajustar el código.
- Pruebas pendientes en un entorno con PC.

## Próximos Pasos
- Implementar la comunicación entre `biofeedback.py` y `server.py`.
- Probar integración completa en Unity.
