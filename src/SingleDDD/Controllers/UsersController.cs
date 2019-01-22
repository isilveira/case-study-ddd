using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SingleDDD.Core.Application.Services;
using SingleDDD.Core.Domain.Entities;
using SingleDDD.Models.UserViewModels;

namespace SingleDDD.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private UserApplicationService UserApplicationService { get; set; }
        public UsersController(
            UserApplicationService userApplicationService
        )
        {
            UserApplicationService = userApplicationService;
        }
        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<User>> Get([FromQuery]GetUserViewModel request)
        {
            return UserApplicationService.GetByFilter(request.Extract());
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<User> Get(long id)
        {
            return UserApplicationService.GetByID(id);
        }

        // POST api/values
        [HttpPost]
        public ActionResult<User> Post([FromBody] PostUserViewModel model)
        {
            try
            {
                var user = UserApplicationService.Create(model.email, model.password);
                return user;
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public ActionResult<User> Put(long id, [FromBody] PutUserViewModel model)
        {
            try
            {
                var user = UserApplicationService.Update(id, model.email, model.password);
                return user;
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(long id)
        {
            try
            {
                UserApplicationService.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        [HttpPost("{id}/[action]")]
        public ActionResult<User> Deactivate(long id)
        {
            try
            {
                var user = UserApplicationService.Deactivate(id);
                return user;
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }

        [HttpPost("{id}/[action]")]
        public ActionResult<User> Activate(long id)
        {
            try
            {
                var user = UserApplicationService.Activate(id);
                return user;
            }
            catch (Exception ex)
            {
                return UnprocessableEntity(ex);
            }
        }
    }
}
