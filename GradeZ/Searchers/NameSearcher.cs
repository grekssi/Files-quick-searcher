﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace GradeZ.Searchers
{
    public class NameSearcher : ISearcher
    {
        public bool IsReady { get; private set; }
        public string FoundAt { get; private set; }
        public FileInfo File { get; private set; }
        public bool Iterate(DirectoryInfo dir, string targetName)
        {
            var directories = dir.GetDirectories();
            foreach (var folder in directories.Where(x => (x.Attributes & FileAttributes.Hidden) == 0))
            {
                var files = folder.GetFiles();
                foreach (var fileInfo in files)
                {
                    if (Path.GetFileNameWithoutExtension(fileInfo.Name) == targetName)
                    {
                        this.File = fileInfo;
                        FoundAt = folder.FullName;
                        IsReady = true;
                        return true;
                    }
                }

                if (IsReady == true)
                {
                    return true;
                }

                if (folder.GetDirectories() != null)
                {
                    Iterate(new DirectoryInfo(folder.FullName), targetName);
                    if (IsReady == true)
                    {
                        return true;
                    }
                }
            }

            if (IsReady == true)
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
            return this.FoundAt;
        }

    }
}
