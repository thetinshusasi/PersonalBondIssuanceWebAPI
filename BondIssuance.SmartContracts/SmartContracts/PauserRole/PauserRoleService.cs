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
using SmartContracts.Contracts.PauserRole.ContractDefinition;

namespace SmartContracts.Contracts.PauserRole
{
    public partial class PauserRoleService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PauserRoleDeployment pauserRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PauserRoleDeployment>().SendRequestAndWaitForReceiptAsync(pauserRoleDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PauserRoleDeployment pauserRoleDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PauserRoleDeployment>().SendRequestAsync(pauserRoleDeployment);
        }

        public static async Task<PauserRoleService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PauserRoleDeployment pauserRoleDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, pauserRoleDeployment, cancellationTokenSource);
            return new PauserRoleService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PauserRoleService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<bool> IsPauserQueryAsync(IsPauserFunction isPauserFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<IsPauserFunction, bool>(isPauserFunction, blockParameter);
        }

        
        public Task<bool> IsPauserQueryAsync(string account, BlockParameter blockParameter = null)
        {
            var isPauserFunction = new IsPauserFunction();
                isPauserFunction.Account = account;
            
            return ContractHandler.QueryAsync<IsPauserFunction, bool>(isPauserFunction, blockParameter);
        }

        public Task<string> AddPauserRequestAsync(AddPauserFunction addPauserFunction)
        {
             return ContractHandler.SendRequestAsync(addPauserFunction);
        }

        public Task<TransactionReceipt> AddPauserRequestAndWaitForReceiptAsync(AddPauserFunction addPauserFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPauserFunction, cancellationToken);
        }

        public Task<string> AddPauserRequestAsync(string account)
        {
            var addPauserFunction = new AddPauserFunction();
                addPauserFunction.Account = account;
            
             return ContractHandler.SendRequestAsync(addPauserFunction);
        }

        public Task<TransactionReceipt> AddPauserRequestAndWaitForReceiptAsync(string account, CancellationTokenSource cancellationToken = null)
        {
            var addPauserFunction = new AddPauserFunction();
                addPauserFunction.Account = account;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(addPauserFunction, cancellationToken);
        }

        public Task<string> RenouncePauserRequestAsync(RenouncePauserFunction renouncePauserFunction)
        {
             return ContractHandler.SendRequestAsync(renouncePauserFunction);
        }

        public Task<string> RenouncePauserRequestAsync()
        {
             return ContractHandler.SendRequestAsync<RenouncePauserFunction>();
        }

        public Task<TransactionReceipt> RenouncePauserRequestAndWaitForReceiptAsync(RenouncePauserFunction renouncePauserFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(renouncePauserFunction, cancellationToken);
        }

        public Task<TransactionReceipt> RenouncePauserRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<RenouncePauserFunction>(null, cancellationToken);
        }
    }
}
