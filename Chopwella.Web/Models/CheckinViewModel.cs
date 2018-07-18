namespace Chopwella.Web.Models
{
    public class CheckinViewModel
    {
        public int Id { get; set; }
        public string StaffNum { get; set; }
        public string Name { get; set; }
        public int VendorId { get; set; }
        public string Email { get; set; }
        public int CategoryId { get; set; }
        public bool ischecked { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
    }
}