using System.Collections.Generic;
using System.Threading.Tasks;
using AnsFileManager.AppService;
using AnsFileManager.Domain.Entities;
using AnsFileManager.WebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System;

namespace AnsFileManager.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class AnsFileController : Controller
    {

        private readonly IAnsFileService _ansFileService;
        private readonly IFtpClientService _ftpClientService;

        public AnsFileController(IAnsFileService ansFileService, IFtpClientService ftpClientService)
        {
            _ansFileService = ansFileService;
            _ftpClientService = ftpClientService;
        }

        // GET api/AnsFile
        [HttpGet]
        public IEnumerable<FileViewModel> Get()
        {
            var ansFiles = _ansFileService.GetAll();
            var files = new List<FileViewModel>();
            if (ansFiles == null)
                return files;

            foreach (var item in ansFiles)
                files.Add(new FileViewModel(item.Id, item.File.FullName(), item.File.FilePath, item.File.FtpFilePath, item.IdOs, item.File.CodSeqAnexo, item.CodFuncionario));

            return files;
        }

        // GET api/AnsFile/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var model = await _ansFileService.GetByIdAsync(id);
            if (model == null)
                return BadRequest($"Invalid parameters");

            return new ObjectResult(
                new FileViewModel(model.Id,
                    model.File.FullName(),
                    model.File.FilePath,
                    model.File.FtpFilePath,
                    model.IdOs,
                    model.File.CodSeqAnexo,
                    model.CodFuncionario)
                );
        }

        // GET api/AnsFile/sended
        [HttpGet("{sended}")]
        public IEnumerable<FileViewModel> Get(bool sended)
        {
            var ansFiles = _ansFileService.GetByIsFileSended(sended);

            var files = new List<FileViewModel>();
            if (ansFiles == null)
                return files;

            foreach (var item in ansFiles)
                files.Add(new FileViewModel(item.Id, item.File.FullName(), item.File.FilePath, item.File.FtpFilePath, item.IdOs, item.File.CodSeqAnexo, item.CodFuncionario));

            return files;
        }

        // GET api/AnsFile/DocName/Os
        [HttpGet("{fullName}/{idOs}")]
        public IActionResult Get(string fullName, string idOs)
        {
            var model = new FileViewModel() { FullName = fullName, IdOs = idOs };

            if (!model.NameIsValid() && string.IsNullOrWhiteSpace(idOs))
                return BadRequest($"Invalid parameters");

            var ansFile = _ansFileService.getFileByIdOs(model.Name(), model.Extension(), idOs);

            return new ObjectResult(
                new FileViewModel(ansFile.Id,
                    ansFile.File.FullName(),
                    ansFile.File.FilePath,
                    ansFile.File.FtpFilePath,
                    ansFile.IdOs,
                    ansFile.File.CodSeqAnexo,
                    ansFile.CodFuncionario)
                );
        }

        // GET api/AnsFile/DocName/Os/CodFunc
        [HttpGet("{fullName}/{idOs}/{codFuncionario}")]
        public IActionResult Get(string fullName, string idOs, int codFuncionario)
        {
            var model = new FileViewModel() { FullName = fullName, IdOs = idOs, CodFuncionario = codFuncionario };

            if (!model.NameIsValid() && !model.IdOsIsValid() && !model.CodFuncionarioIsValid())
                return BadRequest($"Invalid parameters");

            var ansFile = _ansFileService.GetFileByEmployee(model.Name(), model.Extension(), idOs, codFuncionario);

            return new ObjectResult(
                new FileViewModel(ansFile.Id,
                    ansFile.File.FullName(),
                    ansFile.File.FilePath,
                    ansFile.File.FtpFilePath,
                    ansFile.IdOs,
                    ansFile.File.CodSeqAnexo,
                    ansFile.CodFuncionario)
                );
        }

        // POST api/AnsFile
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]FileViewModel model)
        {
            //string FilePath, string CodSeqAnexo, string FtpPath, string IdOs, string CodFuncionario
            try
            {
                if (!model.isValid())
                    return BadRequest($"Invalid parameters");

                var size = string.Empty;
                var ansFile = new AnsFile(model.IdOs, model.Name(), model.Extension(), size, model.FilePath, model.FtpPath, model.CodSeqAnexo);
                var ansFileCreated = await _ansFileService.CreateAsync(ansFile);

                if (ansFileCreated == null)
                    return NotFound($"Error: New File {model.FullName} not created");

                return Ok($"File Created!");
            }
            catch (Exception)
            {
                return NotFound($"Error: New File {model.FullName} not created");
            }
        }

        // DELETE api/AnsFile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var ansFile = await _ansFileService.GetByIdAsync(id);

                if (ansFile == null)
                    return NotFound($"File Id {id} does not exists.");

                await _ansFileService.DeleteAsync(id);

                return Ok($"File Id { ansFile.Id } deleted");
            }
            catch (Exception)
            {
                return NotFound($"Error: File {id} not deleted");
            }
        }

        // DELETE api/AnsFile/
        [HttpDelete()]
        public async Task<IActionResult> Delete()
        {
            try
            {
                await _ansFileService.DeleteAllFileSendedAsync();

                return Ok($"Files deleted");
            }
            catch (Exception)
            {
                return NotFound($"Error: Files not deleted");
            }
        }
    }
}
