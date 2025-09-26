# Guía de Contribución - Nevada-English

## Bienvenida
¡Gracias por interesarte en contribuir a Nevada-English! Este proyecto combina IA cuántica, AR, blockchain y hardware para enseñar inglés de forma innovadora. Tu ayuda es valiosa para hacerlo crecer.
## Cómo Comenzar
1. **Clona el Repositorio**:
   ```bash
   git clone https://github.com/tu-usuario/Nevada-English.git
   cd Nevada-English
2. **Prepara tu computadora**:
   - Corre este comando para instalar todo lo necesario:
     ```bash
     ./setup.sh
     ```
   - Sigue los pasos en `docs/deployment.md` si necesitas ayuda extra para empezar el backend, blockchain o frontend.

3. **Descarga programas básicos**:
   - Necesitas: Python 3.9+ (para el backend), Node.js 16+ (para blockchain), Unity Editor (para el juego), y Git (para guardar cambios).
   - Si no los tienes, busca "descargar [nombre]" en tu navegador y sigue las instrucciones.
## Hacer Cambios
1. **Crea una Rama**:
   - Usa un nombre descriptivo, e.g., `feature/nueva-prueba` o `fix/bug-api`.
   ```bash
   git checkout -b feature/nueva-prueba
   2. **Cambia el código**:
   - Abre y edita los archivos en las carpetas que necesitas (por ejemplo, `backend/` para Python, `blockchain/` para contratos, `frontend/` para el juego, `hardware/` para sensores, o `tests/` para pruebas).
   - Prueba tu cambio para asegurarte de que funcione. Usa comandos simples como `pytest tests/` para probar Python, o `npx hardhat test` para blockchain.

3. **Guarda tus cambios**:
   - Usa este comando para guardar todo:
     ```bash
     git add .
     git commit -m "Añadí una nueva función [escribe qué cambiaste]"
     ```
     ## Enviar tus Cambios
1. **Sube lo que cambiaste**:
   - Usa este comando para enviar tus cambios:
     ```bash
     git push origin feature/nueva-prueba
     ```
   - Esto sube tu trabajo a GitHub.

2. **Pide que revisen tu trabajo**:
   - Ve a GitHub en tu celular o computadora.
   - Crea un "Pull Request" (PR) desde tu rama (`feature/nueva-prueba`) a `main`.
   - Escribe un mensaje corto diciendo qué cambiaste (e.g., "Añadí una nueva prueba").

3. **Espera comentarios**:
   - Alguien revisará tu trabajo y te dirá si necesita ajustes.
   - Si te piden cambios, hazlos y sube de nuevo.
## Consejos para Hacerlo Bien
- **Prueba tu trabajo**: Asegúrate de que todo funcione antes de enviar. Usa `pytest tests/` para Python o `npx hardhat test` para blockchain.
- **Actualiza la guía**: Si cambias algo importante (como el backend o el juego), añade notas en `docs/` (por ejemplo, `architecture.md`).
- **Escribe código limpio**: Sigue el estilo de los archivos que ya tienes (usa 4 espacios para Python, usa Solidity 0.8.0).
- **Revisa el automático**: Asegúrate de que `.github/workflows/ci.yml` apruebe tus cambios antes de enviar.
## Reportar Problemas
- Usa las Issues en GitHub para reportar bugs o sugerir mejoras.
- Incluye detalles como pasos para reproducir y logs de error.

## Licencia
- Este proyecto está bajo la licencia MIT. Consulta `LICENSE` (si existe) o crea uno si es necesario.

## Agradecimientos
¡Tu contribución hace que Nevada-English sea mejor! Si tienes dudas, consulta `docs/faq.md` o contacta al equipo via Issues.
