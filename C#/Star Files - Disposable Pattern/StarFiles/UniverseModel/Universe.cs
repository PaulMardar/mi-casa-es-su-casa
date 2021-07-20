using System;
using System.Collections.Generic;

namespace iQuest.StarFiles.UniverseModel
{
    internal sealed class Universe : IDisposable
    {
        private readonly List<SimpleStar> stars = new List<SimpleStar>();

        private bool isDisposed = false;

        public string CreateStarFromTemplate(string name)
        {
            if (isDisposed == true)
            {
                throw new ObjectDisposedException("object is already disposed");
            }

            SimpleStar star = new SimpleStar(name);
            stars.Add(star);

            return star.FileName;
        }

        public Tuple<string, string> CreateBinaryStar(string name)
        {
            BinaryStar star = new BinaryStar(name);
            stars.Add(star);

            return new Tuple<string, string>(star.FileName, star.AdditionalFilename);
        }

        public void Dispose()
        {
            if (isDisposed)
                return;

            foreach (var star in stars)
            {
                star.Dispose();
            }
            isDisposed = true;
        }
    }
}