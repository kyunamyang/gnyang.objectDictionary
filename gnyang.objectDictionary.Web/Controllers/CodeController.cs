using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using gnyang.objectDictionary.ViewModel;
using gnyang.objectDictionary.Service.Interface;

namespace gnyang.objectDictionary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodeController : Common.ControllerBase
    {
        private readonly ICodeService<CodeViewModel> service;

        public CodeController(ICodeService<CodeViewModel> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<CodeViewModel> Get()
        {
            throw new NotSupportedException();
        }

        [HttpGet("{id}")]
        public CodeViewModel Get(Guid id)
        {
            throw new NotSupportedException();
        }

        [HttpPost]
        public string Post([FromBody] CodeViewModel m)
        {
            return service.GetClassDefinition(m);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] CodeViewModel m)
        {
            throw new NotSupportedException();
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            throw new NotSupportedException();
        }
    }
}
