using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts.ContractHandlers;
using Nethereum.Contracts;
using System.Threading;
using SmartContracts.Contracts.ERC165Checker.ContractDefinition;

namespace SmartContracts.Contracts.ERC165Checker
{
    public partial class ERC165CheckerService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ERC165CheckerDeployment eRC165CheckerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ERC165CheckerDeployment>().SendRequestAndWaitForReceiptAsync(eRC165CheckerDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ERC165CheckerDeployment eRC165CheckerDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ERC165CheckerDeployment>().SendRequestAsync(eRC165CheckerDeployment);
        }

        public static async Task<ERC165CheckerService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ERC165CheckerDeployment eRC165CheckerDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, eRC165CheckerDeployment, cancellationTokenSource);
            return new ERC165CheckerService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ERC165CheckerService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
