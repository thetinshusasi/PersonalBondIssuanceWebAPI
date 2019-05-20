using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace BondIssuance.WebApi.Controllers
{
    public class NodeController : ApiController
    {
        public NodeController()
        {

        }

        [HttpGet]
        public async Task<IHttpActionResult> GetNodes()
        {
            var client = new Nethereum.JsonRpc.Client.RpcClient(new Uri("https://admintest.blockchain.azure.com:3200/o8rC9YIzD9rZ23lBwwhzqt5M"));
            return Ok(200);
        }
    }
}
