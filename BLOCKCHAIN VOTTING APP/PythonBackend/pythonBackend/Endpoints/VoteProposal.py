from flask_jwt_extended import jwt_required
from flask_restful import Resource, reqparse

from Models.Proposal import Proposal
from common import db


class VoteProposalResource(Resource):

    parser = reqparse.RequestParser(bundle_errors = True)
    parser.add_argument("finished",type = bool, required = True)

    @jwt_required()
    def put(self,id):
        proposal = Proposal.query.get(id)
        data = VoteProposalResource.parser.parse_args()
        if not proposal:
            return {"msg" : "Proposal not found"}
        proposal.isFinished = data.get("finished")
        db.session.commit()
        return proposal.to_dict()


