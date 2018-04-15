using System.Collections.Generic;
using AnsFileManager.AppService;
using AnsFileManager.WebApi.Models;
using Microsoft.AspNetCore.Mvc;

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

        // GET api/values
        [HttpGet]
        public IEnumerable<FileViewModel> Get()
        {
            var ansFiles = _ansFileService.GetAll();
            var files = new List<FileViewModel>();
            if (ansFiles == null)
                return files;
            
            foreach (var item in ansFiles)
                files.Add(new FileViewModel(item.File.FullName(), item.File.FilePath, item.IdOs, item.File.CodSeqAnexo, item.CodFuncionario));

            return files;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
