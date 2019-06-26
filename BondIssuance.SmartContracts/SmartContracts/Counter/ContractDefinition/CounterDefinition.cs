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

namespace SmartContracts.Contracts.Counter.ContractDefinition
{


    public partial class CounterDeployment : CounterDeploymentBase
    {
        public CounterDeployment() : base(BYTECODE) { }
        public CounterDeployment(string byteCode) : base(byteCode) { }
    }

    public class CounterDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x604c6023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea165627a7a72305820e1bc47f6d6378ace6901121ed3127bc5b674e7331ca3ca1340ef370ecffff0340029";
        public CounterDeploymentBase() : base(BYTECODE) { }
        public CounterDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
