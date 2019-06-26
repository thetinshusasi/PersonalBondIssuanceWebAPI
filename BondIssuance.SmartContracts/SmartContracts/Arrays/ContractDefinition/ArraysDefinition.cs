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

namespace SmartContracts.Contracts.Arrays.ContractDefinition
{


    public partial class ArraysDeployment : ArraysDeploymentBase
    {
        public ArraysDeployment() : base(BYTECODE) { }
        public ArraysDeployment(string byteCode) : base(byteCode) { }
    }

    public class ArraysDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x604c6023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea165627a7a72305820d81ef4f285acaf43c001dc3944290478674162e25d94c6d3e0fec4712158156f0029";
        public ArraysDeploymentBase() : base(BYTECODE) { }
        public ArraysDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
