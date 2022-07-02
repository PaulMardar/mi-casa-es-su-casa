from flask_restful import Resource

from Models.User import User

class UserResources(Resource):

    def get(self):
        return [user.to_dict() for user in User.query.all()]
