using BondIssuance.DLL.DataModels;
using BondIssuance.DLL.IRepositories;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.Quorum;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Web3;
using Nethereum.Web3.Accounts;
using Nethereum.Web3.Accounts.Managed;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;


namespace BondIssuance.WebApi.Controllers
{
    public class AccountController : ApiController
    {
        private readonly INodeRepository _nodeRepository;
        private readonly IAccessKeyRepository _accessKeyRepository;
        private readonly IUserRepository _userKeyRepository;
        private readonly IUserAccountRepository _userAccountKeyRepository;



        public AccountController(INodeRepository nodeRepository,
            IAccessKeyRepository accessKeyRepository,
            IUserRepository userKeyRepository,
            IUserAccountRepository userAccountKeyRepository)
        {
            _nodeRepository = nodeRepository;
            _accessKeyRepository = accessKeyRepository;
            _userKeyRepository = userKeyRepository;
            _userAccountKeyRepository = userAccountKeyRepository;
        }

        [HttpPost]
        [Route("CreateAccount")]

        public async Task<IHttpActionResult> CreateUserAccount(int userId, string password)
        {

            var user = _userKeyRepository.GetByID(userId);
            if (user != null)
            {
                var node = _nodeRepository.GetByID(user.NodeId);
                if (node != null)
                {
                    var accessKey = _accessKeyRepository.GetAll().ToList().Where(item => item.NodeId == node.Id).FirstOrDefault();
                    if (accessKey != null)
                    {

                        var ecKey = Nethereum.Signer.EthECKey.GenerateKey();
                        var privateKey = ecKey.GetPrivateKeyAsBytes().ToHex();
                        var web3 = new Web3Quorum(accessKey.UrlKey);
                        var publicKey = await web3.Personal.NewAccount.SendRequestAsync(privateKey);

                        var userAccount = new UserAccount()
                        {
                            Name = user.Name,
                            Password = privateKey,
                            PublicKey = publicKey,
                            Address = publicKey,
                            UserId = user.Id,
                            PrivateKey = privateKey


                        };
                        _userAccountKeyRepository.Save(userAccount);

                    }

                }
            }


            //node.
            //var web3 = new Web3Quorum("https://admintest.blockchain.azure.com:3200/o8rC9YIzD9rZ23lBwwhzqt5M");
            //var personalAccountDetails = await web3.Personal.NewAccount.SendRequestAsync(password);
            return Ok(200);

        }

        [HttpGet]
        [Route("GetAccounts")]

        public async Task<IHttpActionResult> GetAccounts(int nodeId)
        {
            string[] accountAddress = null;
            var node = _nodeRepository.GetByID(nodeId);
            if (node != null)
            {
                var accessKey = _accessKeyRepository.GetAll().ToList().Where(item => item.NodeId == node.Id).FirstOrDefault();
                if (accessKey != null)
                {
                    var web3 = new Web3Quorum(accessKey.UrlKey);                        
                    accountAddress = await web3.Eth.Accounts.SendRequestAsync();
                }
            }
            return Ok(accountAddress.ToList());
        }

        [HttpGet]
        [Route("GetAccount")]
        public async Task<IHttpActionResult> GetAccount(int userId)
        {
            var users =_userAccountKeyRepository.GetAll().ToList();
            users.Where(item => item.UserId == userId);
            return Ok(200);
        }
    }
}
