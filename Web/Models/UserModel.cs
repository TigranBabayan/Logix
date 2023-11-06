using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Web.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        [MinLength(3)]
        [Required]
        public string FirstName { get; set; }

        [MinLength(3)]
        [Required]
        public string LastName { get; set; }

        [DataType(DataType.Date)]
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        [DisplayName("Date Of Birth")]
        public DateTime DateOfBirth { get; set; }
        public string FullName => $"{FirstName} {LastName}";

        [EmailAddress]
        [Required]
        public string Email { get; set; }

        [Required]
        [DisplayName("Phone Number")]
        [RegularExpression(@"^\(\d{3}\) \d{3}-\d{4}$", ErrorMessage = "Must be in this format (xxx) xxx-xxxx")]
        public string PhoneNumber { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        [PasswordPropertyText(true)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }

        public int? ClassId { get; set; }


    }
}
