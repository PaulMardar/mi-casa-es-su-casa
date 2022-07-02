from WEB3.MoralisRPCProvider import Moralis
from common import db

class Proposal(db.Model):
    __tablename__ = "proposal"

    id = db.Column(db.Integer,primary_key = True)
    name = db.Column(db.String(256), unique = True)
    createdBy = db.Column(db.String(257))
    question = db.Column(db.String(257))
    isFinished = db.Column(db.Boolean)
    contractAddress = db.Column(db.String(257))


    def to_dict(self):
        m = Moralis(self.contractAddress)
        return {
            "id": self.id,
            "name": self.name,
            "createdBy": self.createdBy,
            "question": self.question,
            "yes":m.countYesVotes(),
            "no": m.countNoVotes(),
            "total": m.countTotalVotes(),
                }


    abi = '[{"inputs":[],"stateMutability":"nonpayable","type":"constructor"},{"inputs":[],"name":"no","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"string","name":"","type":"string"}],"name":"registeredVoters","outputs":[{"internalType":"bool","name":"","type":"bool"}],"stateMutability":"view","type":"function"},{"inputs":[],"name":"totalVoters","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"},{"inputs":[{"internalType":"bool","name":"_value","type":"bool"},{"internalType":"string","name":"voterId","type":"string"}],"name":"vote","outputs":[],"stateMutability":"nonpayable","type":"function"},{"inputs":[],"name":"yes","outputs":[{"internalType":"uint256","name":"","type":"uint256"}],"stateMutability":"view","type":"function"}]'