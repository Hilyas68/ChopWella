using System;

namespace Chopwella.Core
{
    public class CheckIn : BaseEntity
    {
        public virtual Staff Staff { get; set; }
        public int StaffId { get; set; }
        public bool IsChecked { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int VendorId { get; set; }
    }
}
