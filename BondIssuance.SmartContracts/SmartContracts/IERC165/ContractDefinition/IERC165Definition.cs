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

namespace SmartContracts.Contracts.IERC165.ContractDefinition
{


    public partial class IERC165Deployment : IERC165DeploymentBase
    {
        public IERC165Deployment() : base(BYTECODE) { }
        public IERC165Deployment(string byteCode) : base(byteCode) { }
    }

    public class IERC165DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public IERC165DeploymentBase() : base(BYTECODE) { }
        public IERC165DeploymentBase(string byteCode) : base(byteCode) { }

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
