pragma solidity >=0.4.0 <0.7.0;

contract Sample {
    uint storedData;

    function setValueForX(uint x) public {
        storedData = x;
    }

    function getValueForX() public view returns (uint) {
        return storedData;
    }
}