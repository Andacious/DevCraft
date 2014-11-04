using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace DevCraft.Utility
{
    public class DirectoryHelper : IDirectoryHelper
    {
        private static readonly IDirectoryHelper _instance = new DirectoryHelper();

        public static void DeleteBefore(string dir, DateTime beforeDate)
        {
            _instance.DeleteBefore(dir, beforeDate);
        }

        void IDirectoryHelper.DeleteBefore(string dir, DateTime beforeDate)
        {
            if (!Directory.Exists(dir)) return;

            // get all files in the top directory, does not do a deep delete
            List<string> directories = Directory.GetDirectories(dir, "*", SearchOption.TopDirectoryOnly).ToList();

            foreach (string d in directories)
            {
                DateTime creationDate = Directory.GetCreationTime(d);

                // if the creation date too early delete it
                if (creationDate < beforeDate)
                {
                    Directory.Delete(d, true);
                }
            }
        }

        public static void Mirror(string sourceDir, string destinationDir)
        {
            _instance.Mirror(sourceDir, destinationDir);
        }

        void IDirectoryHelper.Mirror(string sourceDir, string destinationDir)
        {
            if (!Directory.Exists(sourceDir)) throw new DirectoryNotFoundException(string.Format("The directory '{0}' could not be found and therefore could not be mirrored.", sourceDir));

            // Get the subdirectories for the specified directory.
            DirectoryInfo rootDirectory = new DirectoryInfo(sourceDir);
            DirectoryInfo[] childrenDirectories = rootDirectory.GetDirectories();

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            // Get the files in the directory and recursively copy them to the new location.
            FileInfo[] files = rootDirectory.GetFiles();

            foreach (FileInfo file in files)
            {
                file.CopyTo(Path.Combine(destinationDir, file.Name), false);
            }

            var dirHelper = (IDirectoryHelper)this;

            foreach (DirectoryInfo childDirectory in childrenDirectories)
            {
                // recurse and mirror child directories
                dirHelper.Mirror(childDirectory.FullName, Path.Combine(destinationDir, childDirectory.Name));
            }
        }
    }
}
