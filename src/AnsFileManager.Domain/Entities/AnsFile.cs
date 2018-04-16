using System.ComponentModel.DataAnnotations.Schema;
using System;
using AnsFileManager.Domain.ValueObjects;
using System.ComponentModel.DataAnnotations;

namespace AnsFileManager.Domain.Entities
{
    [Table("AnsFiles")]
    public class AnsFile
    {
        public AnsFile(string idOs, string fileName, string fileExtension, string filePath, string ftpFilePath, int codSeqAnexo)
        {
            File = new File(fileName, fileExtension, filePath, ftpFilePath, codSeqAnexo);
            IdOs = idOs;
            CreatedOn = DateTime.Now;
        }

        [Key, Column("Id")]
        public int Id { get; set; }

        public File File { get; private set; }

        public string IdOs { get; private set; }

        [Column(TypeName = "number")]
        public int? CodFuncionario { get; set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? SendedOn { get; set; }

        public bool IsFileSended()
            => SendedOn.HasValue;

        public bool IsValid()
            => File.FileVOisValid() && !string.IsNullOrWhiteSpace(IdOs) && CodFuncionario >= 0;
    }
}
