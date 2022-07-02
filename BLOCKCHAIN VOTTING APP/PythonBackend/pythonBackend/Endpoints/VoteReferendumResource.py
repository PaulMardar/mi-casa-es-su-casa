
from flask_jwt_extended import jwt_required, get_jwt
from flask_restful import Resource, reqparse

from Models.Proposal import Proposal
from WEB3.MoralisRPCProvider import Moralis
from common import db


class VoteReferendumResource(Resource):

    parser = reqparse.RequestParser(bundle_errors = True)
    parser.add_argument("finished",type = bool, required = True)

    @jwt_required()
    def put(self,id,vote):
        proposal = Proposal.query.get(id)
        if not proposal:
            return {"msg" : "Proposal not found"}
        moralis = Moralis(proposal.contractAddress)
        moralis.castVote(vote,get_jwt().get("jti"))
        return proposal.to_dict()
