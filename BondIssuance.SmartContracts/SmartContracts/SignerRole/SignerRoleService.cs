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
using SmartContracts.Contracts.SignerRole.ContractDefinition;

namespace SmartContracts.Contracts.SignerRole
{
    public partial class SignerRoleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, SignerRoleDeployment signerRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<SignerRoleDeployment>().SendRequestAndWaitForReceiptAsync(signerRoleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, SignerRoleDeployment signerRoleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<SignerRoleDeployment>().SendRequestAsync(signerRoleDeployment);
        }

        public static async Task<SignerRoleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, SignerRoleDeployment signerRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, signerRoleDeployment, cancellationTokenSource);
            return new SignerRoleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public SignerRoleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> IsSignerQueryAsync(IsSignerFunction isSignerFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsSignerFunction, bool>(isSignerFunction, blockParameter);
        }

        
        public Task<bool> IsSignerQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isSignerFunction = new IsSignerFunction();
                isSignerFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsSignerFunction, bool>(isSignerFunction, blockParameter);
        }

        public Task<string> AddSignerRequestAsync(AddSignerFunction addSignerFunction)
        {
             return ContractHandler.SendRequestAsync(addSignerFunction);
        }

        public Task<TransactionReceipt> AddSignerRequestAndWaitForReceiptAsync(AddSignerFunction addSignerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSignerFunction, cancellationToken);
        }

        public Task<string> AddSignerRequestAsync(string account)
        {
            var addSignerFunction = new AddSignerFunction();
                addSignerFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(addSignerFunction);
        }

        public Task<TransactionReceipt> AddSignerRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var addSignerFunction = new AddSignerFunction();
                addSignerFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addSignerFunction, cancellationToken);
        }

        public Task<string> RenounceSignerRequestAsync(RenounceSignerFunction renounceSignerFunction)
        {
             return ContractHandler.SendRequestAsync(renounceSignerFunction);
        }

        public Task<string> RenounceSignerRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceSignerFunction>();
        }

        public Task<TransactionReceipt> RenounceSignerRequestAndWaitForReceiptAsync(RenounceSignerFunction renounceSignerFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceSignerFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceSignerRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceSignerFunction>(null, cancellationToken);
        }
    }
}
