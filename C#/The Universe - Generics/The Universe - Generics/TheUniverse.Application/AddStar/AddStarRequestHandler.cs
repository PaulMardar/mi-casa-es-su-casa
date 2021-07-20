using System;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddStar
{
    public class AddStarRequestHandler : IRequestHandler<AddStarRequest, bool>
    {
        public bool Execute(AddStarRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string starName = request.StarDetailsProvider.GetStarName();
            string galaxyName = request.StarDetailsProvider.GetGalaxyName();

            return Universe.Instance.AddStar(starName, galaxyName);
        }
    }
}