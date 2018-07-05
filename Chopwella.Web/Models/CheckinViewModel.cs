namespace Chopwella.Web.Models
{
    public class CheckinViewModel
    {
        public int Id { get; set; }
        public string StaffNum { get; set; }
        public string Name { get; set; }
        public int VendorId { get; set; }
        public bool ischecked { get; set; }
    }
}