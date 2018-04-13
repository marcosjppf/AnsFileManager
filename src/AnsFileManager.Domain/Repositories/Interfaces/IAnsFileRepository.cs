using AnsFileManager.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnsFileManager.Domain.Repositories
{
    public interface IAnsFileRepository
    {
        IEnumerable<AnsFile> GetAll();
        Task<AnsFile> GetByIdAsync(int id);
        IEnumerable<AnsFile> GetByIsFileSended(bool sended);
        AnsFile GetFileByEmployee(string fileName, string fileExtension, string idOs, int codFuncionario);
        Task<AnsFile> CreateAsync(AnsFile file);
        Task DeleteAsync(AnsFile file);
        Task DeleteAllFileSendedAsync();
        AnsFile getFileByIdOs(string fileName, string fileExtension, string idOs);
    }
}
