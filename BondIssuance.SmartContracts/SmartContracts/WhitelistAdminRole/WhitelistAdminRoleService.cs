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
using SmartContracts.Contracts.WhitelistAdminRole.ContractDefinition;

namespace SmartContracts.Contracts.WhitelistAdminRole
{
    public partial class WhitelistAdminRoleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, WhitelistAdminRoleDeployment whitelistAdminRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<WhitelistAdminRoleDeployment>().SendRequestAndWaitForReceiptAsync(whitelistAdminRoleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, WhitelistAdminRoleDeployment whitelistAdminRoleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<WhitelistAdminRoleDeployment>().SendRequestAsync(whitelistAdminRoleDeployment);
        }

        public static async Task<WhitelistAdminRoleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, WhitelistAdminRoleDeployment whitelistAdminRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, whitelistAdminRoleDeployment, cancellationTokenSource);
            return new WhitelistAdminRoleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public WhitelistAdminRoleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> IsWhitelistAdminQueryAsync(IsWhitelistAdminFunction isWhitelistAdminFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsWhitelistAdminFunction, bool>(isWhitelistAdminFunction, blockParameter);
        }

        
        public Task<bool> IsWhitelistAdminQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isWhitelistAdminFunction = new IsWhitelistAdminFunction();
                isWhitelistAdminFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsWhitelistAdminFunction, bool>(isWhitelistAdminFunction, blockParameter);
        }

        public Task<string> AddWhitelistAdminRequestAsync(AddWhitelistAdminFunction addWhitelistAdminFunction)
        {
             return ContractHandler.SendRequestAsync(addWhitelistAdminFunction);
        }

        public Task<TransactionReceipt> AddWhitelistAdminRequestAndWaitForReceiptAsync(AddWhitelistAdminFunction addWhitelistAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addWhitelistAdminFunction, cancellationToken);
        }

        public Task<string> AddWhitelistAdminRequestAsync(string account)
        {
            var addWhitelistAdminFunction = new AddWhitelistAdminFunction();
                addWhitelistAdminFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(addWhitelistAdminFunction);
        }

        public Task<TransactionReceipt> AddWhitelistAdminRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var addWhitelistAdminFunction = new AddWhitelistAdminFunction();
                addWhitelistAdminFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addWhitelistAdminFunction, cancellationToken);
        }

        public Task<string> RenounceWhitelistAdminRequestAsync(RenounceWhitelistAdminFunction renounceWhitelistAdminFunction)
        {
             return ContractHandler.SendRequestAsync(renounceWhitelistAdminFunction);
        }

        public Task<string> RenounceWhitelistAdminRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceWhitelistAdminFunction>();
        }

        public Task<TransactionReceipt> RenounceWhitelistAdminRequestAndWaitForReceiptAsync(RenounceWhitelistAdminFunction renounceWhitelistAdminFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceWhitelistAdminFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceWhitelistAdminRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceWhitelistAdminFunction>(null, cancellationToken);
        }
    }
}
