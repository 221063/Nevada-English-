#!/bin/bash

echo "Configurando Nevada-English..."

# Instalar dependencias de Python
echo "Instalando dependencias de Python..."
cd backend || exit
pip install -r requirements.txt
cd ..

# Instalar dependencias de blockchain
echo "Instalando dependencias de blockchain..."
cd blockchain || exit
npm install
cd ..

# Compilar contratos Solidity
echo "Compilando contratos Solidity..."
cd blockchain || exit
npx hardhat compile
cd ..

echo "Configuración completada. ¡Listo para desarrollar!"
