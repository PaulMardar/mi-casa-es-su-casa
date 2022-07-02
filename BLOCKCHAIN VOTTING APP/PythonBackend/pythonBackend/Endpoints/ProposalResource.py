from flask_jwt_extended import jwt_required, get_jwt
from flask_restful import Resource

from Models.Proposal import Proposal
from Models.TokenBlacklist import TokenBlacklist


class ProposalResource(Resource):

    @jwt_required()
    def get(self):
        if TokenBlacklist.hasToken(get_jwt().get("jti")):
            return {"msg": "Invalid token"}, 403
        return [proposal.to_dict() for proposal in Proposal.query.all()]

