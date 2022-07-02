from flask_restful import Resource

from Models.Election import Election

class electionResources(Resource):

    def get(self):
        return [election.to_dict() for election in Election.query.all()]
