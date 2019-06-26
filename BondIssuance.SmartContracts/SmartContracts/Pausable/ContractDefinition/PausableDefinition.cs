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

namespace SmartContracts.Contracts.Pausable.ContractDefinition
{


    public partial class PausableDeployment : PausableDeploymentBase
    {
        public PausableDeployment() : base(BYTECODE) { }
        public PausableDeployment(string byteCode) : base(byteCode) { }
    }

    public class PausableDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public PausableDeploymentBase() : base(BYTECODE) { }
        public PausableDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class IsPauserFunction : IsPauserFunctionBase { }

    [Function("isPauser", "bool")]
    public class IsPauserFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RenouncePauserFunction : RenouncePauserFunctionBase { }

    [Function("renouncePauser")]
    public class RenouncePauserFunctionBase : FunctionMessage
    {

    }

    public partial class AddPauserFunction : AddPauserFunctionBase { }

    [Function("addPauser")]
    public class AddPauserFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class PausedFunction : PausedFunctionBase { }

    [Function("paused", "bool")]
    public class PausedFunctionBase : FunctionMessage
    {

    }

    public partial class PauseFunction : PauseFunctionBase { }

    [Function("pause")]
    public class PauseFunctionBase : FunctionMessage
    {

    }

    public partial class UnpauseFunction : UnpauseFunctionBase { }

    [Function("unpause")]
    public class UnpauseFunctionBase : FunctionMessage
    {

    }

    public partial class PausedEventDTO : PausedEventDTOBase { }

    [Event("Paused")]
    public class PausedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, false )]
        public virtual string Account { get; set; }
    }

    public partial class UnpausedEventDTO : UnpausedEventDTOBase { }

    [Event("Unpaused")]
    public class UnpausedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, false )]
        public virtual string Account { get; set; }
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





    public partial class PausedOutputDTO : PausedOutputDTOBase { }

    [FunctionOutput]
    public class PausedOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }




}
