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
using SmartContracts.Contracts.Pausable.ContractDefinition;

namespace SmartContracts.Contracts.Pausable
{
    public partial class PausableService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, PausableDeployment pausableDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<PausableDeployment>().SendRequestAndWaitForReceiptAsync(pausableDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, PausableDeployment pausableDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<PausableDeployment>().SendRequestAsync(pausableDeployment);
        }

        public static async Task<PausableService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, PausableDeployment pausableDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, pausableDeployment, cancellationTokenSource);
            return new PausableService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public PausableService(Nethereum.Web3.Web3 web3, string contractAddress)
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

        public Task<bool> PausedQueryAsync(PausedFunction pausedFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PausedFunction, bool>(pausedFunction, blockParameter);
        }

        
        public Task<bool> PausedQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<PausedFunction, bool>(null, blockParameter);
        }

        public Task<string> PauseRequestAsync(PauseFunction pauseFunction)
        {
             return ContractHandler.SendRequestAsync(pauseFunction);
        }

        public Task<string> PauseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<PauseFunction>();
        }

        public Task<TransactionReceipt> PauseRequestAndWaitForReceiptAsync(PauseFunction pauseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(pauseFunction, cancellationToken);
        }

        public Task<TransactionReceipt> PauseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<PauseFunction>(null, cancellationToken);
        }

        public Task<string> UnpauseRequestAsync(UnpauseFunction unpauseFunction)
        {
             return ContractHandler.SendRequestAsync(unpauseFunction);
        }

        public Task<string> UnpauseRequestAsync()
        {
             return ContractHandler.SendRequestAsync<UnpauseFunction>();
        }

        public Task<TransactionReceipt> UnpauseRequestAndWaitForReceiptAsync(UnpauseFunction unpauseFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(unpauseFunction, cancellationToken);
        }

        public Task<TransactionReceipt> UnpauseRequestAndWaitForReceiptAsync(CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync<UnpauseFunction>(null, cancellationToken);
        }
    }
}
