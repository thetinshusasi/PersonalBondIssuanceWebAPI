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

namespace SmartContracts.Contracts.PauserRole.ContractDefinition
{


    public partial class PauserRoleDeployment : PauserRoleDeploymentBase
    {
        public PauserRoleDeployment() : base(BYTECODE) { }
        public PauserRoleDeployment(string byteCode) : base(byteCode) { }
    }

    public class PauserRoleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public PauserRoleDeploymentBase() : base(BYTECODE) { }
        public PauserRoleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class IsPauserFunction : IsPauserFunctionBase { }

    [Function("isPauser", "bool")]
    public class IsPauserFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class AddPauserFunction : AddPauserFunctionBase { }

    [Function("addPauser")]
    public class AddPauserFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RenouncePauserFunction : RenouncePauserFunctionBase { }

    [Function("renouncePauser")]
    public class RenouncePauserFunctionBase : FunctionMessage
    {

    }

    public partial class PauserAddedEventDTO : PauserAddedEventDTOBase { }

    [Event("PauserAdded")]
    public class PauserAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class PauserRemovedEventDTO : PauserRemovedEventDTOBase { }

    [Event("PauserRemoved")]
    public class PauserRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class IsPauserOutputDTO : IsPauserOutputDTOBase { }

    [FunctionOutput]
    public class IsPauserOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }




}
