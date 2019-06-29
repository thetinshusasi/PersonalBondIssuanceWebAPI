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
using SmartContracts.Contracts.Hello.ContractDefinition;

namespace SmartContracts.Contracts.Hello
{
    public partial class HelloService
    {
        public static Task<TransactionReceipt> DeployContractAndWaitForReceiptAsync(Nethereum.Web3.Web3 web3, HelloDeployment helloDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            return web3.Eth.GetContractDeploymentHandler<HelloDeployment>().SendRequestAndWaitForReceiptAsync(helloDeployment, cancellationTokenSource);
        }

        public static Task<string> DeployContractAsync(Nethereum.Web3.Web3 web3, HelloDeployment helloDeployment)
        {
            return web3.Eth.GetContractDeploymentHandler<HelloDeployment>().SendRequestAsync(helloDeployment);
        }

        public static async Task<HelloService> DeployContractAndGetServiceAsync(Nethereum.Web3.Web3 web3, HelloDeployment helloDeployment, CancellationTokenSource cancellationTokenSource = null)
        {
            var receipt = await DeployContractAndWaitForReceiptAsync(web3, helloDeployment, cancellationTokenSource);
            return new HelloService(web3, receipt.ContractAddress);
        }

        protected Nethereum.Web3.Web3 Web3{ get; }

        public ContractHandler ContractHandler { get; }

        public HelloService(Nethereum.Web3.Web3 web3, string contractAddress)
        {
            Web3 = web3;
            ContractHandler = web3.Eth.GetContractHandler(contractAddress);
        }

        public Task<string> SetMessageRequestAsync(SetMessageFunction setMessageFunction)
        {
             return ContractHandler.SendRequestAsync(setMessageFunction);
        }

        public Task<TransactionReceipt> SetMessageRequestAndWaitForReceiptAsync(SetMessageFunction setMessageFunction, CancellationTokenSource cancellationToken = null)
        {
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMessageFunction, cancellationToken);
        }

        public Task<string> SetMessageRequestAsync(string newMessage)
        {
            var setMessageFunction = new SetMessageFunction();
                setMessageFunction.NewMessage = newMessage;
            
             return ContractHandler.SendRequestAsync(setMessageFunction);
        }

        public Task<TransactionReceipt> SetMessageRequestAndWaitForReceiptAsync(string newMessage, CancellationTokenSource cancellationToken = null)
        {
            var setMessageFunction = new SetMessageFunction();
                setMessageFunction.NewMessage = newMessage;
            
             return ContractHandler.SendRequestAndWaitForReceiptAsync(setMessageFunction, cancellationToken);
        }

        public Task<string> GetMessageQueryAsync(GetMessageFunction getMessageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMessageFunction, string>(getMessageFunction, blockParameter);
        }

        
        public Task<string> GetMessageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<GetMessageFunction, string>(null, blockParameter);
        }

        public Task<string> MessageQueryAsync(MessageFunction messageFunction, BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessageFunction, string>(messageFunction, blockParameter);
        }

        
        public Task<string> MessageQueryAsync(BlockParameter blockParameter = null)
        {
            return ContractHandler.QueryAsync<MessageFunction, string>(null, blockParameter);
        }
    }
}
