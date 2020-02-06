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

        [HttpGet]
        public IEnumerable<FieldViewModel> Get()
        {
            var conditions = new ConcurrentDictionary<string, string>();

            return service.GetAll(conditions);
        }

        [HttpGet("{id}")]
        public FieldViewModel Get(Guid id)
        {
            return service.GetById(id);
        }

        [HttpPost]
        public void Post([FromBody] FieldViewModel f)
        {
            if (f.Id == null)
            {
                f.Id = Guid.NewGuid().ToString();
            }

            // [TEMP] UserId 채우기
            f.User = GetCurrentUser();
            
            service.Create(f);
        }

        [HttpPut("{id}")]
        public void Put(string id, [FromBody] FieldViewModel f)
        {
            // [TEMP] UserId 채우기
            f.User = GetCurrentUser();

            service.Update(f);
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
