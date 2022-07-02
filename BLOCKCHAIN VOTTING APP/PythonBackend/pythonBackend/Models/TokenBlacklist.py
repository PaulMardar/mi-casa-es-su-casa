from common import db


class TokenBlacklist(db.Model):
    __tablename__ = "tokenBlacklist"

    id = db.Column(db.Integer, primary_key=True)
    token = db.Column(db.String(256), unique=True, nullable=False)
    expiration = db.Column(db.BigInteger, nullable=False)

    @staticmethod
    def hasToken(token):
        token = TokenBlacklist.query.filter(TokenBlacklist.token == token).first()
        return True if token else False
