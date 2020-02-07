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
        public void Post([FromBody] SourceViewModel s)
        {
            if (s.Id == null)
            {
                s.Id = Guid.NewGuid().ToString();
            }

            // [TEMP] UserId 채우기
            s.User = GetCurrentUser();

            service.Create(s);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] SourceViewModel s)
        {
            // [TEMP] UserId 채우기
            s.User = GetCurrentUser();

            service.Update(s);
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
