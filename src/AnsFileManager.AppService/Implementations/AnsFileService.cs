using AnsFileManager.Domain.Entities;
using AnsFileManager.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AnsFileManager.AppService
{
    public class AnsFileService : IAnsFileService
    {
        private readonly IAnsFileRepository _ansFileRepository;

        public AnsFileService(IAnsFileRepository ansFileRepository)
        {
            _ansFileRepository = ansFileRepository;
        }

        public async Task<AnsFile> CreateAsync(AnsFile file)
        {
            if (!file.IsValid())
                return null;

            return await _ansFileRepository.CreateAsync(file);
        }

        public async Task DeleteAllFileSendedAsync()
        {
            await _ansFileRepository.DeleteAllFileSendedAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var file = await _ansFileRepository.GetByIdAsync(id);
            if (file != null)
                await _ansFileRepository.DeleteAsync(file);
        }

        public IEnumerable<AnsFile> GetAll()
        {
            return _ansFileRepository.GetAll();
        }

        public Task<AnsFile> GetByIdAsync(int id)
        {
            if (id <= 0)
                return null;

            return _ansFileRepository.GetByIdAsync(id);
        }

        public IEnumerable<AnsFile> GetByIsFileSended(bool sended)
        {
            return _ansFileRepository.GetByIsFileSended(sended);
        }

        public AnsFile GetFileByEmployee(string fileName, string fileExtension, string idOs, int codFuncionario)
        {
            return _ansFileRepository.GetFileByEmployee(fileName, fileExtension, idOs, codFuncionario);
        }

        public AnsFile getFileByIdOs(string fileName, string fileExtension, string idOs)
        {
            return _ansFileRepository.getFileByIdOs(fileName, fileExtension, idOs);
        }
    }
}
