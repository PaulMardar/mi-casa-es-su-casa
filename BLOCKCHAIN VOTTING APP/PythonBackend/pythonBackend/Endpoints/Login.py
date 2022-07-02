from flask_jwt_extended import create_access_token
from flask_restful import Resource, reqparse

from Models.User import User


class Login(Resource):

    parser = reqparse.RequestParser(bundle_errors = True)
    parser.add_argument("hash",type = str, required = True)


    def post(self):
        data = Login.parser.parse_args()
        user = User.query.filter(User.hash == data.get("hash")).first()
        if user:
            accessToken = create_access_token(user.id)
            return {"token": accessToken}
        return {"message": "User not found"}



