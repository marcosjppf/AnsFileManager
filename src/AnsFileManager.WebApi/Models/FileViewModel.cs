using AnsFileManager.Domain.Extensions;
using System.Collections.Generic;

namespace AnsFileManager.WebApi.Models
{
    public class FileViewModel
    {
        public FileViewModel(string fullName, string filePath, string idOs, int codSeqAnexo, int? codFuncionario)
        {
            FullName = fullName;
            FilePath = filePath;
            IdOs = idOs;
            CodFuncionario = codFuncionario;
            CodSeqAnexo = codSeqAnexo;
        }
        public string FullName { get; private set; }
        public string FilePath { get; private set; }
        public string IdOs { get; private set; }
        public int? CodFuncionario { get; private set; }
        public int CodSeqAnexo { get; private set; }

        public bool isValid()
            => NameIsValid() && FilePathIsValid() && CodFuncionarioIsValid() && CodSeqAnexoIsValid();

        private bool NameIsValid()
            => !string.IsNullOrWhiteSpace(FullName) && FileExtension.isValid(FullName);

        private bool FilePathIsValid()
            => string.IsNullOrWhiteSpace(FilePath) && FilePath.Length > 2;

        private bool CodSeqAnexoIsValid()
            => CodSeqAnexo > 0;

        private bool CodFuncionarioIsValid()
            => CodFuncionario > 0;
    }
}
