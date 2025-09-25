# Preguntas Frecuentes (FAQ) - Nevada-English

## Instalación y Configuración
**¿Cómo clono y configuro el proyecto localmente?**
- Clona el repositorio con `git clone https://github.com/tu-usuario/Nevada-English.git`.
- Ejecuta `./setup.sh` para instalar dependencias.
- Sigue las instrucciones en `docs/deployment.md` para configurar el backend, blockchain y frontend.

**¿Qué hago si falta una dependencia?**
- Revisa `backend/requirements.txt` y `blockchain/package.json` para las dependencias necesarias.
- Instala manualmente con `pip install <paquete>` o `npm install`.

## Uso
**¿Cómo inicio el servidor backend?**
- Navega a `backend/api/` y ejecuta `python server.py`. La API estará en `http://127.0.0.1:5000`.

**¿Cómo pruebo el contrato blockchain?**
- Inicia una red local con `npx hardhat node` en `blockchain/`.
- Despliega el contrato con `npx hardhat run scripts/deploy.js --network localhost`.

## Desarrollo
**¿Cómo agrego nuevas pruebas?**
- Crea un archivo en `tests/` (e.g., `test_newfeature.py`) y usa `pytest` para escribir pruebas.
- Actualiza `.github/workflows/ci.yml` para incluirlas.

**¿Cómo integro hardware real?**
- Reemplaza la simulación en `hardware/scripts/biofeedback.py` con datos de sensores (e.g., Muse EEG).
- Ajusta `server.py` para procesar los nuevos datos.

## Problemas Comunes
**¿Por qué falla la compilación de Solidity?**
- Asegúrate de que `hardhat.config.js` use la versión correcta de Solidity (`0.8.0`).
- Ejecuta `npx hardhat compile` para regenerar artifacts.

**¿Qué hago si las pruebas no corren?**
- Verifica que todas las dependencias estén instaladas.
- Asegúrate de que el servidor o la red Hardhat estén activos.

## Contribuciones
**¿Cómo puedo contribuir?**
- Haz un fork del repositorio, crea una rama, y envía un pull request.
- Sigue las guías en `docs/architecture.md` y `docs/deployment.md`.

**¿Dónde reporto errores?**
- Usa las Issues en GitHub para reportar bugs o sugerencias.
