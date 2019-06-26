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
using SmartContracts.Contracts.MinterRole.ContractDefinition;

namespace SmartContracts.Contracts.MinterRole
{
    public partial class MinterRoleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, MinterRoleDeployment minterRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<MinterRoleDeployment>().SendRequestAndWaitForReceiptAsync(minterRoleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, MinterRoleDeployment minterRoleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<MinterRoleDeployment>().SendRequestAsync(minterRoleDeployment);
        }

        public static async Task<MinterRoleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, MinterRoleDeployment minterRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, minterRoleDeployment, cancellationTokenSource);
            return new MinterRoleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public MinterRoleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> IsMinterQueryAsync(IsMinterFunction isMinterFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsMinterFunction, bool>(isMinterFunction, blockParameter);
        }

        
        public Task<bool> IsMinterQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isMinterFunction = new IsMinterFunction();
                isMinterFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsMinterFunction, bool>(isMinterFunction, blockParameter);
        }

        public Task<string> AddMinterRequestAsync(AddMinterFunction addMinterFunction)
        {
             return ContractHandler.SendRequestAsync(addMinterFunction);
        }

        public Task<TransactionReceipt> AddMinterRequestAndWaitForReceiptAsync(AddMinterFunction addMinterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addMinterFunction, cancellationToken);
        }

        public Task<string> AddMinterRequestAsync(string account)
        {
            var addMinterFunction = new AddMinterFunction();
                addMinterFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(addMinterFunction);
        }

        public Task<TransactionReceipt> AddMinterRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var addMinterFunction = new AddMinterFunction();
                addMinterFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addMinterFunction, cancellationToken);
        }

        public Task<string> RenounceMinterRequestAsync(RenounceMinterFunction renounceMinterFunction)
        {
             return ContractHandler.SendRequestAsync(renounceMinterFunction);
        }

        public Task<string> RenounceMinterRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenounceMinterFunction>();
        }

        public Task<TransactionReceipt> RenounceMinterRequestAndWaitForReceiptAsync(RenounceMinterFunction renounceMinterFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renounceMinterFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenounceMinterRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenounceMinterFunction>(null, cancellationToken);
        }
    }
}
