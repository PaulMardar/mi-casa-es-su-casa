import requests
from flask_restful.representations import json


class Moralis:
    url = ''
    headers = {"Accept": "application/json",
               "x-api-key": "tteLpGrrZlDiMIsppzwEpUR15ixzeRIQnleknOB6RMTFjvCxlkfYDI9SxXCPMi5p",
               "Content-Type": "application/json"}

    data = {"abi" : [{"inputs":[],"stateMutability":"nonpayable","type":"constructor"},{"inputs":[{"internalType":"bool","name":"_value","type":"bool"},{"internalType":"string","name":"voterId","type":"string"}],"name":"vote","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"no","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"string","name":"","type":"string"}],"name":"registeredVoters","outputs":[{"internalType":"bool","name":"","type":"bool"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"totalVoters","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"yes","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"}]}

    def __init__(self,address):
        self.url= "https://deep-index.moralis.io/api/v2/"+ address + "/function?chain=avalanche%20testnet&function_name="

    def countYesVotes(self):
        response = requests.post(self.url+"yes", data=json.dumps(self.data), headers=self.headers)
        # print("Status Code", response.status_code)
        # print("JSON Response ", response.json())
        return response.json()

    def countNoVotes(self):
        response = requests.post(self.url+"no", data=json.dumps(self.data), headers=self.headers)
        return response.json()

    def countTotalVotes(self):
        response = requests.post(self.url+"totalVoters", data=json.dumps(self.data), headers=self.headers)
        return response.json()

    def checkValidityOfVotes(self):
        return int(self.countYesVotes())+ int(self.countNoVotes()) == int(self.countTotalVotes())

    def castVote(self,vote,signature):
        response = requests.post(self.url + "vote()", data=json.dumps(self.data +{"params" : {vote, signature} }), headers=self.headers)
        return response.json()

