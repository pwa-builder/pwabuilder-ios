using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Microsoft.PWABuilder.IOS.Web.Common
{
    public static class DirectoryInfoExtensions
    {
        public static void CopyContents(this DirectoryInfo source, DirectoryInfo target)
        {
            var directoriesToCopy = new Queue<(DirectoryInfo source, DirectoryInfo target)>();
            var enqueueSubdirectories = new Action<DirectoryInfo, DirectoryInfo>((currentSource, currentTarget) =>
            {
                // Create the target directory.
                Directory.CreateDirectory(currentTarget.FullName);

                // Copy each file into the new directory.
                foreach (var file in currentSource.EnumerateFiles())
                {
                    file.CopyTo(Path.Combine(currentTarget.FullName, file.Name), true);
                }

                // Enqueue the subdirectories.
                foreach (var subDir in currentSource.GetDirectories())
                {
                    var nextTargetSubDir = currentTarget.CreateSubdirectory(subDir.Name);
                    directoriesToCopy.Enqueue((subDir, nextTargetSubDir));
                }
            });

            enqueueSubdirectories(source, target);
            while (directoriesToCopy.Count > 0)
            {
                var (currentSrc, currentTarget) = directoriesToCopy.Dequeue();
                enqueueSubdirectories(currentSrc, currentTarget);
            }
        }
    }
}
