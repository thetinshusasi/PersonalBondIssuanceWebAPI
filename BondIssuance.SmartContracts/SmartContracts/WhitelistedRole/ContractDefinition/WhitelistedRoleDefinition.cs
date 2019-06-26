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

namespace SmartContracts.Contracts.WhitelistedRole.ContractDefinition
{


    public partial class WhitelistedRoleDeployment : WhitelistedRoleDeploymentBase
    {
        public WhitelistedRoleDeployment() : base(BYTECODE) { }
        public WhitelistedRoleDeployment(string byteCode) : base(byteCode) { }
    }

    public class WhitelistedRoleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x60806040526100133361001860201b60201c565b6101ba565b61003081600061007660201b6104be1790919060201c565b8073ffffffffffffffffffffffffffffffffffffffff167f22380c05984257a1cb900161c713dd71d39e74820f1aea43bd3f1bdd2096129960405160405180910390a250565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614156100b057600080fd5b6100c0828261012860201b60201c565b156100ca57600080fd5b60018260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055505050565b60008073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff16141561016357600080fd5b8260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16905092915050565b610641806101c96000396000f3fe608060405234801561001057600080fd5b506004361061007d5760003560e01c80634c5a628c1161005b5780634c5a628c146101665780637362d9c814610170578063bb5f747b146101b4578063d6cd9473146102105761007d565b806310154bad14610082578063291d9549146100c65780633af32abf1461010a575b600080fd5b6100c46004803603602081101561009857600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919050505061021a565b005b610108600480360360208110156100dc57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610238565b005b61014c6004803603602081101561012057600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff169060200190929190505050610256565b604051808215151515815260200191505060405180910390f35b61016e610273565b005b6101b26004803603602081101561018657600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919050505061027e565b005b6101f6600480360360208110156101ca57600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919050505061029c565b604051808215151515815260200191505060405180910390f35b6102186102b9565b005b6102233361029c565b61022c57600080fd5b610235816102c4565b50565b6102413361029c565b61024a57600080fd5b6102538161031e565b50565b600061026c82600161037890919063ffffffff16565b9050919050565b61027c3361040a565b565b6102873361029c565b61029057600080fd5b61029981610464565b50565b60006102b282600061037890919063ffffffff16565b9050919050565b6102c23361031e565b565b6102d88160016104be90919063ffffffff16565b8073ffffffffffffffffffffffffffffffffffffffff167fee1504a83b6d4a361f4c1dc78ab59bfa30d6a3b6612c403e86bb01ef2984295f60405160405180910390a250565b61033281600161056a90919063ffffffff16565b8073ffffffffffffffffffffffffffffffffffffffff167f270d9b30cf5b0793bbfd54c9d5b94aeb49462b8148399000265144a8722da6b660405160405180910390a250565b60008073ffffffffffffffffffffffffffffffffffffffff168273ffffffffffffffffffffffffffffffffffffffff1614156103b357600080fd5b8260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060009054906101000a900460ff16905092915050565b61041e81600061056a90919063ffffffff16565b8073ffffffffffffffffffffffffffffffffffffffff167f0a8eb35e5ca14b3d6f28e4abf2f128dbab231a58b56e89beb5d636115001e16560405160405180910390a250565b6104788160006104be90919063ffffffff16565b8073ffffffffffffffffffffffffffffffffffffffff167f22380c05984257a1cb900161c713dd71d39e74820f1aea43bd3f1bdd2096129960405160405180910390a250565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614156104f857600080fd5b6105028282610378565b1561050c57600080fd5b60018260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff0219169083151502179055505050565b600073ffffffffffffffffffffffffffffffffffffffff168173ffffffffffffffffffffffffffffffffffffffff1614156105a457600080fd5b6105ae8282610378565b6105b757600080fd5b60008260000160008373ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200190815260200160002060006101000a81548160ff021916908315150217905550505056fea165627a7a7230582035541bbada5943b9ad5369f3c56612a216bb013cb3d12d5c694c81e6a9f52dd40029";
        public WhitelistedRoleDeploymentBase() : base(BYTECODE) { }
        public WhitelistedRoleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class RenounceWhitelistAdminFunction : RenounceWhitelistAdminFunctionBase { }

    [Function("renounceWhitelistAdmin")]
    public class RenounceWhitelistAdminFunctionBase : FunctionMessage
    {

    }

    public partial class AddWhitelistAdminFunction : AddWhitelistAdminFunctionBase { }

    [Function("addWhitelistAdmin")]
    public class AddWhitelistAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class IsWhitelistAdminFunction : IsWhitelistAdminFunctionBase { }

    [Function("isWhitelistAdmin", "bool")]
    public class IsWhitelistAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class IsWhitelistedFunction : IsWhitelistedFunctionBase { }

    [Function("isWhitelisted", "bool")]
    public class IsWhitelistedFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class AddWhitelistedFunction : AddWhitelistedFunctionBase { }

    [Function("addWhitelisted")]
    public class AddWhitelistedFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RemoveWhitelistedFunction : RemoveWhitelistedFunctionBase { }

    [Function("removeWhitelisted")]
    public class RemoveWhitelistedFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RenounceWhitelistedFunction : RenounceWhitelistedFunctionBase { }

    [Function("renounceWhitelisted")]
    public class RenounceWhitelistedFunctionBase : FunctionMessage
    {

    }

    public partial class WhitelistedAddedEventDTO : WhitelistedAddedEventDTOBase { }

    [Event("WhitelistedAdded")]
    public class WhitelistedAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class WhitelistedRemovedEventDTO : WhitelistedRemovedEventDTOBase { }

    [Event("WhitelistedRemoved")]
    public class WhitelistedRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class WhitelistAdminAddedEventDTO : WhitelistAdminAddedEventDTOBase { }

    [Event("WhitelistAdminAdded")]
    public class WhitelistAdminAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class WhitelistAdminRemovedEventDTO : WhitelistAdminRemovedEventDTOBase { }

    [Event("WhitelistAdminRemoved")]
    public class WhitelistAdminRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }





    public partial class IsWhitelistAdminOutputDTO : IsWhitelistAdminOutputDTOBase { }

    [FunctionOutput]
    public class IsWhitelistAdminOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }

    public partial class IsWhitelistedOutputDTO : IsWhitelistedOutputDTOBase { }

    [FunctionOutput]
    public class IsWhitelistedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }






}
