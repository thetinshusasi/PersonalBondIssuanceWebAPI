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

namespace SmartContracts.Contracts.SafeERC20.ContractDefinition
{


    public partial class SafeERC20Deployment : SafeERC20DeploymentBase
    {
        public SafeERC20Deployment() : base(BYTECODE) { }
        public SafeERC20Deployment(string byteCode) : base(byteCode) { }
    }

    public class SafeERC20DeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x604c6023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea165627a7a7230582006dcab1fe4c0d5826dc95b95d54522e8e874e8c43fa5bc40672de4d82c5584300029";
        public SafeERC20DeploymentBase() : base(BYTECODE) { }
        public SafeERC20DeploymentBase(string byteCode) : base(byteCode) { }

    }
}
