pragma solidity ^0.5.0;

contract Hello {
    string public message;

     constructor () public{
        message = "Tinshu";
    }

    function setMessage (string memory newMessage) public {
        message = newMessage;        
    }

     function getMessage()  public view returns (string memory) {
        return message;
    }
}