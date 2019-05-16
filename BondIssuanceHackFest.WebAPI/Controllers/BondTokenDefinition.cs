﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BondIssuanceHackFest.WebAPI.Controllers
{
    using System.Numerics;
    using global::Nethereum.ABI.FunctionEncoding.Attributes;
    using global::Nethereum.Contracts;

    namespace Nethereum.StandardTokenEIP20.ContractDefinition
    {
        public partial class EIP20Deployment : EIP20DeploymentBase
        {
            public EIP20Deployment() : base(BYTECODE) { }

            public EIP20Deployment(string byteCode) : base(byteCode) { }
        }

        public class EIP20DeploymentBase : ContractDeploymentMessage
        {

            public static string BYTECODE = "608060405234801561001057600080fd5b506040516107843803806107848339810160409081528151602080840151838501516060860151336000908152808552959095208490556002849055908501805193959094919391019161006991600391860190610096565b506004805460ff191660ff8416179055805161008c906005906020840190610096565b5050505050610131565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106100d757805160ff1916838001178555610104565b82800160010185558215610104579182015b828111156101045782518255916020019190600101906100e9565b50610110929150610114565b5090565b61012e91905b80821115610110576000815560010161011a565b90565b610644806101406000396000f3006080604052600436106100ae5763ffffffff7c010000000000000000000000000000000000000000000000000000000060003504166306fdde0381146100b3578063095ea7b31461013d57806318160ddd1461017557806323b872dd1461019c57806327e235e3146101c6578063313ce567146101e75780635c6581651461021257806370a082311461023957806395d89b411461025a578063a9059cbb1461026f578063dd62ed3e14610293575b600080fd5b3480156100bf57600080fd5b506100c86102ba565b6040805160208082528351818301528351919283929083019185019080838360005b838110156101025781810151838201526020016100ea565b50505050905090810190601f16801561012f5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b34801561014957600080fd5b50610161600160a060020a0360043516602435610348565b604080519115158252519081900360200190f35b34801561018157600080fd5b5061018a6103ae565b60408051918252519081900360200190f35b3480156101a857600080fd5b50610161600160a060020a03600435811690602435166044356103b4565b3480156101d257600080fd5b5061018a600160a060020a03600435166104b7565b3480156101f357600080fd5b506101fc6104c9565b6040805160ff9092168252519081900360200190f35b34801561021e57600080fd5b5061018a600160a060020a03600435811690602435166104d2565b34801561024557600080fd5b5061018a600160a060020a03600435166104ef565b34801561026657600080fd5b506100c861050a565b34801561027b57600080fd5b50610161600160a060020a0360043516602435610565565b34801561029f57600080fd5b5061018a600160a060020a03600435811690602435166105ed565b6003805460408051602060026001851615610100026000190190941693909304601f810184900484028201840190925281815292918301828280156103405780601f1061031557610100808354040283529160200191610340565b820191906000526020600020905b81548152906001019060200180831161032357829003601f168201915b505050505081565b336000818152600160209081526040808320600160a060020a038716808552908352818420869055815186815291519394909390927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925928290030190a350600192915050565b60025481565b600160a060020a03831660008181526001602090815260408083203384528252808320549383529082905281205490919083118015906103f45750828110155b15156103ff57600080fd5b600160a060020a038085166000908152602081905260408082208054870190559187168152208054849003905560001981101561046157600160a060020a03851660009081526001602090815260408083203384529091529020805484900390555b83600160a060020a031685600160a060020a03167fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef856040518082815260200191505060405180910390a3506001949350505050565b60006020819052908152604090205481565b60045460ff1681565b600160209081526000928352604080842090915290825290205481565b600160a060020a031660009081526020819052604090205490565b6005805460408051602060026001851615610100026000190190941693909304601f810184900484028201840190925281815292918301828280156103405780601f1061031557610100808354040283529160200191610340565b3360009081526020819052604081205482111561058157600080fd5b3360008181526020818152604080832080548790039055600160a060020a03871680845292819020805487019055805186815290519293927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef929181900390910190a350600192915050565b600160a060020a039182166000908152600160209081526040808320939094168252919091522054905600a165627a7a72305820a364c08a705d8b29603263ebff0569de6c90b2d665d056a3c77729e2eda923ef0029";

            public EIP20DeploymentBase() : base(BYTECODE) { }

            public EIP20DeploymentBase(string byteCode) : base(byteCode) { }

            [Parameter("uint256", "_initialAmount", 1)]
            public virtual BigInteger InitialAmount { get; set; }
            [Parameter("string", "_tokenName", 2)]
            public virtual string TokenName { get; set; }
            [Parameter("uint8", "_decimalUnits", 3)]
            public virtual byte DecimalUnits { get; set; }
            [Parameter("string", "_tokenSymbol", 4)]
            public virtual string TokenSymbol { get; set; }
        }

        public class BookRunner : ContractDeploymentMessage
        {
            public static string BYTECODE = "60806040523480156200001157600080fd5b50604051620011cd380380620011cd833981018060405260c08110156200003757600080fd5b8151602083018051919392830192916401000000008111156200005957600080fd5b820160208101848111156200006d57600080fd5b81518560208202830111640100000000821117156200008b57600080fd5b50509291906020018051640100000000811115620000a857600080fd5b82016020810184811115620000bc57600080fd5b8151640100000000811182820187101715620000d757600080fd5b50509291906020018051640100000000811115620000f457600080fd5b820160208101848111156200010857600080fd5b81516401000000008111828201871017156200012357600080fd5b50506020808301516040909301518651929550929350859185918591620001519160039190860190620002c0565b50815162000167906004906020850190620002c0565b506005805460ff191660ff929092169190911790555062000191905033620001e2602090811b901c565b8451620001a690601290602088019062000345565b50601380546001600160a01b039283166001600160a01b031991821617909155601480549790921696169590951790945550620003f292505050565b620001fd8160066200023460201b62000d0b1790919060201c565b6040516001600160a01b038216907f6ae172837ea30b801fbfcdd4108aa1d5bf8ff775444fd70256b44e6bf3dfc3f690600090a250565b6001600160a01b0381166200024857600080fd5b6200025a82826200028a60201b60201c565b156200026557600080fd5b6001600160a01b0316600090815260209190915260409020805460ff19166001179055565b60006001600160a01b038216620002a057600080fd5b506001600160a01b03166000908152602091909152604090205460ff1690565b828054600181600116156101000203166002900490600052602060002090601f016020900481019282601f106200030357805160ff191683800117855562000333565b8280016001018555821562000333579182015b828111156200033357825182559160200191906001019062000316565b5062000341929150620003ab565b5090565b8280548282559060005260206000209081019282156200039d579160200282015b828111156200039d57825182546001600160a01b0319166001600160a01b0390911617825560209092019160019091019062000366565b5062000341929150620003cb565b620003c891905b80821115620003415760008155600101620003b2565b90565b620003c891905b80821115620003415780546001600160a01b0319168155600101620003d2565b610dcb80620004026000396000f3fe608060405234801561001057600080fd5b50600436106101165760003560e01c806395d89b41116100a2578063a9059cbb11610071578063a9059cbb14610360578063aa271e1a1461038c578063d39fec73146103b2578063dd62ed3e14610414578063efe8b25a1461044257610116565b806395d89b41146102fe578063983b2d5614610306578063986502751461032c578063a457c2d71461033457610116565b8063313ce567116100e9578063313ce56714610228578063395093511461024657806340c10f191461027257806370a082311461029e5780638f70585f146102c457610116565b806306fdde031461011b578063095ea7b31461019857806318160ddd146101d857806323b872dd146101f2575b600080fd5b61012361044a565b6040805160208082528351818301528351919283929083019185019080838360005b8381101561015d578181015183820152602001610145565b50505050905090810190601f16801561018a5780820380516001836020036101000a031916815260200191505b509250505060405180910390f35b6101c4600480360360408110156101ae57600080fd5b506001600160a01b0381351690602001356104e0565b604080519115158252519081900360200190f35b6101e061055c565b60408051918252519081900360200190f35b6101c46004803603606081101561020857600080fd5b506001600160a01b03813581169160208101359091169060400135610562565b61023061062b565b6040805160ff9092168252519081900360200190f35b6101c46004803603604081101561025c57600080fd5b506001600160a01b038135169060200135610634565b6101c46004803603604081101561028857600080fd5b506001600160a01b0381351690602001356106e2565b6101e0600480360360208110156102b457600080fd5b50356001600160a01b0316610709565b6102fc600480360360808110156102da57600080fd5b506001600160a01b038135169060208101359060408101359060600135610724565b005b61012361093e565b6102fc6004803603602081101561031c57600080fd5b50356001600160a01b031661099f565b6102fc6109bd565b6101c46004803603604081101561034a57600080fd5b506001600160a01b0381351690602001356109c8565b6101c46004803603604081101561037657600080fd5b506001600160a01b038135169060200135610a11565b6101c4600480360360208110156103a257600080fd5b50356001600160a01b0316610a1e565b6103d8600480360360208110156103c857600080fd5b50356001600160a01b0316610a37565b604080516001600160a01b0396871681526020810195909552848101939093526060840191909152909216608082015290519081900360a00190f35b6101e06004803603604081101561042a57600080fd5b506001600160a01b0381358116916020013516610a74565b6101e0610a9f565b60038054604080516020601f60026000196101006001881615020190951694909404938401819004810282018101909252828152606093909290918301828280156104d65780601f106104ab576101008083540402835291602001916104d6565b820191906000526020600020905b8154815290600101906020018083116104b957829003601f168201915b5050505050905090565b60006001600160a01b0383166104f557600080fd5b3360008181526001602090815260408083206001600160a01b03881680855290835292819020869055805186815290519293927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925929181900390910190a350600192915050565b60025490565b6001600160a01b0383166000908152600160209081526040808320338452909152812054610596908363ffffffff610aa516565b6001600160a01b03851660009081526001602090815260408083203384529091529020556105c5848484610aba565b6001600160a01b0384166000818152600160209081526040808320338085529083529281902054815190815290519293927f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925929181900390910190a35060019392505050565b60055460ff1690565b60006001600160a01b03831661064957600080fd5b3360009081526001602090815260408083206001600160a01b038716845290915290205461067d908363ffffffff610b8516565b3360008181526001602090815260408083206001600160a01b0389168085529083529281902085905580519485525191937f8c5be1e5ebec7d5bd14f71427d1e84f3dd0314c0f7b2291e5b200ac8c7c3b925929081900390910190a350600192915050565b60006106ed33610a1e565b6106f657600080fd5b6107008383610b9e565b50600192915050565b6001600160a01b031660009081526020819052604090205490565b60005b601254811015610937576012818154811061073e57fe5b6000918252602090912001546001600160a01b031633141561092f576040805160a0810182526001600160a01b03808816808352602080840189905283850188905260608401879052336080909401849052600d80546001600160a01b031990811690931790819055600e8a8155600f8a815560108a81556011805487168917815560008981526007909652989094208054861693871693909317835590546001830155546002820155905460038201559354600494909401805490911693821693909317909255838602600c556013549091161461081c57600080fd5b60145460408051600160e01b6370a0823102815233600482015290516001600160a01b03909216916370a0823191602480820192602092909190829003018186803b15801561086a57600080fd5b505afa15801561087e573d6000803e3d6000fd5b505050506040513d602081101561089457600080fd5b5051600c54106108a357600080fd5b601454601354600c5460408051600160e01b63a9059cbb0281526001600160a01b039384166004820152602481019290925251919092169163a9059cbb9160448083019260209291908290030181600087803b15801561090257600080fd5b505af1158015610916573d6000803e3d6000fd5b505050506040513d602081101561092c57600080fd5b50505b600101610727565b5050505050565b60048054604080516020601f60026000196101006001881615020190951694909404938401819004810282018101909252828152606093909290918301828280156104d65780601f106104ab576101008083540402835291602001916104d6565b6109a833610a1e565b6109b157600080fd5b6109ba81610c46565b50565b6109c633610c8e565b565b60006001600160a01b0383166109dd57600080fd5b3360009081526001602090815260408083206001600160a01b038716845290915290205461067d908363ffffffff610aa516565b6000610700338484610aba565b6000610a3160068363ffffffff610cd616565b92915050565b6001600160a01b03908116600090815260076020526040902080546001820154600283015460038401546004909401549285169591949093921690565b6001600160a01b03918216600090815260016020908152604080832093909416825291909152205490565b600a5490565b600082821115610ab457600080fd5b50900390565b6001600160a01b038216610acd57600080fd5b6001600160a01b038316600090815260208190526040902054610af6908263ffffffff610aa516565b6001600160a01b038085166000908152602081905260408082209390935590841681522054610b2b908263ffffffff610b8516565b6001600160a01b038084166000818152602081815260409182902094909455805185815290519193928716927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef92918290030190a3505050565b600082820183811015610b9757600080fd5b9392505050565b6001600160a01b038216610bb157600080fd5b600254610bc4908263ffffffff610b8516565b6002556001600160a01b038216600090815260208190526040902054610bf0908263ffffffff610b8516565b6001600160a01b0383166000818152602081815260408083209490945583518581529351929391927fddf252ad1be2c89b69c2b068fc378daa952ba7f163c4a11628f55a4df523b3ef9281900390910190a35050565b610c5760068263ffffffff610d0b16565b6040516001600160a01b038216907f6ae172837ea30b801fbfcdd4108aa1d5bf8ff775444fd70256b44e6bf3dfc3f690600090a250565b610c9f60068263ffffffff610d5716565b6040516001600160a01b038216907fe94479a9f7e1952cc78f2d6baab678adc1b772d936c6583def489e524cb6669290600090a250565b60006001600160a01b038216610ceb57600080fd5b506001600160a01b03166000908152602091909152604090205460ff1690565b6001600160a01b038116610d1e57600080fd5b610d288282610cd6565b15610d3257600080fd5b6001600160a01b0316600090815260209190915260409020805460ff19166001179055565b6001600160a01b038116610d6a57600080fd5b610d748282610cd6565b610d7d57600080fd5b6001600160a01b0316600090815260209190915260409020805460ff1916905556fea165627a7a72305820e4cafad0d00f44ab0964c920e0c18e46c98eec802c5f67c9fa329cb8bbf24f380029";

            public BookRunner() : base(BYTECODE) { }

            public BookRunner(string byteCode) : base(byteCode) { }

            [Parameter("address", "token_address", 1)]
            public virtual string TokenAddress { get; set; }
            [Parameter("string", "_tokenName", 2)]
            public virtual string TokenName { get; set; }
            [Parameter("uint8", "_decimalUnits", 3)]
            public virtual byte DecimalUnits { get; set; }
            [Parameter("string", "_tokenSymbol", 4)]
            public virtual string TokenSymbol { get; set; }

        }

        public partial class NameFunction : NameFunctionBase { }

        [Function("name", "string")]
        public class NameFunctionBase : FunctionMessage
        {

        }

        public partial class ApproveFunction : ApproveFunctionBase { }

        [Function("approve", "bool")]
        public class ApproveFunctionBase : FunctionMessage
        {
            [Parameter("address", "_spender", 1)]
            public virtual string Spender { get; set; }
            [Parameter("uint256", "_value", 2)]
            public virtual BigInteger Value { get; set; }
        }

        public partial class TotalSupplyFunction : TotalSupplyFunctionBase { }

        [Function("totalSupply", "uint256")]
        public class TotalSupplyFunctionBase : FunctionMessage
        {

        }

        public partial class TransferFromFunction : TransferFromFunctionBase { }

        [Function("transferFrom", "bool")]
        public class TransferFromFunctionBase : FunctionMessage
        {
            [Parameter("address", "_from", 1)]
            public virtual string From { get; set; }
            [Parameter("address", "_to", 2)]
            public virtual string To { get; set; }
            [Parameter("uint256", "_value", 3)]
            public virtual BigInteger Value { get; set; }
        }

        public partial class BalancesFunction : BalancesFunctionBase { }

        [Function("balances", "uint256")]
        public class BalancesFunctionBase : FunctionMessage
        {
            [Parameter("address", "", 1)]
            public virtual string Address { get; set; }
        }

        public partial class DecimalsFunction : DecimalsFunctionBase { }

        [Function("decimals", "uint8")]
        public class DecimalsFunctionBase : FunctionMessage
        {

        }

        public partial class AllowedFunction : AllowedFunctionBase { }

        [Function("allowed", "uint256")]
        public class AllowedFunctionBase : FunctionMessage
        {
            [Parameter("address", "", 1)]
            public virtual string Owner { get; set; }
            [Parameter("address", "", 2)]
            public virtual string Spender { get; set; }
        }

        public partial class BalanceOfFunction : BalanceOfFunctionBase { }

        [Function("balanceOf", "uint256")]
        public class BalanceOfFunctionBase : FunctionMessage
        {
            [Parameter("address", "_owner", 1)]
            public virtual string Owner { get; set; }
        }

        public partial class SymbolFunction : SymbolFunctionBase { }

        [Function("symbol", "string")]
        public class SymbolFunctionBase : FunctionMessage
        {

        }

        public partial class TransferFunction : TransferFunctionBase { }

        [Function("transfer", "bool")]
        public class TransferFunctionBase : FunctionMessage
        {
            [Parameter("address", "_to", 1)]
            public virtual string To { get; set; }
            [Parameter("uint256", "_value", 2)]
            public virtual BigInteger Value { get; set; }
        }

        public partial class AllowanceFunction : AllowanceFunctionBase { }

        [Function("allowance", "uint256")]
        public class AllowanceFunctionBase : FunctionMessage
        {
            [Parameter("address", "_owner", 1)]
            public virtual string Owner { get; set; }
            [Parameter("address", "_spender", 2)]
            public virtual string Spender { get; set; }
        }

        public partial class TransferEventDTO : TransferEventDTOBase { }

        [Event("Transfer")]
        public class TransferEventDTOBase : IEventDTO
        {
            [Parameter("address", "_from", 1, true)]
            public virtual string From { get; set; }
            [Parameter("address", "_to", 2, true)]
            public virtual string To { get; set; }
            [Parameter("uint256", "_value", 3, false)]
            public virtual BigInteger Value { get; set; }
        }

        public partial class ApprovalEventDTO : ApprovalEventDTOBase { }

        [Event("Approval")]
        public class ApprovalEventDTOBase : IEventDTO
        {
            [Parameter("address", "_owner", 1, true)]
            public virtual string Owner { get; set; }
            [Parameter("address", "_spender", 2, true)]
            public virtual string Spender { get; set; }
            [Parameter("uint256", "_value", 3, false)]
            public virtual BigInteger Value { get; set; }
        }

        public partial class NameOutputDTO : NameOutputDTOBase { }

        [FunctionOutput]
        public class NameOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("string", "", 1)]
            public virtual string Name { get; set; }
        }



        public partial class TotalSupplyOutputDTO : TotalSupplyOutputDTOBase { }

        [FunctionOutput]
        public class TotalSupplyOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("uint256", "", 1)]
            public virtual BigInteger TotalSupply { get; set; }
        }



        public partial class BalancesOutputDTO : BalancesOutputDTOBase { }

        [FunctionOutput]
        public class BalancesOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("uint256", "", 1)]
            public virtual BigInteger Balance { get; set; }
        }

        public partial class DecimalsOutputDTO : DecimalsOutputDTOBase { }

        [FunctionOutput]
        public class DecimalsOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("uint8", "", 1)]
            public virtual byte Decimals { get; set; }
        }

        public partial class AllowedOutputDTO : AllowedOutputDTOBase { }

        [FunctionOutput]
        public class AllowedOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("uint256", "", 1)]
            public virtual BigInteger Amount { get; set; }
        }

        public partial class BalanceOfOutputDTO : BalanceOfOutputDTOBase { }

        [FunctionOutput]
        public class BalanceOfOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("uint256", "balance", 1)]
            public virtual BigInteger Balance { get; set; }
        }

        public partial class SymbolOutputDTO : SymbolOutputDTOBase { }

        [FunctionOutput]
        public class SymbolOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("string", "", 1)]
            public virtual string Symbol { get; set; }
        }

        public partial class AllowanceOutputDTO : AllowanceOutputDTOBase { }

        [FunctionOutput]
        public class AllowanceOutputDTOBase : IFunctionOutputDTO
        {
            [Parameter("uint256", "remaining", 1)]
            public virtual BigInteger Remaining { get; set; }
        }
    }
}