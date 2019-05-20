using System;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Text;
using Nethereum.JsonRpc;

namespace BondIssuanceHackFest.WebAPI.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api")]
    public class NodeController : ApiController
    {
        public NodeController()
        {

        }

        [HttpGet]
        [Route("GetNodes")]
        public async Task<IHttpActionResult> GetNodes()
        {
            string authValue = Convert.ToBase64String(Encoding.UTF8.GetBytes("admintest:{Tinshu@30121992}"));
            var authHeader = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", authValue);
            //var client = new Ne
            var client = new Nethereum.JsonRpc.Client.RpcClient(new Uri("https://admintest.blockchain.azure.com:3200"), authHeader);
            //Nethereum.JsonRpc.Client.RpcClient(new Uri("https://admintest.blockchain.azure.com:3200"), authHeader);
            //var client = new Nethereum.JsonRpc
            return Ok();
        }
    }
}
