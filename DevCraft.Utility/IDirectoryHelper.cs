using System;

namespace DevCraft.Utility
{
    public interface IDirectoryHelper
    {
        void Mirror(string sourceDir, string destinationDir);
        void DeleteBefore(string dir, DateTime beforeDate);
    }
}