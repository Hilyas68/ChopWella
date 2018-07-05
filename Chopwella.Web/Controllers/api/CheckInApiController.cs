using Chopwella.Core;
using Chopwella.ServiceInterface;
using Chopwella.Web.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Chopwella.Web.Controllers.api
{
    [RoutePrefix("api/chopwella")]
    public class CheckInApiController : ApiController
    {
        private readonly IServices<CheckIn> _checkinservice;
        public CheckInApiController(IServices<CheckIn> checkinservice)
        {
            _checkinservice = checkinservice;
        }
        [Route("CheckInDetails")]
        [HttpGet]
        public HttpResponseMessage GetCheckIn()
        {
            try
            {
                var check = _checkinservice.GetAll();
                return this.Request.CreateResponse<IEnumerable<CheckIn>>(HttpStatusCode.Created, check);
            }
            catch (Exception message)
            {
                return this.Request.CreateResponse(HttpStatusCode.InternalServerError, message.Message);
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
                    Name = cvm.Name,
                    StaffId = cvm.Id,
                    IsChecked = true,
                    VendorId = 1
                };
                _checkinservice.Add(checkin);
                return Request.CreateResponse(HttpStatusCode.OK, "checked");

            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

        }
    }
}
