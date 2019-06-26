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
using SmartContracts.Contracts.TokenTimelock.ContractDefinition;

namespace SmartContracts.Contracts.TokenTimelock
{
    public partial class TokenTimelockService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, TokenTimelockDeployment tokenTimelockDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<TokenTimelockDeployment>().SendRequestAndWaitForReceiptAsync(tokenTimelockDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, TokenTimelockDeployment tokenTimelockDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<TokenTimelockDeployment>().SendRequestAsync(tokenTimelockDeployment);
        }

        public static async Task<TokenTimelockService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, TokenTimelockDeployment tokenTimelockDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, tokenTimelockDeployment, cancellationTokenSource);
            return new TokenTimelockService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public TokenTimelockService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> TokenQueryAsync(TokenFunction tokenFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenFunction, string>(tokenFunction, blockParameter);
        }

        
        public Task<string> TokenQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<TokenFunction, string>(null, blockParameter);
        }

        public Task<string> BeneficiaryQueryAsync(BeneficiaryFunction beneficiaryFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BeneficiaryFunction, string>(beneficiaryFunction, blockParameter);
        }

        
        public Task<string> BeneficiaryQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<BeneficiaryFunction, string>(null, blockParameter);
        }

        public Task<BigInteger> ReleaseTimeQueryAsync(ReleaseTimeFunction releaseTimeFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseTimeFunction, BigInteger>(releaseTimeFunction, blockParameter);
        }

        
        public Task<BigInteger> ReleaseTimeQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<ReleaseTimeFunction, BigInteger>(null, blockParameter);
        }

        public Task<string> ReleaseRequestAsync(ReleaseFunction releaseFunction)
        {
             return ContractHandler.SendRequestAsync(releaseFunction);
        }

        public Task<string> ReleaseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<ReleaseFunction>();
        }

        public Task<TransactionReceipt> ReleaseRequestAndWaitForReceiptAsync(ReleaseFunction releaseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(releaseFunction, cancellationToken);
        }

        public Task<TransactionReceipt> ReleaseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<ReleaseFunction>(null, cancellationToken);
        }
    }
}
