using AnsFileManager.Domain.Entities;
using System.Data.Entity;

namespace AnsFileManager.Data.Context
{
    public interface IAnsFileManagerOracleDbContext
    {
        DbSet<AnsFile> AnsFiles { get; set; }
    }
}
