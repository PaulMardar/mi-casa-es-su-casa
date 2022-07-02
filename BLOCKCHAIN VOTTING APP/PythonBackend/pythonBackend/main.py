
from Endpoints.Login import Login
from Endpoints.Logout import Logout
from Endpoints.VoteProposal import VoteProposalResource
from Endpoints.VoteReferendumResource import VoteReferendumResource
from Endpoints.candidateResource import candidateResources
from Endpoints.electionResource import electionResources
from common import api, app, db
from Endpoints.userResources import UserResources
from Endpoints.ProposalResource import ProposalResource

db.create_all()

api.add_resource(UserResources,"/users")
api.add_resource(ProposalResource,"/proposals")
api.add_resource(candidateResources,"/candidate")
api.add_resource(electionResources, "/elections")
api.add_resource(Login, "/login")
api.add_resource(Logout, "/logout")
api.add_resource(VoteProposalResource, "/voteProposal/<id>")
api.add_resource(VoteReferendumResource, "/voteProposal/<id>/<vote>")
if __name__ == "__main__":
    app.run(debug=True, use_reloader=False)




