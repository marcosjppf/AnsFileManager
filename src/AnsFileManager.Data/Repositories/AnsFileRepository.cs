using AnsFileManager.Data.Context;
using AnsFileManager.Domain.Entities;
using AnsFileManager.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AnsFileManager.Data.Repositories
{
    public class AnsFileRepository : IAnsFileRepository
    {
        private readonly AnsFileManagerOracleDbContext _oracleDbcontext;

        public AnsFileRepository(AnsFileManagerOracleDbContext oracleDbcontext)
        {
            _oracleDbcontext = oracleDbcontext;
        }

        public async Task<AnsFile> CreateAsync(AnsFile file)
        {
            var fileCreated = _oracleDbcontext.AnsFiles.Add(file);
            await _oracleDbcontext.SaveChangesAsync();
            return fileCreated;
        }

        public async Task DeleteAllFileSendedAsync()
        {
            var files = _oracleDbcontext.AnsFiles.Where(f => f.IsFileSended()).ToList<AnsFile>();
            foreach (var file in files)
                _oracleDbcontext.AnsFiles.Remove(file);
            await _oracleDbcontext.SaveChangesAsync();
        }

        public async Task DeleteAsync(AnsFile file)
        {
            _oracleDbcontext.AnsFiles.Remove(file);
            await _oracleDbcontext.SaveChangesAsync();
        }

        public IEnumerable<AnsFile> GetAll()
        {
            return _oracleDbcontext.AnsFiles.ToList();
        }

        public async Task<AnsFile> GetByIdAsync(int id)
        {
            return await _oracleDbcontext.AnsFiles.FindAsync(id);
        }

        public IEnumerable<AnsFile> GetByIsFileSended(bool sended)
        {
            return _oracleDbcontext.AnsFiles.Where(f => f.IsFileSended()).ToList<AnsFile>();
        }

        public AnsFile GetFileByEmployee(string fileName, string fileExtension, string idOs, int codFuncionario)
        {
            return _oracleDbcontext.AnsFiles
                .Where(f => f.Name == fileName && f.FileExtension == fileExtension && f.IdOs == idOs && f.CodFuncionario == codFuncionario)
                .FirstOrDefault<AnsFile>();
        }

        public AnsFile getFileByIdOs(string fileName, string fileExtension, string idOs)
        {
            return _oracleDbcontext.AnsFiles
                .Where(f => f.Name == fileName && f.FileExtension == fileExtension && f.IdOs == idOs)
                .FirstOrDefault<AnsFile>();
        }
    }
}
