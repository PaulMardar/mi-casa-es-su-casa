

from apscheduler.schedulers.background import BackgroundScheduler
from flask import Flask
from flask_cors import CORS
from flask_jwt_extended import JWTManager
from flask_restful import Api
from flask_sqlalchemy import SQLAlchemy

from Jobs.CleanUpJob import cleanup
from Jobs.ValidateVotesJob import checkValidity

app = Flask(__name__)
app.config["SQLALCHEMY_DATABASE_URI"] = "postgresql://postgres:paul@localhost:5432/postgres"
app.config['CORS_HEADERS'] = 'Content-Type'
app.config['JWT_SECRET_KEY']= 'wugaBugaApeToghederMakeStrongKey'
app.config['JWT_ACCESS_TOKEN_EXPIRES']= 300
db = SQLAlchemy(app)

api = Api(app)

jwt = JWTManager(app)


cors = CORS(app, resources={r"/*": {"origins": "*"}})





scheduler = BackgroundScheduler()
scheduler.add_job(func= cleanup,trigger="interval", seconds = 100)
scheduler.add_job(func= checkValidity,trigger="interval", seconds = 100)
scheduler.start()




