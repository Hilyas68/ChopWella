using System.ComponentModel.DataAnnotations;

namespace Chopwella.Core
{
    public class Staff : BaseEntity
    {
        //[Required]
        public string StaffNum { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
