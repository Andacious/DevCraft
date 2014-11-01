using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DevCraft.Utility
{
    public class DirectoryHelper : IDirectoryHelper
    {
        private static readonly IDirectoryHelper _instance = new DirectoryHelper();

        public static void Mirror(string sourceDir, string destinationDir)
        {
            _instance.Mirror(sourceDir, destinationDir);
        }

        public static void DeleteBefore(string dir, DateTime beforeDate)
        {
            _instance.DeleteBefore(dir, beforeDate);
        }

        void IDirectoryHelper.DeleteBefore(string dir, DateTime beforeDate)
        {
            if (!Directory.Exists(dir)) return;

            List<string> directories = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly).ToList();

            foreach (string d in directories)
            {
                DateTime creationDate = Directory.GetCreationTime(d);

                if (creationDate < beforeDate)
                {
                    Directory.Delete(d, true);
                }
            }
        }

        void IDirectoryHelper.Mirror(string sourceDir, string destinationDir)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo rootDirectory = new DirectoryInfo(sourceDir);
            DirectoryInfo[] childrenDirectories = rootDirectory.GetDirectories();

            if (!rootDirectory.Exists) return;

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = rootDirectory.GetFiles();

            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destinationDir, file.Name), false);
            }

            foreach (DirectoryInfo childDirectory in childrenDirectories)
            {
                ((IDirectoryHelper)this).Mirror(childDirectory.FullName, Path.Combine(destinationDir, childDirectory.Name));
            }
        }
    }
}
