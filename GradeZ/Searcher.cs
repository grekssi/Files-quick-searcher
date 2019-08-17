using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;

namespace GradeZ
{
    public class Searcher
    {
        private bool isready = false;
        private string foundAt = string.Empty;

        public bool Iterate(DirectoryInfo dir, string targetName)
        {
            if (isready == true)
            {
                isready = false;
            }
            foreach (var folder in dir.GetDirectories())
            {
                if (isready == true)
                {
                    return true;
                }
                var files = folder.GetFiles();
                foreach (var fileInfo in files)
                {
                    if (Path.GetFileNameWithoutExtension(fileInfo.Name) == targetName)
                    {
                        foundAt = folder.FullName;
                        isready = true;
                        return true;
                    }
                }

                if (isready == true)
                {
                    return true;
                }

                if (folder.GetDirectories() != null)
                {
                    Iterate(new DirectoryInfo(folder.FullName), targetName);
                    if (isready == true)
                    {
                        return true;
                    }
                }
            }

            if (isready == true)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public string GetDirectory()
        {
            return this.foundAt;
        }
    }
}
