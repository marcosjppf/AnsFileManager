using System.ComponentModel.DataAnnotations.Schema;
using System;
using AnsFileManager.Domain.ValueObjects;

namespace AnsFileManager.Domain.Entities
{
    [Table("AnsFiles")]
    public class AnsFile
    {
        public AnsFile(string idOs, string fileName, string fileExtension, string size, string filePath, int codSeqAnexo)
        {
            File = new File(fileName, fileExtension, size, filePath, codSeqAnexo);
            IdOs = idOs;
            CreatedOn = DateTime.Now;
        }

        [Column(TypeName = "number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public File File { get; set; }

        public string IdOs { get; private set; }

        [Column(TypeName = "number")]
        public int? CodFuncionario { get; set; }

        public DateTime CreatedOn { get; private set; }

        public DateTime? UpdatedOn { get; set; }

        public DateTime? SendedOn { get; set; }

        public bool IsFileSended()
            => SendedOn.HasValue;

        public bool IsValid()
            => File.isValid() && !string.IsNullOrWhiteSpace(IdOs) && CodFuncionario >= 0;
    }
}
