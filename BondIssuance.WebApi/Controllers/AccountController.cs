using Nethereum.Quorum;
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
        public AccountController()
        {

        }

        [HttpPost]
        [Route("CreateAccount")]

        public async Task<IHttpActionResult> CreateUserAccount(string userName, string password)
        {

            var web3 = new Web3Quorum("https://admintest.blockchain.azure.com:3200/o8rC9YIzD9rZ23lBwwhzqt5M");
            var personalAccountDetails = await web3.Personal.NewAccount.SendRequestAsync(password);
            return Ok(200);

        }

        [HttpGet]
        [Route("GetAccounts")]

        public async Task<IHttpActionResult> GetAccounts()
        {
            var web3 = new Web3Quorum("https://admintest.blockchain.azure.com:3200/o8rC9YIzD9rZ23lBwwhzqt5M");
           var accounts =  await web3.Personal.ListAccounts.SendRequestAsync();
            return Ok(accounts);
        }

        [HttpGet]
        [Route("GetAccount")]
        public async Task<IHttpActionResult> GetAccount(string userName, string password)
        {
            var web3 = new Web3Quorum("https://admintest.blockchain.azure.com:3200/o8rC9YIzD9rZ23lBwwhzqt5M");
            var accounts = await web3.Personal.ListAccounts.SendRequestAsync();

            var account = new ManagedAccount(accounts[1], password);
            return Ok(200);
        }
    }
}
