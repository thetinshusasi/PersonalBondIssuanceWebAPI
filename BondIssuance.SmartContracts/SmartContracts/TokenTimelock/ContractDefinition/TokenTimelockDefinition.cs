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

namespace SmartContracts.Contracts.TokenTimelock.ContractDefinition
{


    public partial class TokenTimelockDeployment : TokenTimelockDeploymentBase
    {
        public TokenTimelockDeployment() : base(BYTECODE) { }
        public TokenTimelockDeployment(string byteCode) : base(byteCode) { }
    }

    public class TokenTimelockDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b506040516060806104cb8339810180604052606081101561003057600080fd5b8101908080519060200190929190805190602001909291908051906020019092919050505042811161006157600080fd5b826000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff16021790555081600160006101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff160217905550806002819055505050506103d0806100fb6000396000f3fe608060405234801561001057600080fd5b506004361061004c5760003560e01c806338af3eed1461005157806386d1a69f1461009b578063b91d4001146100a5578063fc0c546a146100c3575b600080fd5b61005961010d565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b6100a3610137565b005b6100ad6102a1565b6040518082815260200191505060405180910390f35b6100cb6102ab565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b6000600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905090565b60025442101561014657600080fd5b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166370a08231306040518263ffffffff1660e01b8152600401808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060206040518083038186803b1580156101e657600080fd5b505afa1580156101fa573d6000803e3d6000fd5b505050506040513d602081101561021057600080fd5b810190808051906020019092919050505090506000811161023057600080fd5b61029e600160009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16826000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff166102d49092919063ffffffff16565b50565b6000600254905090565b60008060009054906101000a900473ffffffffffffffffffffffffffffffffffffffff16905090565b8273ffffffffffffffffffffffffffffffffffffffff1663a9059cbb83836040518363ffffffff1660e01b8152600401808373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200182815260200192505050602060405180830381600087803b15801561035b57600080fd5b505af115801561036f573d6000803e3d6000fd5b505050506040513d602081101561038557600080fd5b810190808051906020019092919050505061039f57600080fd5b50505056fea165627a7a72305820925296b6174972d05cfd9948d9d1b9073cba46f76ffa5e288e286f415d8b84f60029";
        public TokenTimelockDeploymentBase() : base(BYTECODE) { }
        public TokenTimelockDeploymentBase(string byteCode) : base(byteCode) { }
        [Parameter("address", "token", 1)]
        public virtual string Token { get; set; }
        [Parameter("address", "beneficiary", 2)]
        public virtual string Beneficiary { get; set; }
        [Parameter("uint256", "releaseTime", 3)]
        public virtual BigInteger ReleaseTime { get; set; }
    }

    public partial class TokenFunction : TokenFunctionBase { }

    [Function("token", "address")]
    public class TokenFunctionBase : FunctionMessage
    {

    }

    public partial class BeneficiaryFunction : BeneficiaryFunctionBase { }

    [Function("beneficiary", "address")]
    public class BeneficiaryFunctionBase : FunctionMessage
    {

    }

    public partial class ReleaseTimeFunction : ReleaseTimeFunctionBase { }

    [Function("releaseTime", "uint256")]
    public class ReleaseTimeFunctionBase : FunctionMessage
    {

    }

    public partial class ReleaseFunction : ReleaseFunctionBase { }

    [Function("release")]
    public class ReleaseFunctionBase : FunctionMessage
    {

    }

    public partial class TokenOutputDTO : TokenOutputDTOBase { }

    [FunctionOutput]
    public class TokenOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class BeneficiaryOutputDTO : BeneficiaryOutputDTOBase { }

    [FunctionOutput]
    public class BeneficiaryOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }

    public partial class ReleaseTimeOutputDTO : ReleaseTimeOutputDTOBase { }

    [FunctionOutput]
    public class ReleaseTimeOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }


}
