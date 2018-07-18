using Chopwella.Core;
using Chopwella.ServiceInterface;
using Chopwella.Web.Models;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]
    public class CheckInApiController : ApiController
    {
        private readonly IServices<CheckIn> _checkinservice;
        private readonly IServices<Staff> staffservices;
        private readonly IServices<Vendor> vendorservices;
        public CheckInApiController(IServices<CheckIn> checkinservice, IServices<Staff> staffservices, IServices<Vendor> vendorservices)
        {
            _checkinservice = checkinservice;
            this.staffservices = staffservices;
            this.vendorservices = vendorservices;
        }
        [Route("CheckInDetails")]
        [HttpGet]
        public HttpResponseMessage GetCheckIn()
        {
            try
            {
                var check = _checkinservice.GetAll();
                var display = check.GroupBy(p => new { p.Staff.StaffNum, p.Staff.Name,p.VendorId }, p => p,
                    (key, g) => new{
                    StaffId = key.StaffNum,
                    StaffName = key.Name,
                    VendorId=key.VendorId,
                    CheckCount = g.Count()
                });
                
                return this.Request.CreateResponse(HttpStatusCode.Created, display);
            }
            catch (Exception ex)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

      
        [HttpPost]
        [Route("AddtoCheckin")]
        public HttpResponseMessage AddCheckin(CheckinViewModel cvm)
        {
            try
            {
                   var checkin = new CheckIn
                {
                   // Name = cvm.Name,
                    StaffId = cvm.Id,
                    IsChecked = true,
                    VendorId = 1
                };

                var staff = new Staff
                {
                    Monday = cvm.Monday,
                    Tuesday = cvm.Tuesday,
                    Wednesday = cvm.Wednesday,
                    Thursday = cvm.Thursday,
                    Friday = cvm.Friday,
                    CategoryId = cvm.CategoryId,
                    Name = cvm.Name,
                    StaffNum = cvm.StaffNum,
                    Id = cvm.Id,
                    Email = cvm.Email
                };

                UpdateStaff(staff);



               

                _checkinservice.Add(checkin);
                return Request.CreateResponse(HttpStatusCode.OK, "checked");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }

        public void UpdateStaff(Staff staff)
        {
            staffservices.Edit(staff);
        }
       
    }
}
