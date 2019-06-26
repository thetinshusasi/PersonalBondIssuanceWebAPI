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

namespace SmartContracts.Contracts.ERC165Checker.ContractDefinition
{


    public partial class ERC165CheckerDeployment : ERC165CheckerDeploymentBase
    {
        public ERC165CheckerDeployment() : base(BYTECODE) { }
        public ERC165CheckerDeployment(string byteCode) : base(byteCode) { }
    }

    public class ERC165CheckerDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x604c6023600b82828239805160001a607314601657fe5b30600052607381538281f3fe73000000000000000000000000000000000000000030146080604052600080fdfea165627a7a72305820cd841c330c32df2179af653f4e52675b5305f4b403903b998e18ae2b538319650029";
        public ERC165CheckerDeploymentBase() : base(BYTECODE) { }
        public ERC165CheckerDeploymentBase(string byteCode) : base(byteCode) { }

    }
}
