using Chopwella.Infrastructure.Identity;
using Chopwella.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    public class UserController : ApiController
    {
        private UserManager<AppUser, int> userMgr;
        private RoleManager<AppRole, int> roleMgr;

        public UserController()
        {
            userMgr = Startup.UserManagerFactory.Invoke();
            roleMgr = Startup.RoleManagerFactory.Invoke();
        }

        public async Task<HttpResponseMessage> CreateUser(UserViewModel model)
        {
            try
            {
                if (!this.ModelState.IsValid)
                {
                    this.Request.CreateResponse(HttpStatusCode.BadRequest);
                }

                var user = new AppUser
                {
                   UserName = model.UserName,
                   Email = model.Email
                };

                var result = await userMgr.CreateAsync(user, model.Password);
                if(!roleMgr.RoleExists(model.Role.Name))
                {
                    var role = new AppRole() { Name = model.Role.Name };
                    roleMgr.Create(role);
                }
                if (!userMgr.IsInRole(user.Id, model.Role.Name))
                {
                    userMgr.AddToRole(user.Id, model.Role.Name);
                }
                if (!result.Succeeded)
                {
                    this.Request.CreateResponse(HttpStatusCode.BadRequest, result.Errors.FirstOrDefault());
                }
                return this.Request.CreateResponse(HttpStatusCode.Created, "Successful");

            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
