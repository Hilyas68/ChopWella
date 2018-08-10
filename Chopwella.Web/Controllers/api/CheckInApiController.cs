using Chopwella.Core;
using Chopwella.ServiceInterface;
using Chopwella.Web.Models;
using Microsoft.AspNet.Identity;
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
                var display = check.GroupBy(p => new { p.Staff.StaffNum, p.Staff.Name, p.VendorId }, p => p,
                    (key, g) => new
                    {
                        StaffId = key.StaffNum,
                        StaffName = key.Name,
                        VendorId = key.VendorId,
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
                var user = User.IsInRole("VENDOR");

                if (user)
                {
                    var checkin = new CheckIn
                    {

                        StaffId = cvm.Id,
                        IsChecked = true,
                        VendorId = int.Parse(User.Identity.GetUserId())
                    };

                    var Day = cvm.Day;
                    var staff = staffservices.GetSingle(cvm.Id);

                    if (staff != null)
                    {

                        switch (Day)
                        {

                            case 2:
                                if (staff.Monday != true)
                                {
                                    staff.Monday = true;
                                }

                                break;
                            case 3:
                                if (staff.Tuesday != true)
                                {
                                    staff.Tuesday = true;
                                }
                                break;
                            case 4:
                                if (staff.Wednesday != true)
                                {
                                    staff.Wednesday = true;
                                }
                                break;
                            case 5:
                                if (staff.Thursday != true)
                                {
                                    staff.Thursday = true;
                                }
                                break;
                            case 6:
                                if (staff.Friday != true)
                                {
                                    staff.Friday = true;
                                }
                                break;
                            default:

                                break;
                        }

                        UpdateStaff(staff);
                    }

                    _checkinservice.Add(checkin);
                }

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
