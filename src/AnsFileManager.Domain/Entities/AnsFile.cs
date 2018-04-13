using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace AnsFileManager.Domain.Entities
{
    [Table("AnsFiles")]
    public class AnsFile
    {
        public AnsFile(string fileName, string fileExtension, string idOs)
        {
            Name = fileName;
            FileExtension = fileExtension;
            IdOs = idOs;
        }

        [Column(TypeName = "number")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("FileName")]
        [StringLength(100)]
        public string Name { get; private set; }

        [StringLength(10)]
        public string FileExtension { get; private set; }

        public string IdOs { get; private set; }

        [StringLength(10)]
        public string Size { get; set; }
        
        [StringLength(255)]
        public string LocalPath { get; set; }

        [Column(TypeName = "number")]
        public int CodFuncionario { get; set; }

        [Column(TypeName = "number")]
        public int CodSeqAnexo { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.Now;

        public DateTime? UpdatedOn { get; set; }

        public DateTime? SendedOn { get; set; }

        public bool IsFileSended()
            => SendedOn.HasValue;

        public bool IsValid()
            => !string.IsNullOrWhiteSpace(Name) && !string.IsNullOrWhiteSpace(FileExtension) && !string.IsNullOrWhiteSpace(IdOs) && CodFuncionario >= 0;

        public bool IsNotValid()
            => string.IsNullOrWhiteSpace(Name) || string.IsNullOrWhiteSpace(FileExtension) || string.IsNullOrWhiteSpace(IdOs) || CodFuncionario <= 0;
    }
}
