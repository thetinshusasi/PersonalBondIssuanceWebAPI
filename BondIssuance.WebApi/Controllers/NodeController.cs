using BondIssuance.DLL.Contexts;
using BondIssuance.DLL.IRepositories;
using BondIssuance.DLL.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using BondIssuance.DLL.DataModels;

namespace BondIssuance.WebApi.Controllers
{
    public class NodeController : ApiController
    {
        private readonly INodeRepository _nodeRepository;
        public NodeController(INodeRepository nodeRepository)
        {
            _nodeRepository = nodeRepository;
        }


        [HttpGet]
        public async Task<IHttpActionResult> GetNodes()
        {
            var nodes = _nodeRepository.GetAll();
            //var client = new Nethereum.JsonRpc.Client.RpcClient(new Uri("https://admintest.blockchain.azure.com:3200/o8rC9YIzD9rZ23lBwwhzqt5M"));
            return Ok(200);
        }

        [HttpPost]
        public async Task<IHttpActionResult> PostNodes(Node node)
        {
            _nodeRepository.Save(node);
            return Ok(200);
        }
    }
}
