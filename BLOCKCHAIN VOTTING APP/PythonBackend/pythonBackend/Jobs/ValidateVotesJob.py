
def checkValidity():
    from Models.Proposal import Proposal
    from WEB3.MoralisRPCProvider import Moralis
    for proposal in Proposal.query.all():
        m = Moralis(proposal.contractAddress)
        if m.checkValidityOfVotes() == False:
            print("VALIDITY FOR " +proposal.contractAddress + " IS CORRUPTED")

    print("VALIDITY Check JOB PERFORMED !")

