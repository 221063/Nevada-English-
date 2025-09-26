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
     
