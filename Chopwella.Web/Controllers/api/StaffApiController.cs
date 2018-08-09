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
    public class StaffApiController : ApiController
    {
        private readonly IServices<Staff> staffservice;
        //IRepository<Staff> repo = new ChopwellaRepo<Staff>();

        public StaffApiController(IServices<Staff> staffservice)
        {
            this.staffservice = staffservice;
        }


        [Route("staff")]
        public HttpResponseMessage GetStaff()
        {
            try
            {
                var staff = staffservice.GetAll();
                return this.Request.CreateResponse<IEnumerable<Staff>>(HttpStatusCode.Created, staff);
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("staffbyCat/{Id}")]
        public HttpResponseMessage GetStaffByCategory([FromUri]int Id)
        {
            try
            {
                IEnumerable<Staff> staff = staffservice.GetAll();
                var staffByCategory = staff.Where(m => m.CategoryId == Id).ToList();

                return this.Request.CreateResponse<IEnumerable<Staff>>(HttpStatusCode.Created, staffByCategory);
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("AddStaff")]
        [HttpPost]
        public HttpResponseMessage AddStaff([FromBody]Staff s)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

                IEnumerable<Staff> staff = staffservice.GetAll();
                var checkStaffNum = staff.FirstOrDefault(m => m.StaffNum == s.StaffNum);

                if (checkStaffNum != null) return this.Request.CreateResponse(HttpStatusCode.Conflict, "Staff Number Already Exist");

                staffservice.Add(s);
                return this.Request.CreateResponse(HttpStatusCode.Created, "Successful");
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }


        [Route("deleteStaff/{id}")]
        [HttpDelete]
        public HttpResponseMessage Delete(int id)
        {
            try
            {
                var staff = staffservice.GetSingle(id);
                staffservice.Delete(staff);
                staffservice.Save();
                return Request.CreateResponse(HttpStatusCode.OK, "Record has been successfully deleted");
            }

            catch (Exception ex)
            {

                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        [Route("editStaff")]
        [HttpPost]
        public HttpResponseMessage EditStaff(Staff staff)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return this.Request.CreateResponse(HttpStatusCode.BadRequest, "your fields are not valid");
                }

                staffservice.Edit(staff);

                return this.Request.CreateResponse(HttpStatusCode.Created, "Updated Successfully");
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [Route("reset")]
        [HttpPut]
        public HttpResponseMessage ResetStaffRecord()
        {
            try
            {
                var _staff = staffservice.GetAll();
                foreach (var staff in _staff)
                {
                    staff.Monday = false;
                    staff.Tuesday = false;
                    staff.Wednesday = false;
                    staff.Thursday = false;
                    staff.Friday = false;
                }
                staffservice.Save();

                return this.Request.CreateResponse(HttpStatusCode.Created, "Successful");
            }
            catch (Exception ex)
            {

                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
