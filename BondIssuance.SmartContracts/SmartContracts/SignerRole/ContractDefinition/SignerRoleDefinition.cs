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

namespace SmartContracts.Contracts.SignerRole.ContractDefinition
{


    public partial class SignerRoleDeployment : SignerRoleDeploymentBase
    {
        public SignerRoleDeployment() : base(BYTECODE) { }
        public SignerRoleDeployment(string byteCode) : base(byteCode) { }
    }

    public class SignerRoleDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x";
        public SignerRoleDeploymentBase() : base(BYTECODE) { }
        public SignerRoleDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class IsSignerFunction : IsSignerFunctionBase { }

    [Function("isSigner", "bool")]
    public class IsSignerFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class AddSignerFunction : AddSignerFunctionBase { }

    [Function("addSigner")]
    public class AddSignerFunctionBase : FunctionMessage
    {
        [Parameter("address", "account", 1)]
        public virtual string Account { get; set; }
    }

    public partial class RenounceSignerFunction : RenounceSignerFunctionBase { }

    [Function("renounceSigner")]
    public class RenounceSignerFunctionBase : FunctionMessage
    {

    }

    public partial class SignerAddedEventDTO : SignerAddedEventDTOBase { }

    [Event("SignerAdded")]
    public class SignerAddedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class SignerRemovedEventDTO : SignerRemovedEventDTOBase { }

    [Event("SignerRemoved")]
    public class SignerRemovedEventDTOBase : IEventDTO
    {
        [Parameter("address", "account", 1, true )]
        public virtual string Account { get; set; }
    }

    public partial class IsSignerOutputDTO : IsSignerOutputDTOBase { }

    [FunctionOutput]
    public class IsSignerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("bool", "", 1)]
        public virtual bool ReturnValue1 { get; set; }
    }




}
