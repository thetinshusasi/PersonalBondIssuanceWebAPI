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

namespace SmartContracts.Contracts.WhitelistAdminRole.ContractDefinition
{


    public partial class WhitelistAdminRoleDeployment : WhitelistAdminRoleDeploymentBase
    {
        public WhitelistAdminRoleDeployment() : base(BYTECODE) { }
        public WhitelistAdminRoleDeployment(string byteCode) : base(byteCode) { }
    }

    public class WhitelistAdminRoleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public WhitelistAdminRoleDeploymentBase() : base(BYTECODE) { }
        public WhitelistAdminRoleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class IsWhitelistAdminFunction : IsWhitelistAdminFunctionBase { }

    [Function("isWhitelistAdmin", "bool")]
    public class IsWhitelistAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class AddWhitelistAdminFunction : AddWhitelistAdminFunctionBase { }

    [Function("addWhitelistAdmin")]
    public class AddWhitelistAdminFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RenounceWhitelistAdminFunction : RenounceWhitelistAdminFunctionBase { }

    [Function("renounceWhitelistAdmin")]
    public class RenounceWhitelistAdminFunctionBase : FunctionMessage
    {

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




}
