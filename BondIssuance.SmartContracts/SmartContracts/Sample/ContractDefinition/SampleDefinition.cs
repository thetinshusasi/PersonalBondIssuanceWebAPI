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

namespace BondIssuanceContracts.Sample.ContractDefinition
{


    public partial class SampleDeployment : SampleDeploymentBase
    {
        public SampleDeployment() : base(BYTECODE) { }
        public SampleDeployment(string byteCode) : base(byteCode) { }
    }

    public class SampleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "6080604052348015600f57600080fd5b5060a28061001e6000396000f3fe6080604052348015600f57600080fd5b506004361060325760003560e01c8063540c8629146037578063e1e99e8d146053575b600080fd5b605160048036036020811015604b57600080fd5b5035606b565b005b60596070565b60408051918252519081900360200190f35b600055565b6000549056fea165627a7a7230582045df2877835f61ca0f2a725e364ff47870abeb78980f922ab69db95016a3bde30029";
        public SampleDeploymentBase() : base(BYTECODE) { }
        public SampleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class SetValueForXFunction : SetValueForXFunctionBase { }

    [Function("setValueForX")]
    public class SetValueForXFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "x", 1)]
        public virtual BigInteger X { get; set; }
    }

    public partial class GetValueForXFunction : GetValueForXFunctionBase { }

    [Function("getValueForX", "uint256")]
    public class GetValueForXFunctionBase : FunctionMessage
    {

    }



    public partial class GetValueForXOutputDTO : GetValueForXOutputDTOBase { }

    [FunctionOutput]
    public class GetValueForXOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }
}
