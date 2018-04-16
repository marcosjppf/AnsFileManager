using System;

namespace AnsFileManager.AppService
{
    public interface IFtpClientService
    {
        void CreateDirectory(string newDirectory);
        void Delete(string deleteFile);
        string[] DirectoryListDetailed(string directory);
        string[] DirectoryListSimple(string directory);
        void Download(string remoteFile, string localFile);
        DateTime GetDateFTP(string filename, string url);
        string GetFileCreatedDateTime(string fileName);
        string GetFileSize(string fileName);
        void Rename(string currentFileNameAndPath, string newFileName);
        void Upload(string remoteFile, string localFile);
    }
}