from flask_jwt_extended import get_jwt, jwt_required
from flask_restful import Resource

from Models.TokenBlacklist import TokenBlacklist
from common import db


class Logout(Resource):


    @jwt_required()
    def post(self):
        JTI = get_jwt().get("jti")
        expiration = get_jwt().get("exp")
        db.session.add(TokenBlacklist(expiration=expiration, token=JTI))
        db.session.commit()
        return {"msg" : "Logout succesfull"}






