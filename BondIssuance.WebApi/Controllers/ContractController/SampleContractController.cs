using BondIssuance.DLL.DataModels;
using BondIssuance.DLL.IRepositories;
using BondIssuanceContracts.Sample;
using BondIssuanceContracts.Sample.ContractDefinition;
using Nethereum.Contracts;
using Nethereum.JsonRpc.Client;
using Nethereum.Quorum;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Swashbuckle.Swagger.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Nethereum.Geth;
using System.Threading;
using Nethereum.Web3.Accounts.Managed;
using Nethereum.Web3.Accounts;
using System.Numerics;
using Nethereum.ABI.FunctionEncoding.Attributes;

namespace BondIssuance.WebApi.Controllers.ContractController
{
    [Event("Transfer")]
    public class TransferEventDto : IEventDTO
    {
        [Parameter("address", "_from", 1, true)]
        public string From { get; set; }

        [Parameter("address", "_to", 2, true)]
        public string To { get; set; }

        [Parameter("uint256", "_value", 3, false)]
        public BigInteger Value { get; set; }
    }

    [RoutePrefix("api/SampleContract")]
    public class SampleContractController : ApiController
    {
        private readonly IContractRepository _contractRepository;
        private readonly INodeRepository _nodeRepository;
        private readonly IAccessKeyRepository _accessKeyRepository;
        private readonly IUserRepository _userRepository;
        private readonly IUserAccountRepository _userAccountRepository;

        private readonly string CONTRACT_NAME = "Sample_Deployement";
        public SampleContractController(IContractRepository contractRepository,
            INodeRepository nodeRepository,
            IAccessKeyRepository accessKeyRepository,
            IUserRepository userRepository,
            IUserAccountRepository userAccountRepository)
        {
            _contractRepository = contractRepository;
            _nodeRepository = nodeRepository;
            _accessKeyRepository = accessKeyRepository;
            _userRepository = userRepository;
            _userAccountRepository = userAccountRepository;
        }

        [HttpPost]
        [SwaggerOperation(Tags = new string[] { "Contracts" })]
        [Route("DeploySampleContract")]
        public async Task<IHttpActionResult> DeploySampleContract(int userId)
        {
            bool isContractAlreadyExist = _contractRepository.GetAll().ToList()
                .Where(item => item.Name == CONTRACT_NAME).FirstOrDefault() != null ? true : false;
            if (!isContractAlreadyExist)
            {
                var user = _userRepository.GetByID(userId);
                if (user != null)
                {
                    var userAccount = _userAccountRepository.GetAll().ToList().Where(item => item.UserId == user.Id).FirstOrDefault();

                    var node = _nodeRepository.GetByID(user.NodeId);
                    if (node != null && userAccount != null)
                    {
                        var accessKey = _accessKeyRepository.GetAll().ToList().Where(item => item.NodeId == node.Id).FirstOrDefault();
                        if (accessKey != null)
                        {

                            var newWeb3 = new Web3Quorum(accessKey.UrlKey);
                            //var privateFor =accounts.ToList().Where(item=>item != userAccount.Address).ToList();
                            //newWeb3.SetPrivateRequestParameters(privateFor);
                            //newWeb3.Quorum.

                            //var isAccountUnlocked = await web3.Personal.UnlockAccount
                            //      .SendRequestAsync(account.Address, user.Name + user.Password, 120);

                            var isAccountUnlocked = await newWeb3.Personal.UnlockAccount
                                  .SendRequestAsync(userAccount.Address, user.Name + user.Password, 120);

                            //var newWeb3 = new Web3(account);
                            var sampleDeploymentContract = new SampleDeployment()
                            {
                                Gas=2500000,
                                GasPrice=0,
                                FromAddress =userAccount.Address
                            };
                           
                            var transactionReciept = await SampleService.DeployContractAndWaitForReceiptAsync(newWeb3, sampleDeploymentContract);
                           

                            //var mineResult = await newWeb3.Miner.Start.SendRequestAsync();
                            //var receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionReciept.TransactionHash);

                            //while (receipt == null)
                            //{
                            //    Thread.Sleep(3000);
                            //    receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionReciept.TransactionHash);
                            //}
                            //mineResult = await newWeb3.Miner.Stop.SendRequestAsync();

                            _contractRepository.Save(new DLL.DataModels.Contract()
                            {
                                Name = CONTRACT_NAME,
                                Address = transactionReciept.ContractAddress,
                                NodeId = node.Id,
                                UserId = user.Id,
                                UserAccountId = userAccount.Id
                            });
                        }
                    }
                }
                return Ok("Contract Deployed");

            }
            return Ok("Contract Already Exist");

        }

        [HttpGet]
        [SwaggerOperation(Tags = new string[] { "Contracts" })]
        [Route("GetSampleContractAddress")]
        public async Task<IHttpActionResult> GetSampleContractAddress()
        {
            var contractAddress = _contractRepository.GetAll().ToList().Where(item => item.Name == CONTRACT_NAME).FirstOrDefault()?.Address;
            if (contractAddress != null)
            {
                return Ok(contractAddress);
            }
            return Ok("Contract Not found in DB");
        }

        [HttpPost]
        [SwaggerOperation(Tags = new string[] { "Contracts" })]
        [Route("SetValueForX")]
        public async Task<IHttpActionResult> SetValueForX(int userId, int x)
        {
            var contract = _contractRepository.GetAll().ToList()
                          .Where(item => item.Name == CONTRACT_NAME).FirstOrDefault();
            if (contract != null)
            {
                var user = _userRepository.GetByID(userId);
                if (user != null)
                {
                    var userAccount = _userAccountRepository.GetAll().ToList().Where(item => item.UserId == user.Id).FirstOrDefault();

                    var node = _nodeRepository.GetByID(user.NodeId);
                    if (node != null && userAccount != null)
                    {
                        var accessKey = _accessKeyRepository.GetAll().ToList().Where(item => item.NodeId == node.Id).FirstOrDefault();
                        if (accessKey != null)
                        {

                          
                            var account = new QuorumAccount(userAccount.Address);
                            var newWeb3 = new Web3Quorum(account, accessKey.UrlKey);
                            var isAccountUnlocked = await newWeb3.Personal.UnlockAccount
                                  .SendRequestAsync(userAccount.Address, userAccount.Name + userAccount.Password, 120);
                            var contractHandler =  newWeb3.Eth.GetContractHandler(contract.Address);
                            var sampleService = new SampleService(newWeb3, contractHandler.ContractAddress);

                            BigInteger b = new BigInteger(x);
                            
                            var transRecipt = await sampleService.SetValueForXRequestAndWaitForReceiptAsync(new SetValueForXFunction() {
                                FromAddress= userAccount.Address,
                                X = b,
                                Gas =  100000000,
                                GasPrice =0
                                
                            });


                            var hash = await newWeb3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(transRecipt.TransactionHash);
                            
                            var events =   transRecipt.DecodeAllEvents<TransferEventDto>();
                          
                           //var isAccountUnlocked = await newWeb3.Personal.UnlockAccount
                            //      .SendRequestAsync(account.Address, user.Name + user.Password, 120);
                            //var sampleContractService = new SampleService(newWeb3, contract.Address);

                            //var sampleContractHandler = sampleContractService.ContractHandler;
                            //var callInput = new CallInput();
                            //callInput.From = userAccount.Address;
                            //var sampleContractTransactionHandler = sampleContractService.ContractHandler.EthApiContractService.GetContractTransactionHandler<SetValueForXFunction>();
                            //var setValueForX = new SetValueForXFunction();
                            //setValueForX.X = x;
                            //var gasRequired = await sampleContractHandler.EthApiContractService.Transactions.EstimateGas.SendRequestAsync(callInput);
                            ////sampleContractHandler.EthApiContractService.Transactions.EstimateGas.SendRequestAsync(callInput);
                            //setValueForX.Gas =  gasRequired;
                            //var res = await sampleContractHandler.SendRequestAndWaitForReceiptAsync(setValueForX);

                            //var sampleContract = newWeb3.Eth.GetContract<SampleDeployment>(contract.Address);
                            //var sampleContractHandler = newWeb3.Eth.GetContractHandler(sampleContract.Address);

                            //var callInput = new CallInput();
                            //var gasRequired = await sampleContractHandler.EthApiContractService.Transactions.EstimateGas.SendRequestAsync(callInput);
                            //var setValueForX = new SetValueForXFunction();
                            //setValueForX.X = x;
                            //setValueForX.Gas = gasRequired;


                            //    newWeb3.Eth.GetContractTransactionHandler<SetValueForXFunction>();
                            //sampleContractTransactionHandler.


                            //var transactionRecipt = await sampleContractService.SetValueForXRequestAndWaitForReceiptAsync(
                            //    new SetValueForXFunction()
                            //    {
                            //        X = b,
                            //        FromAddress =account.Address,
                            //        Gas = 400000,

                            //    });
                            //var web3Geth = new Web3Geth(account, accessKey.UrlKey);
                            //var mineResult = await web3Geth.Miner.Start.SendRequestAsync(6);
                            //var receipt = await newWeb3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionRecipt.TransactionHash);

                            //while (receipt == null)
                            //{
                            //    Thread.Sleep(3000);
                            //    receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionRecipt.TransactionHash);
                            //}
                            //mineResult = await web3Geth.Miner.Stop.SendRequestAsync();


                            return Ok("testimg");

                        }
                    }
                }
            }

            return Ok("Transaction for X ");
        }


        [HttpGet]
        [SwaggerOperation(Tags = new string[] { "Contracts" })]
        [Route("GetValueForX")]
        public async Task<IHttpActionResult> GetValueForX(int userId)
        {
            var contract = _contractRepository.GetAll().ToList()
                          .Where(item => item.Name == CONTRACT_NAME).FirstOrDefault();
            if (contract != null)
            {
                var user = _userRepository.GetByID(userId);
                if (user != null)
                {
                    var userAccount = _userAccountRepository.GetAll().ToList().Where(item => item.UserId == user.Id).FirstOrDefault();

                    var node = _nodeRepository.GetByID(user.NodeId);
                    if (node != null && userAccount != null)
                    {
                        var accessKey = _accessKeyRepository.GetAll().ToList().Where(item => item.NodeId == node.Id).FirstOrDefault();
                        if (accessKey != null)
                        {
                            var account = new QuorumAccount(userAccount.Address);

                            var web3 = new Web3Quorum(account, accessKey.UrlKey);
                            var isAccountUnlocked = await web3.Personal.UnlockAccount
                                  .SendRequestAsync(account.Address, user.Name + user.Password, 120);
                            var newWeb3 = new Web3Quorum(account, accessKey.UrlKey);
                          var contract1 =  newWeb3.Eth.GetContract<SampleDeployment>(contract.Address);
                            //contract1.Eth.
                            var sampleContractService = new SampleService(newWeb3, contract.Address);

                            var getValueForXFunc = new GetValueForXFunction();
                            var resp = await sampleContractService.GetValueForXQueryAsync(getValueForXFunc);
                            int value = (int)resp;
                            return Ok(value);

                        }
                    }
                }
            }

            return Ok("Cannot value for X ");
        }
    }
}
