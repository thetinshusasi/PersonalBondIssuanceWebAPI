using BondIssuance.DLL.DataModels;
using BondIssuance.DLL.IRepositories;
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
using Nethereum.Signer;
using SmartContracts.Contracts.BondIssuer;
using SmartContracts.Contracts.BondIssuer.ContractDefinition;
using Nethereum.ABI.Encoders;
using Nethereum.Hex.HexTypes;

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

                            var managedAccount = new ManagedAccount(userAccount.Address, userAccount.Password);
                            var web3Managed = new Web3(managedAccount,accessKey.UrlKey);
                            var unlocked = await web3Managed.Personal.UnlockAccount.SendRequestAsync(userAccount.Address, userAccount.Password, 30);

                            var balance = await web3Managed.Eth.GetBalance.SendRequestAsync(userAccount.Address);

                            var service = await BondIssuerService.DeployContractAndWaitForReceiptAsync(web3Managed,
                                new BondIssuerDeployment()
                                {
                                    Bonds = new List<BigInteger>(),
                                    Coupon = 10,
                                    Decimals = 10,
                                    DocumentHashes = new List<byte[]>(),
                                    FaceValue = 100,
                                    Investors = new List<string>(),
                                    Isin = "ISN",
                                    Issuer = userAccount.Address,
                                    Maturity = "10",
                                    Name = "tinshuToken",
                                    TotalSupply = 10,
                                    Gas = 1000000
                                });

                            //var web3Geth = new Web3Geth(managedAccount, accessKey.UrlKey);

                            //       var mineResult = await web3Geth.Miner.Start.SendRequestAsync(6);
                            //var status = new HexBigInteger(0);
                            //while (service.Status == status)
                            //{
                            //    Thread.Sleep(5000);
                            //    service = await web3Managed.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(service.TransactionHash);
                            //}
                            //mineResult = await web3Geth.Miner.Stop.SendRequestAsync();

                            //_contractRepository.Save(new DLL.DataModels.Contract()
                            //{
                            //    Name = CONTRACT_NAME,
                            //    Address = service.ContractAddress,
                            //    NodeId = node.Id,
                            //    UserId = user.Id,
                            //    UserAccountId = userAccount.Id
                            //});
                            return Ok("code deployed");

                        }
                    }
                }

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

        //[HttpPost]
        //[SwaggerOperation(Tags = new string[] { "Contracts" })]
        //[Route("SetValueForX")]
        //public async Task<IHttpActionResult> SetValueForX(int userId, int x)
        //{
        //    var contract = _contractRepository.GetAll().ToList()
        //                  .Where(item => item.Name == CONTRACT_NAME).FirstOrDefault();
        //    if (contract != null)
        //    {
        //        var user = _userRepository.GetByID(userId);
        //        if (user != null)
        //        {
        //            var userAccount = _userAccountRepository.GetAll().ToList().Where(item => item.UserId == user.Id).FirstOrDefault();

        //            var node = _nodeRepository.GetByID(user.NodeId);
        //            if (node != null && userAccount != null)
        //            {
        //                var accessKey = _accessKeyRepository.GetAll().ToList().Where(item => item.NodeId == node.Id).FirstOrDefault();
        //                if (accessKey != null)
        //                {

                           
        //                    var account = new QuorumAccount(userAccount.Address);
        //                    var newWeb3 = new Web3Quorum(account, accessKey.UrlKey);
        //                    var isAccountUnlocked = await newWeb3.Personal.UnlockAccount
        //                          .SendRequestAsync(userAccount.Address, userAccount.Name + userAccount.Password, 120);
        //                    var contractHandler =  newWeb3.Eth.GetContractHandler(contract.Address);
        //                    var sampleService = new BondIssuerService(newWeb3, contractHandler.ContractAddress);

        //                    BigInteger b = new BigInteger(x);
                            
        //                    var transRecipt = await sampleService.(new SetValueForXFunction() {
        //                        FromAddress= userAccount.Address,
        //                        X = b,
        //                        Gas =  100000000,
        //                        GasPrice =0,

                                
        //                    });


        //                    var hash = await newWeb3.Eth.Transactions.GetTransactionByHash.SendRequestAsync(transRecipt.TransactionHash);
                            
        //                    var events =   transRecipt.DecodeAllEvents<TransferEventDto>();
                          
        //                   //var isAccountUnlocked = await newWeb3.Personal.UnlockAccount
        //                    //      .SendRequestAsync(account.Address, user.Name + user.Password, 120);
        //                    //var sampleContractService = new SampleService(newWeb3, contract.Address);

        //                    //var sampleContractHandler = sampleContractService.ContractHandler;
        //                    //var callInput = new CallInput();
        //                    //callInput.From = userAccount.Address;
        //                    //var sampleContractTransactionHandler = sampleContractService.ContractHandler.EthApiContractService.GetContractTransactionHandler<SetValueForXFunction>();
        //                    //var setValueForX = new SetValueForXFunction();
        //                    //setValueForX.X = x;
        //                    //var gasRequired = await sampleContractHandler.EthApiContractService.Transactions.EstimateGas.SendRequestAsync(callInput);
        //                    ////sampleContractHandler.EthApiContractService.Transactions.EstimateGas.SendRequestAsync(callInput);
        //                    //setValueForX.Gas =  gasRequired;
        //                    //var res = await sampleContractHandler.SendRequestAndWaitForReceiptAsync(setValueForX);

        //                    //var sampleContract = newWeb3.Eth.GetContract<SampleDeployment>(contract.Address);
        //                    //var sampleContractHandler = newWeb3.Eth.GetContractHandler(sampleContract.Address);

        //                    //var callInput = new CallInput();
        //                    //var gasRequired = await sampleContractHandler.EthApiContractService.Transactions.EstimateGas.SendRequestAsync(callInput);
        //                    //var setValueForX = new SetValueForXFunction();
        //                    //setValueForX.X = x;
        //                    //setValueForX.Gas = gasRequired;


        //                    //    newWeb3.Eth.GetContractTransactionHandler<SetValueForXFunction>();
        //                    //sampleContractTransactionHandler.


        //                    //var transactionRecipt = await sampleContractService.SetValueForXRequestAndWaitForReceiptAsync(
        //                    //    new SetValueForXFunction()
        //                    //    {
        //                    //        X = b,
        //                    //        FromAddress =account.Address,
        //                    //        Gas = 400000,

        //                    //    });
        //                    //var web3Geth = new Web3Geth(account, accessKey.UrlKey);
        //                    //var mineResult = await web3Geth.Miner.Start.SendRequestAsync(6);
        //                    //var receipt = await newWeb3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionRecipt.TransactionHash);

        //                    //while (receipt == null)
        //                    //{
        //                    //    Thread.Sleep(3000);
        //                    //    receipt = await web3.Eth.Transactions.GetTransactionReceipt.SendRequestAsync(transactionRecipt.TransactionHash);
        //                    //}
        //                    //mineResult = await web3Geth.Miner.Stop.SendRequestAsync();


        //                    return Ok("testimg");

        //                }
        //            }
        //        }
        //    }

        //    return Ok("Transaction for X ");
        //}


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




                            var managedAccount = new Account(userAccount.Address);
                            var web3Managed = new Web3(managedAccount, accessKey.UrlKey);
                            var unlocked = await web3Managed.Personal.UnlockAccount.SendRequestAsync(userAccount.Address, userAccount.Password, 30);

                            var service2 = new BondIssuerService(web3Managed, contract.Address);
                            var receipt2 = await service2.GetTestValueQueryAsync(
                                new GetTestValueFunction()
                                {                                 
                                    FromAddress = userAccount.Address
                                });

                            return Ok(receipt2);

                        }
                    }
                }
            }

            return Ok("Cannot value for X ");
        }
    }
}
