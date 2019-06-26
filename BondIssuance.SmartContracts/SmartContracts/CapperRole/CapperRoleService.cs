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
using SmartContracts.Contracts.CapperRole.ContractDefinition;

namespace SmartContracts.Contracts.CapperRole
{
    public partial class CapperRoleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, CapperRoleDeployment capperRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<CapperRoleDeployment>().SendRequestAndWaitForReceiptAsync(capperRoleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, CapperRoleDeployment capperRoleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<CapperRoleDeployment>().SendRequestAsync(capperRoleDeployment);
        }

        public static async Task<CapperRoleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, CapperRoleDeployment capperRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, capperRoleDeployment, cancellationTokenSource);
            return new CapperRoleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public CapperRoleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> IsCapperQueryAsync(IsCapperFunction isCapperFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsCapperFunction, bool>(isCapperFunction, blockParameter);
        }

        
        public Task<bool> IsCapperQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isCapperFunction = new IsCapperFunction();
                isCapperFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsCapperFunction, bool>(isCapperFunction, blockParameter);
        }

        public Task<string> AddCapperRequestAsync(AddCapperFunction addCapperFunction)
        {
             return ContractHandler.SendRequestAsync(addCapperFunction);
        }

        public Task<TransactionReceipt> AddCapperRequestAndWaitForReceiptAsync(AddCapperFunction addCapperFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addCapperFunction, cancellationToken);
        }

        public Task<string> AddCapperRequestAsync(string account)
        {
            var addCapperFunction = new AddCapperFunction();
                addCapperFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(addCapperFunction);
        }

        public Task<TransactionReceipt> AddCapperRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var addCapperFunction = new AddCapperFunction();
                addCapperFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addCapperFunction, cancellationToken);
        }

        public Task<string> RenounceCapperRequestAsync(RenounceCapperFunction renounceCapperFunction)
        {
             return ContractHandler.SendRequestAsync(renounceCapperFunction);
        }

        public Task<string> RenounceCapperRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceCapperFunction>();
        }

        public Task<TransactionReceipt> RenounceCapperRequestAndWaitForReceiptAsync(RenounceCapperFunction renounceCapperFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceCapperFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceCapperRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceCapperFunction>(null, cancellationToken);
        }
    }
}
