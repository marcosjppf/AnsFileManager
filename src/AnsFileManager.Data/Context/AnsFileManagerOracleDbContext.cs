﻿using AnsFileManager.Data.Configurations;
using AnsFileManager.Domain.Entities;
using System.Data.Entity;

namespace AnsFileManager.Data.Context
{
    [DbConfigurationType(typeof(OracleConfiguration))]
    public class AnsFileManagerOracleDbContext : DbContext, IAnsFileManagerOracleDbContext
    {
        private readonly string _schema;

        public AnsFileManagerOracleDbContext(string conStr, string schema) :
            base(conStr)
        {
            _schema = schema;
        }

        public DbSet<AnsFile> AnsFiles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(_schema);
            modelBuilder.Entity<AnsFile>().Property(f => f.File.FileName).IsRequired();
            modelBuilder.Entity<AnsFile>().Property(f => f.File.FilePath).IsRequired();
            modelBuilder.Entity<AnsFile>().Property(f => f.File.Extension).IsRequired();
            modelBuilder.Entity<AnsFile>().Property(f => f.File.CodSeqAnexo).IsRequired();
            modelBuilder.Entity<AnsFile>().Property(f => f.File.Size).IsRequired();
            modelBuilder.Entity<AnsFile>().Property(f => f.CreatedOn).IsRequired();
            modelBuilder.Entity<AnsFile>().Property(f => f.IdOs).IsRequired();
            base.OnModelCreating(modelBuilder);
        }
    }
}
