using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Numerics;
using Nethereum.Hex.HexTypes;
using Nethereum.ABI.FunctionEncoding.Attributes;
using Nethereum.Web3;
using Nethereum.RPC.Eth.DTOs;
using Nethereum.Contracts.CQS;
using Nethereum.Contracts;
using System.Threading;

namespace SmartContracts.Contracts.ERC165.ContractDefinition
{


    public partial class ERC165Deployment : ERC165DeploymentBase
    {
        public ERC165Deployment() : base(BYTECODE) { }
        public ERC165Deployment(string byteCode) : base(byteCode) { }
    }

    public class ERC165DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public ERC165DeploymentBase() : base(BYTECODE) { }
        public ERC165DeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class SupportsInterfaceFunction : SupportsInterfaceFunctionBase { }

    [Function("supportsInterface", "bool")]
    public class SupportsInterfaceFunctionBase : FunctionMessage
    {
        [Parameter("bytes4", "interfaceId", 1)]
        public virtual byte[] InterfaceId { get; set; }
    }

    public partial class SupportsInterfaceOutputDTO : SupportsInterfaceOutputDTOBase { }

    [FunctionOutput]
    public class SupportsInterfaceOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }
}
