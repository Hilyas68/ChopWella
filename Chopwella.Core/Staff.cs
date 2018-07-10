using System.ComponentModel.DataAnnotations;

namespace Chopwella.Core
{
    public class Staff : BaseEntity, IDay
    {
        public string StaffNum { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
        public bool Monday { get; set; }
        public bool Tuesday { get; set; }
        public bool Wednesday { get; set; }
        public bool Thursday { get; set; }
        public bool Friday { get; set; }
    }
}
