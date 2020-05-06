using System.IO;

using Logger.Models.Interfaces;

namespace Logger.Models.IOManagement
{
    public class IOManager : IIOManager
    {
        private string CurrentPath;
        private string CurrentDirectory;
        private string CurrentFile;

        private IOManager()
        {
            this.CurrentPath = this.GetCurrentPath();
        }
        public IOManager(string currentDirectory, string currentFile)
        : this()
        {
            this.CurrentDirectory = currentDirectory;
            this.CurrentFile = currentFile;


        }

        public string CurrentDirectoryPath => this.CurrentPath + this.CurrentDirectory;
        public string CurrentFilePath => this.CurrentDirectoryPath + this.CurrentFile;

        

        public void EnsureDirectoryAndFileExistence()
        {
            if (!Directory.Exists(this.CurrentDirectoryPath))
            {
                Directory.CreateDirectory(this.CurrentDirectoryPath);
            }
            File.WriteAllText(this.CurrentFilePath,"");
        }

        public string GetCurrentPath()
        {
            return Directory.GetCurrentDirectory();
        }
    }
}
