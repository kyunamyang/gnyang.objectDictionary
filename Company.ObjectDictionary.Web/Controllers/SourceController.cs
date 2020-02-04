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
    public class SourceController : Common.ControllerBase
    {
        private readonly IGenericService<SourceViewModel> service;

        public SourceController(IGenericService<SourceViewModel> service)
        {
            this.service = service;
        }

        [HttpGet]
        public IEnumerable<SourceViewModel> Get()
        {
            var conditions = new ConcurrentDictionary<string, string>();

            return service.GetAll(conditions);
        }

        [HttpGet("{id}")]
        public SourceViewModel Get(Guid id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] SourceViewModel entity)
        {
            service.Create(entity);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] SourceViewModel entity)
        {
            service.Update(entity);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Delete(new Guid(id));
        }
    }
}
