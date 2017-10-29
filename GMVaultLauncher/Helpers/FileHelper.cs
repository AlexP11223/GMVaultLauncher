using System;
using System.IO;

namespace GMVaultLauncher.Helpers
{
    public static class FileHelper
    {
        /// <summary>
        /// Creates directory if not exist.
        /// </summary>
        /// <param name="filePath">File path (C:\dir\file.txt) or directory path (C:\dir\).</param>
        public static void CreateDirectoryIfNotExist(string filePath)
        {
            string dir = Path.GetDirectoryName(filePath);

            if (!String.IsNullOrEmpty(dir) && !Directory.Exists(dir))
            {
                Directory.CreateDirectory(dir);
            }
        }

        /// <summary>
        /// Deletes directory with all files inside
        /// </summary>
        /// <param name="dirPath">Directory path</param>
        public static void DeleteDirWithFiles(string dirPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);

            foreach (var file in dirInfo.GetFiles())
            {
                file.Delete();
            }

            foreach (var subdir in dirInfo.GetDirectories())
            {
                DeleteDirWithFiles(subdir.FullName);
            }

            Directory.Delete(dirPath);
        }
    }
}
