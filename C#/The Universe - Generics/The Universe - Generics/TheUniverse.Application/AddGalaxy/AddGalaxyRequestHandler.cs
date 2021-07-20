using System;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.AddGalaxy
{
    public class AddGalaxyRequestHandler : IRequestHandler<AddGalaxyRequest, Boolean>
    {
        public bool Execute(AddGalaxyRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }

            string galaxyName = request.GalaxyDetailsProvider.GetGalaxyName();
            return Universe.Instance.AddGalaxy(galaxyName);

        }
    }
}