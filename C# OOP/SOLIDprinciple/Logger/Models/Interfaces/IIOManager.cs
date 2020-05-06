

namespace Logger.Models.Interfaces
{
    public interface IIOManager
    {
        string CurrentDirectoryPath { get; }

        string CurrentFilePath { get; }

        void EnsureDirectoryAndFileExistence();

        string GetCurrentPath();

    }
}
