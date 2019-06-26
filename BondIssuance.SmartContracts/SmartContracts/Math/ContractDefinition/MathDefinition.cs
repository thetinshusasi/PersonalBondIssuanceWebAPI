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

namespace SmartContracts.Contracts.Math.ContractDefinition
{


    public partial class MathDeployment : MathDeploymentBase
    {
        public MathDeployment() : base(BYTECODE) { }
        public MathDeployment(string byteCode) : base(byteCode) { }
    }

    public class MathDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x604c6023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea165627a7a72305820de2a21a5d5c07f0e4bc20315e18196573c299cdbbe398b8e6b980527fc7c74980029";
        public MathDeploymentBase() : base(BYTECODE) { }
        public MathDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
