﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeZ.Searchers
{
    public class ExtensionSearcher : ISearcher
    {
        public bool IsReady { get; }
        public string FoundAt { get; }
        public bool Iterate(DirectoryInfo dir, string targetName)
        {
            throw new NotImplementedException();
        }

        public string GetDirectory()
        {
            throw new NotImplementedException();
        }

        public FileInfo File { get; }
    }
}
