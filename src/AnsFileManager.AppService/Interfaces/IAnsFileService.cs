using AnsFileManager.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AnsFileManager.AppService
{
    public interface IAnsFileService
    {
        IEnumerable<AnsFile> GetAll();
        Task<AnsFile> GetByIdAsync(int id);
        IEnumerable<AnsFile> GetByIsFileSended(bool sended);
        AnsFile GetFileByEmployee(string fileName, string fileExtension, string idOs, int codFuncionario);
        AnsFile getFileByIdOs(string fileName, string fileExtension, string idOs);
        Task<AnsFile> CreateAsync(AnsFile ansFile);
        Task DeleteAsync(AnsFile file);
        Task DeleteAllFileSendedAsync();
    }
}
