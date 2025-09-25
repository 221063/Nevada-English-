# Despliegue de Nevada-English

## Descripción General
Este documento detalla los pasos para desplegar Nevada-English localmente o en un entorno de producción, incluyendo el backend, el frontend y la blockchain.

## Requisitos Previos
- Python 3.9+
- Node.js 16+
- Unity Editor (para el frontend)
- Hardhat (para blockchain)
- Git

- ## Despliegue Local

### 1. Clonar el Repositorio
```bash
git clone https://github.com/tu-usuario/Nevada-English.git
cd Nevada-English

### 2. Configurar el Backend
- Instala dependencias:
  ```bash
  ./setup.sh
cd backend/api
python server.py
### 3. Configurar la Blockchain
- Inicia una red local Hardhat:
  ```bash
  cd blockchain
  npx hardhat node
npx hardhat run scripts/deploy.js --network localhost
### 4. Configurar el Frontend (Unity)
- Abre `frontend/UnityProject/` en Unity Editor.
- Ajusta la URL de la API en `PhoneticCombatTracker.cs` si es necesario.
- Construye y ejecuta el proyecto.

### 5. Ejecutar el Hardware
- Inicia el script de biofeedback:
  ```bash
  cd hardware/scripts
  python biofeedback.py

