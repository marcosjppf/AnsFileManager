using System.Collections.Generic;

namespace AnsFileManager.Domain.Extensions
{
    public static class FileExtension
    {
        public static List<string> ValidExtensions 
            = new List<string> { ".gif", ".jpg", ".doc", ".txt", ".bat", ".ppt", ".zip", ".rar", ".jpg", ".iso", ".ini", ".dll" };

        public static bool isValid(string extension)
            => ValidExtensions.IndexOf(extension) > -1;
    }
}
