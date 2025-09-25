const hre = require("hardhat");

async function main() {
  const GrammarNFT = await hre.ethers.getContractFactory("GrammarNFT");
  const grammarNFT = await GrammarNFT.deploy();
  await grammarNFT.deployed();
  console.log("GrammarNFT deployed to:", grammarNFT.address);
}

main().catch((error) => {
  console.error(error);
  process.exitCode = 1;
});
