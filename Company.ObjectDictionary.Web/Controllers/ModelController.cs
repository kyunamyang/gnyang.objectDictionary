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

        [HttpGet]
        public IEnumerable<ModelViewModel> Get(string startChar)
        {
            var conditions = new ConcurrentDictionary<string, string>();

            if(!string.IsNullOrEmpty(startChar))
            {
                conditions.TryAdd("StartChar", startChar);
            }

            return service.GetAll(conditions);
        }

        [HttpGet("{id}")]
        public ModelViewModel Get(Guid id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] ModelViewModel m)
        {
            if(m.Id == null)
            {
                m.Id = Guid.NewGuid().ToString();
            }

            // [TEMP] UserId 채우기
            m.User = GetCurrentUser();

            service.Create(m);
        }

        // PUT: api/Model/82928937-2279-4F8E-AF7B-5351E9580F71
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] ModelViewModel m)
        {
            // [TEMP] UserId 채우기
            m.User = GetCurrentUser();

            service.Update(m);
        }

        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            service.Delete(new Guid(id));
        }

        // [TEMP]
        private UserViewModel GetCurrentUser()
        {
            var user = new UserViewModel();
            user.Id = "302EFE24-DAA6-4C62-99D6-10DDFB4C1FB6";

            return user;
        }
    }
}
