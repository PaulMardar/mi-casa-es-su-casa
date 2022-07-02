from flask_restful import Resource

from Models.Candidate import Candidate

class candidateResources(Resource):

    def get(self):
        return [candidate.to_dict() for candidate in Candidate.query.all()]
