import pytest
from web3 import Web3
import os
import json

# Conectar a la red local de Hardhat
w3 = Web3(Web3.HTTPProvider("http://127.0.0.1:8545"))
assert w3.is_connected(), "No se pudo conectar a la red Hardhat"

# Cargar el contrato desplegado (ajusta la ruta según tu entorno)
with open("blockchain/artifacts/contracts/GrammarNFT.sol/GrammarNFT.json") as f:
    contract_json = json.load(f)
contract_address = "0x..."  # Reemplaza con la dirección real después de desplegar
abi = contract_json["abi"]
contract = w3.eth.contract(address=contract_address, abi=abi)

def test_nft_deployment():
    # Verificar que el contrato esté desplegado
    assert contract.functions.name().call() == "GrammarNFT", "Nombre del contrato incorrecto"
    assert contract.functions.symbol().call() == "GNFT", "Símbolo del contrato incorrecto"

def test_award_nft():
    # Simular acuñar un NFT (requiere cuenta y transacción)
    account = w3.eth.accounts[0]  # Usa la primera cuenta de Hardhat
    token_uri = "https://example.com/nft/1"
    tx = contract.functions.awardGrammarNFT(account, token_uri).build_transaction({
        "from": account,
        "nonce": w3.eth.get_transaction_count(account),
        "gas": 2000000,
        "gasPrice": w3.to_wei("50", "gwei")
    })
    signed_tx = w3.eth.account.sign_transaction(tx, os.getenv("PRIVATE_KEY", "0x..."))  # Ajusta la clave privada
    tx_hash = w3.eth.send_raw_transaction(signed_tx.raw_transaction)
    tx_receipt = w3.eth.wait_for_transaction_receipt(tx_hash)
    assert tx_receipt.status == 1, "Transacción fallida"
    assert contract.functions.balanceOf(account).call() == 1, "NFT no acuñado correctamente"

if __name__ == "__main__":
    pytest.main([__file__])
