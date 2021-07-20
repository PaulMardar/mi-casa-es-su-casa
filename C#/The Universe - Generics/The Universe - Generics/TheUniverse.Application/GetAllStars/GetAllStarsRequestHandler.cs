using System.Collections.Generic;
using iQuest.TheUniverse.Domain;
using iQuest.TheUniverse.Infrastructure;

namespace iQuest.TheUniverse.Application.GetAllStars
{
    public class GetAllStarsRequestHandler : IRequestHandler<GetAllStarsRequest, List<StarInfo>>
    {
        public List<StarInfo> Execute(GetAllStarsRequest request)
        {
            var starsInfo = new List<StarInfo>();
            var galaxies = Universe.Instance.EnumerateGalaxies();

            foreach (var galaxy in galaxies)
            {
                var stars = galaxy.EnumerateStars();

                foreach (string star in stars)
                {
                    starsInfo.Add(new StarInfo
                    {
                        GalaxyName = galaxy.Name,
                        StarName = star
                    });

                }
            }

            return starsInfo;
        }
    }
}