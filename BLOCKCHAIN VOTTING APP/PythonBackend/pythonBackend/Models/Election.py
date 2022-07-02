from common import db

class Election(db.Model):
    __tablename__ = "election"

    id = db.Column(db.Integer,primary_key = True)
    electionName = db.Column(db.String(256), unique = True)
    position = db.Column(db.String(257))
    candidates = db.relationship('Candidate', backref='election', lazy=True)

    def __repr__(self):
        return f'<Election "{self.electionName}">'

    def to_dict(self):
        return {
            "id": self.id,
            "electionName": self.electionName,
            "position": self.position,
            "candidates": [candidate.to_dict() for candidate in self.candidates]
                }
