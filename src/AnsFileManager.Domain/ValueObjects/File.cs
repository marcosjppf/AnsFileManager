using AnsFileManager.Domain.Extensions;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AnsFileManager.Domain.ValueObjects
{
    public class File
    {
        public File(string fileName, string fileExtension, string size, string filePath, int codSeqAnexo)
        {
            FileName = fileName;
            Extension = fileExtension;
            Size = size;
            FilePath = filePath;
            CodSeqAnexo = codSeqAnexo;
        }
        
        [StringLength(100)]
        public string FileName { get; private set; }

        [StringLength(5)]
        public string Extension { get; private set; }
        
        [StringLength(10)]
        public string Size { get; private set; }

        [StringLength(255)]
        public string FilePath { get; private set; }

        [Column(TypeName = "number")]
        public int CodSeqAnexo { get; private set; }

        public string FullName()
            => string.Concat(FileName, ".", Extension);

        public bool isValid()
            => NameIsValid() && FilePathIsValid();

        private bool NameIsValid()
            => !string.IsNullOrWhiteSpace(FileName) && FileExtension.isValid(Extension);

        private bool FilePathIsValid()
            => string.IsNullOrWhiteSpace(FilePath) && (FilePath.Contains(@"\") || FilePath.Contains("/")) && FilePath.Length > 2;
    }
}
