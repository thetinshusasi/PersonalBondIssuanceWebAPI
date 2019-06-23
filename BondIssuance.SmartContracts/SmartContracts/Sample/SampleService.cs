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
using BondIssuanceContracts.Sample.ContractDefinition;

namespace BondIssuanceContracts.Sample
{
    public partial class SampleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SampleDeployment sampleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SampleDeployment>().SendRequestAndWaitForReceiptAsync(sampleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SampleDeployment sampleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SampleDeployment>().SendRequestAsync(sampleDeployment);
        }

        public static async Task<SampleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SampleDeployment sampleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, sampleDeployment, cancellationTokenSource);
            return new SampleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SampleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> SetValueForXRequestAsync(SetValueForXFunction setValueForXFunction)
        {
             return ContractHandler.SendRequestAsync(setValueForXFunction);
        }

        public Task<TransactionReceipt> SetValueForXRequestAndWaitForReceiptAsync(SetValueForXFunction setValueForXFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setValueForXFunction, cancellationToken);
        }

        public Task<string> SetValueForXRequestAsync(BigInteger x)
        {
            var setValueForXFunction = new SetValueForXFunction();
                setValueForXFunction.X = x;
            
             return ContractHandler.SendRequestAsync(setValueForXFunction);
        }

        public Task<TransactionReceipt> SetValueForXRequestAndWaitForReceiptAsync(BigInteger x, CancellationTokenSource cancellationToken = null)
        {
            var setValueForXFunction = new SetValueForXFunction();
                setValueForXFunction.X = x;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setValueForXFunction, cancellationToken);
        }

        public Task<BigInteger> GetValueForXQueryAsync(GetValueForXFunction getValueForXFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValueForXFunction, BigInteger>(getValueForXFunction, blockParameter);
        }

        
        public Task<BigInteger> GetValueForXQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetValueForXFunction, BigInteger>(null, blockParameter);
        }
    }
}
