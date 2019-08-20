using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GradeZ
{
    public class Searcher
    {
        private bool isready = false;
        private string foundAt = string.Empty;
        private int i = 0;
        private int length;

        public bool Iterate(DirectoryInfo dir, string targetName)
        {
            if (isready == true)
            {
                return true;
            }

            var directories = dir.GetDirectories();
            foreach (var folder in directories.Where(x => (x.Attributes & FileAttributes.Hidden) == 0))
            {
                length = dir.GetDirectories().Length;
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
