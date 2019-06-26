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

namespace SmartContracts.Contracts.Roles.ContractDefinition
{


    public partial class RolesDeployment : RolesDeploymentBase
    {
        public RolesDeployment() : base(BYTECODE) { }
        public RolesDeployment(string byteCode) : base(byteCode) { }
    }

    public class RolesDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x604c6023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea165627a7a72305820250cab95ac6dc4d7a0c976dd59ba099506c5fb3d6bd21cbca22f272385fd93e90029";
        public RolesDeploymentBase() : base(BYTECODE) { }
        public RolesDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
