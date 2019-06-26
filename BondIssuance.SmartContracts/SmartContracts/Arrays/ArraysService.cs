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
using SmartContracts.Contracts.Arrays.ContractDefinition;

namespace SmartContracts.Contracts.Arrays
{
    public partial class ArraysService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, ArraysDeployment arraysDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<ArraysDeployment>().SendRequestAndWaitForReceiptAsync(arraysDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, ArraysDeployment arraysDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<ArraysDeployment>().SendRequestAsync(arraysDeployment);
        }

        public static async Task<ArraysService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, ArraysDeployment arraysDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, arraysDeployment, cancellationTokenSource);
            return new ArraysService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public ArraysService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }


    }
}
