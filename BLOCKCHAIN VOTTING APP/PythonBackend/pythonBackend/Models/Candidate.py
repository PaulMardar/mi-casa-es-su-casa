from common import db

class Candidate(db.Model):
    __tablename__ = "candidate"

    id = db.Column(db.Integer,primary_key = True)
    firstName= db.Column(db.String(100))
    lastName= db.Column(db.String(100))
    election_id = db.Column(db.Integer, db.ForeignKey('election.id'))

    def __repr__(self):
        return f'<Candidate "{self.firstName}...">'


    def to_dict(self):
        return {
            "firstName": self.firstName,
            "lastName": self.lastName
        }