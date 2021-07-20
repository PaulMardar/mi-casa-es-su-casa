using System;

namespace iQuest.StarFiles.UniverseModel
{
    /// <summary>
    /// Will generate a file on disk.
    /// </summary>

    internal class SimpleStar : IDisposable
    {
        protected WinApiFile File { get; private set; }

        public string Name { get; }

        public string FileName => File.FileName;

        private bool isDisposed = false;

        public SimpleStar(string name)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));

            CreateAndOpenFile();
        }

        private void CreateAndOpenFile()
        {
            Guid guid = Guid.NewGuid();
            string filePath = $"star-{guid:D}.txt";
            File = new WinApiFile(filePath);

            GenerateContent();
        }

        protected virtual void GenerateContent()
        {
            string content = $"This is the simple star named '{Name}'" + Environment.NewLine +
                "This star is made up mostly of Hydrogen and some Helium atoms." + Environment.NewLine;
            File.Write(content);
        }

        public virtual void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool dispose)
        {
            if (isDisposed)
                return;
            if (dispose)
                File.Dispose();
            isDisposed = true;
        }
    }
}