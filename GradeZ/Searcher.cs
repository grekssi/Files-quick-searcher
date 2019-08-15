using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradeZ
{
    public class Searcher
    {
        public static void Iterate(DirectoryInfo dir, string path)
        {
            foreach (var folder in dir.GetDirectories())
            {
                var files = folder.GetFiles();
                foreach (var fileInfo in files.Where(x => x.Extension == ".zip"
                                                          || x.Extension == ".docx"
                                                          || x.Extension == ".pptx"
                                                          || x.Extension == ".config"
                                                          || x.Extension == ".csproj"))
                {
                    Console.WriteLine("Deleting: " + fileInfo.Name);
                    File.SetAttributes(folder.FullName + "\\" + fileInfo.Name, FileAttributes.Normal);
                    File.Delete(folder.FullName + "\\" + fileInfo.Name);
                }
                if (folder.GetDirectories() != null)
                {
                    Iterate(new DirectoryInfo(folder.FullName), folder.FullName);
                }
            }
        }
    }
}
