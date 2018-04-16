using AnsFileManager.Domain.Extensions;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace AnsFileManager.WebApi.Models
{
    public class FileViewModel
    {
        public FileViewModel() { }

        public FileViewModel(int id, string fullName, string filePath, string ftpPath, string idOs, int codSeqAnexo, int? codFuncionario)
        {
            Id = id;
            FullName = fullName;
            FilePath = filePath;
            FtpPath = ftpPath;
            IdOs = idOs;
            CodFuncionario = codFuncionario;
            CodSeqAnexo = codSeqAnexo;
        }

        [Required]
        public int Id { get; set; }
        [Required]
        public string FullName { get; set; }
        [Required]
        public string FilePath { get; set; }
        public string FtpPath { get; set; }
        [Required]
        public string IdOs { get; set; }
        public int? CodFuncionario { get; set; }
        [Required]
        public int CodSeqAnexo { get; set; }

        public string Name()
            => Path.GetFileName(FullName);

        public string Extension()
            => Path.GetExtension(FullName);

        public string LocalFileLink()
            => string.Concat(FilePath, CodSeqAnexo, ".zip");

        public bool isValid()
            => NameIsValid() && FilePathIsValid() && CodFuncionarioIsValid() && CodSeqAnexoIsValid() && IdOsIsValid();

        public bool NameIsValid()
            => !string.IsNullOrWhiteSpace(FullName) && FileExtension.isValid(FullName);

        private bool FilePathIsValid()
            => string.IsNullOrWhiteSpace(FilePath) && FilePath.Length > 2;

        private bool CodSeqAnexoIsValid()
            => CodSeqAnexo > 0;

        public bool CodFuncionarioIsValid()
            => CodFuncionario > 0;

        public bool IdOsIsValid()
            => string.IsNullOrWhiteSpace(IdOs) && IdOs.Length > 2;
    }
}
