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

namespace SmartContracts.Contracts.CapperRole.ContractDefinition
{


    public partial class CapperRoleDeployment : CapperRoleDeploymentBase
    {
        public CapperRoleDeployment() : base(BYTECODE) { }
        public CapperRoleDeployment(string byteCode) : base(byteCode) { }
    }

    public class CapperRoleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public CapperRoleDeploymentBase() : base(BYTECODE) { }
        public CapperRoleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class IsCapperFunction : IsCapperFunctionBase { }

    [Function("isCapper", "bool")]
    public class IsCapperFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class AddCapperFunction : AddCapperFunctionBase { }

    [Function("addCapper")]
    public class AddCapperFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RenounceCapperFunction : RenounceCapperFunctionBase { }

    [Function("renounceCapper")]
    public class RenounceCapperFunctionBase : FunctionMessage
    {

    }

    public partial class CapperAddedEventDTO : CapperAddedEventDTOBase { }

    [Event("CapperAdded")]
    public class CapperAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class CapperRemovedEventDTO : CapperRemovedEventDTOBase { }

    [Event("CapperRemoved")]
    public class CapperRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class IsCapperOutputDTO : IsCapperOutputDTOBase { }

    [FunctionOutput]
    public class IsCapperOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }




}
