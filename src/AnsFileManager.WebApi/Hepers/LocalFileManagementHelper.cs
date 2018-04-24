using System;
using System.IO;

namespace AnsFileManager.WebApi.Hepers
{
    public static class LocalFileManagementHelper
    {
        public static void DeleteLocalFile(string localFileLink)
        {
            try
            {
                if (File.Exists(localFileLink))
                    File.Delete(localFileLink);
            }
            catch (Exception)
            {
                throw;
            }
            
        }
    }
}
