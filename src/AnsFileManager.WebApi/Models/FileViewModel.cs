using System.Collections.Generic;

namespace AnsFileManager.WebApi.Models
{
    public class FileViewModel
    {
        private readonly List<string> ValidFilePaths = new List<string> { ".gif", ".jpg", ".doc", ".txt", ".bat", ".ppt", ".zip", ".rar", ".jpg", ".iso", ".ini", ".dll" };

        public FileViewModel(string fullName, string filePath, string idOs, int codFuncionario, int codSeqAnexo)
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
        public int CodFuncionario { get; private set; }
        public int CodSeqAnexo { get; private set; }

        public bool isValid()
            => NameIsValid() && FilePathIsValid() && CodFuncionarioIsValid() && CodSeqAnexoIsValid();

        private bool NameIsValid()
            => !string.IsNullOrWhiteSpace(FullName) && ValidFilePaths.IndexOf(FullName) > -1;

        private bool FilePathIsValid()
            => string.IsNullOrWhiteSpace(FilePath) && FilePath.Length > 2;

        private bool CodSeqAnexoIsValid()
            => CodSeqAnexo > 0;

        private bool CodFuncionarioIsValid()
            => CodFuncionario > 0;
    }
}
