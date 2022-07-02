from common import db

class User(db.Model):
    __tablename__ = "user"

    id = db.Column(db.Integer,primary_key = True)
    cnp = db.Column(db.String(20), unique = True)
    hash = db.Column(db.String(257))
    firstName= db.Column(db.String(100))
    lastName= db.Column(db.String(100))

    def to_dict(self):
        return {
            "hash": self.hash,
            "firstName": self.firstName,
            "lastName": self.lastName
        }
