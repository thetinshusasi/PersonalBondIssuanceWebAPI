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
using SmartContracts.Contracts.WhitelistedRole.ContractDefinition;

namespace SmartContracts.Contracts.WhitelistedRole
{
    public partial class WhitelistedRoleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, WhitelistedRoleDeployment whitelistedRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<WhitelistedRoleDeployment>().SendRequestAndWaitForReceiptAsync(whitelistedRoleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, WhitelistedRoleDeployment whitelistedRoleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<WhitelistedRoleDeployment>().SendRequestAsync(whitelistedRoleDeployment);
        }

        public static async Task<WhitelistedRoleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, WhitelistedRoleDeployment whitelistedRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, whitelistedRoleDeployment, cancellationTokenSource);
            return new WhitelistedRoleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public WhitelistedRoleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
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

        public Task<bool> IsWhitelistedQueryAsync(IsWhitelistedFunction isWhitelistedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsWhitelistedFunction, bool>(isWhitelistedFunction, blockParameter);
        }

        
        public Task<bool> IsWhitelistedQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isWhitelistedFunction = new IsWhitelistedFunction();
                isWhitelistedFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsWhitelistedFunction, bool>(isWhitelistedFunction, blockParameter);
        }

        public Task<string> AddWhitelistedRequestAsync(AddWhitelistedFunction addWhitelistedFunction)
        {
             return ContractHandler.SendRequestAsync(addWhitelistedFunction);
        }

        public Task<TransactionReceipt> AddWhitelistedRequestAndWaitForReceiptAsync(AddWhitelistedFunction addWhitelistedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addWhitelistedFunction, cancellationToken);
        }

        public Task<string> AddWhitelistedRequestAsync(string account)
        {
            var addWhitelistedFunction = new AddWhitelistedFunction();
                addWhitelistedFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(addWhitelistedFunction);
        }

        public Task<TransactionReceipt> AddWhitelistedRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var addWhitelistedFunction = new AddWhitelistedFunction();
                addWhitelistedFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addWhitelistedFunction, cancellationToken);
        }

        public Task<string> RemoveWhitelistedRequestAsync(RemoveWhitelistedFunction removeWhitelistedFunction)
        {
             return ContractHandler.SendRequestAsync(removeWhitelistedFunction);
        }

        public Task<TransactionReceipt> RemoveWhitelistedRequestAndWaitForReceiptAsync(RemoveWhitelistedFunction removeWhitelistedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeWhitelistedFunction, cancellationToken);
        }

        public Task<string> RemoveWhitelistedRequestAsync(string account)
        {
            var removeWhitelistedFunction = new RemoveWhitelistedFunction();
                removeWhitelistedFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(removeWhitelistedFunction);
        }

        public Task<TransactionReceipt> RemoveWhitelistedRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var removeWhitelistedFunction = new RemoveWhitelistedFunction();
                removeWhitelistedFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(removeWhitelistedFunction, cancellationToken);
        }

        public Task<string> RenounceWhitelistedRequestAsync(RenounceWhitelistedFunction renounceWhitelistedFunction)
        {
             return ContractHandler.SendRequestAsync(renounceWhitelistedFunction);
        }

        public Task<string> RenounceWhitelistedRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceWhitelistedFunction>();
        }

        public Task<TransactionReceipt> RenounceWhitelistedRequestAndWaitForReceiptAsync(RenounceWhitelistedFunction renounceWhitelistedFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceWhitelistedFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceWhitelistedRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceWhitelistedFunction>(null, cancellationToken);
        }
    }
}
