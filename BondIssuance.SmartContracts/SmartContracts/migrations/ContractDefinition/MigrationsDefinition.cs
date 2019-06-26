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

namespace SmartContracts.Contracts.Migrations.ContractDefinition
{


    public partial class MigrationsDeployment : MigrationsDeploymentBase
    {
        public MigrationsDeployment() : base(BYTECODE) { }
        public MigrationsDeployment(string byteCode) : base(byteCode) { }
    }

    public class MigrationsDeploymentBase : ContractDeploymentMessage
    {
        public static string BYTECODE = "0x608060405234801561001057600080fd5b50336000806101000a81548173ffffffffffffffffffffffffffffffffffffffff021916908373ffffffffffffffffffffffffffffffffffffffff1602179055506102ae806100606000396000f3fe608060405234801561001057600080fd5b506004361061004c5760003560e01c80630900f01014610051578063445df0ac146100955780638da5cb5b146100b3578063fdacd576146100fd575b600080fd5b6100936004803603602081101561006757600080fd5b81019080803573ffffffffffffffffffffffffffffffffffffffff16906020019092919050505061012b565b005b61009d6101f7565b6040518082815260200191505060405180910390f35b6100bb6101fd565b604051808273ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff16815260200191505060405180910390f35b6101296004803603602081101561011357600080fd5b8101908080359060200190929190505050610222565b005b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff1614156101f45760008190508073ffffffffffffffffffffffffffffffffffffffff1663fdacd5766001546040518263ffffffff1660e01b815260040180828152602001915050600060405180830381600087803b1580156101da57600080fd5b505af11580156101ee573d6000803e3d6000fd5b50505050505b50565b60015481565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1681565b6000809054906101000a900473ffffffffffffffffffffffffffffffffffffffff1673ffffffffffffffffffffffffffffffffffffffff163373ffffffffffffffffffffffffffffffffffffffff16141561027f57806001819055505b5056fea165627a7a723058202117a366b810d8398788ca2cc6d1629fe385f1157e9af78fc5fd20819e4ba6570029";
        public MigrationsDeploymentBase() : base(BYTECODE) { }
        public MigrationsDeploymentBase(string byteCode) : base(byteCode) { }

    }

    public partial class Last_completed_migrationFunction : Last_completed_migrationFunctionBase { }

    [Function("last_completed_migration", "uint256")]
    public class Last_completed_migrationFunctionBase : FunctionMessage
    {

    }

    public partial class OwnerFunction : OwnerFunctionBase { }

    [Function("owner", "address")]
    public class OwnerFunctionBase : FunctionMessage
    {

    }

    public partial class SetCompletedFunction : SetCompletedFunctionBase { }

    [Function("setCompleted")]
    public class SetCompletedFunctionBase : FunctionMessage
    {
        [Parameter("uint256", "completed", 1)]
        public virtual BigInteger Completed { get; set; }
    }

    public partial class UpgradeFunction : UpgradeFunctionBase { }

    [Function("upgrade")]
    public class UpgradeFunctionBase : FunctionMessage
    {
        [Parameter("address", "new_address", 1)]
        public virtual string New_address { get; set; }
    }

    public partial class Last_completed_migrationOutputDTO : Last_completed_migrationOutputDTOBase { }

    [FunctionOutput]
    public class Last_completed_migrationOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("uint256", "", 1)]
        public virtual BigInteger ReturnValue1 { get; set; }
    }

    public partial class OwnerOutputDTO : OwnerOutputDTOBase { }

    [FunctionOutput]
    public class OwnerOutputDTOBase : IFunctionOutputDTO 
    {
        [Parameter("address", "", 1)]
        public virtual string ReturnValue1 { get; set; }
    }




}
