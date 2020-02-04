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
    public class ModelController : Common.ControllerBase
    {
        private readonly IGenericService<ModelViewModel> service;
        
        public ModelController(IGenericService<ModelViewModel> service)
        {
            this.service = service;
        }
        // GET: api/Model
        [HttpGet]
        public IEnumerable<ModelViewModel> Get()
        {
            var conditions = new ConcurrentDictionary<string, string>();

            return service.GetAll(conditions);
        }

        // GET: api/Model/82928937-2279-4F8E-AF7B-5351E9580F71
        [HttpGet("{id}")]
        public ModelViewModel Get(Guid id)
        {
            return service.GetById(id);
        }

        // POST: api/Model
        [HttpPost]
        public void Post([FromBody] ModelViewModel entity)
        {
            service.Create(entity);
        }

        // PUT: api/Model/82928937-2279-4F8E-AF7B-5351E9580F71
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] ModelViewModel entity)
        {
            service.Update(entity);
        }

        // DELETE: api/Model/82928937-2279-4F8E-AF7B-5351E9580F71
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Delete(new Guid(id));
        }
    }
}
