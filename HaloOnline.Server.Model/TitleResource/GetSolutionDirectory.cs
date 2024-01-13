using System;
using System.IO;
using System.Linq;

namespace HaloOnline.Server.Model.TitleResource
{
    public static class SolutionDirectoryGetter
    {
        public static string GetSolutionDirectory()
        {
            string assemblyDirectory = AppDomain.CurrentDomain.BaseDirectory;

            while (!Directory.GetFiles(assemblyDirectory, "*.sln").Any())
            {
                string parentDirectory = Directory.GetParent(assemblyDirectory)?.FullName;

                if (parentDirectory == null || parentDirectory == assemblyDirectory)
                {
                    throw new InvalidOperationException("Solution file not found.");
                }

                assemblyDirectory = parentDirectory;
            }

            return assemblyDirectory;
        }
    }
}
