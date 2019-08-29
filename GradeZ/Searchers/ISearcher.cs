using System.IO;

namespace GradeZ.Searchers
{
    public interface ISearcher
    {
        bool IsReady { get; }
        string FoundAt { get; }
        bool Iterate(DirectoryInfo dir, string targetName);
        string GetDirectory();
    }
}
