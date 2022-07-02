// SPDX-License-Identifier: GPL-3.0

pragma solidity ^0.8.4;

contract Referendum {
    

    address owner;
    
    mapping(string => bool) public registeredVoters;
    //maps the hash to and checks if the voter has voted already

    uint public yes;
    uint public no;
    uint public totalVoters;
    
    
    constructor() {
        owner = msg.sender;
        yes = 0;
        no = 0;
        totalVoters = 0;
    }
    


    function vote(bool _value, string memory voterId) public {

        if (registeredVoters[voterId] == true) {
            return;
        }
        
        if (_value == true) {
            yes += 1;
        } else {
            no += 1;
        }
        totalVoters += 1;
        registeredVoters[voterId] = true;
    }
    
    

}

