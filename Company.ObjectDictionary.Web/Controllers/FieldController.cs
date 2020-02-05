using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Concurrent;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Company.ObjectDictionary.ViewModel;
using Company.ObjectDictionary.Service.Interface;

namespace Company.ObjectDictionary.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FieldController : Common.ControllerBase
    {
        private readonly IGenericService<FieldViewModel> service;

        public FieldController(IGenericService<FieldViewModel> service)
        {
            this.service = service;
        }
        // GET: api/Field
        [HttpGet]
        public IEnumerable<FieldViewModel> Get()
        {
            var conditions = new ConcurrentDictionary<string, string>();

            return service.GetAll(conditions);
        }

        // GET: api/Field/82928937-2279-4F8E-AF7B-5351E9580F71
        [HttpGet("{id}")]
        public FieldViewModel Get(Guid id)
        {
            return service.GetById(id);
        }

        // POST: api/Field
        [HttpPost]
        public void Post([FromBody] FieldViewModel f)
        {
            service.Create(f);
        }

        // PUT: api/Field/82928937-2279-4F8E-AF7B-5351E9580F71
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] FieldViewModel f)
        {
            service.Update(f);
        }

        // DELETE: api/Field/82928937-2279-4F8E-AF7B-5351E9580F71
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Delete(new Guid(id));
        }
    }
}
