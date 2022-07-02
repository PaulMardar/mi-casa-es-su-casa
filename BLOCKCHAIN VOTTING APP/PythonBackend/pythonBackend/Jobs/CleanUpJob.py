
from time import time



def cleanup():
    from common import db
    from Models.TokenBlacklist import TokenBlacklist
    for token in TokenBlacklist.query.filter(TokenBlacklist.expiration <= time()).all():
        db.session.delete(token)
    db.session.commit()
    print("TOKEN CLEANUP JOB PERFORMED !")





