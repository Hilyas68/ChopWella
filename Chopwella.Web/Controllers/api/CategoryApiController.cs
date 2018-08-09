using Chopwella.Core;
using Chopwella.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]
    public class CategoryApiController : ApiController
    {
        private readonly IServices<Category> categoryservice;

        public CategoryApiController(IServices<Category> categoryservice)
        {
            this.categoryservice = categoryservice;
        }

        [Route("category")]
        public HttpResponseMessage GetCatetories()
        {
            try
            {
                var staff = categoryservice.GetAll();
                return this.Request.CreateResponse<IEnumerable<Category>>(HttpStatusCode.Created, staff);
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("addCategory")]
        [HttpPost]
        public HttpResponseMessage AddCategory([FromBody]Category c)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

                IEnumerable<Category> categories = categoryservice.GetAll();
                var checkCategory = categories.FirstOrDefault(m => m.Name == c.Name);

                if (checkCategory != null) return this.Request.CreateResponse(HttpStatusCode.Conflict, "Category Already Exist");

                categoryservice.Add(c);
                return this.Request.CreateResponse(HttpStatusCode.Created, "Added Successfully");
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        [Route("editCategory")]
        public HttpResponseMessage EditVendor([FromBody] Category v)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

                categoryservice.Edit(v);

                return this.Request.CreateResponse(HttpStatusCode.Created, "Updated Successfully");
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("deleteCategory/{Id}")]
        [HttpDelete]
        public HttpResponseMessage DeleteCategory(int Id)
        {
            try
            {
                var cat = categoryservice.GetSingle(Id);

                if (cat == null) return this.Request.CreateResponse(HttpStatusCode.Created, "Wrong CategoryId");

                categoryservice.Delete(cat);
                return this.Request.CreateResponse(HttpStatusCode.Created, "Deleted Successfully");
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
