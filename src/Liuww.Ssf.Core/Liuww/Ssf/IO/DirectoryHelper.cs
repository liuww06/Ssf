using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Liuww.Ssf.IO
{
    public static class DirectoryHelper
    {
        public static void CreateIfNotExists(string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }
        public static bool IsSubDirectoryOf(string parentDirectoryPath, string childDirectoryPath)
        {
            return IsSubDirectoryOf(
                new DirectoryInfo(parentDirectoryPath),
                new DirectoryInfo(childDirectoryPath)
            );
        }

        public static bool IsSubDirectoryOf(DirectoryInfo parentDirectory, DirectoryInfo childDirectory)
        {
            if (parentDirectory.FullName == childDirectory.FullName)
            {
                return true;
            }

            var parentOfChild = childDirectory.Parent;
            if (parentOfChild == null)
            {
                return false;
            }

            return IsSubDirectoryOf(parentDirectory, parentOfChild);
        }
    }
}
