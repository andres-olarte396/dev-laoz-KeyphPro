using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    public class UserModel : ModelBase<Guid>
    {
        [Required]
        [StringLength(50, ErrorMessage = "First Name must not exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must contain only letters.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Last Name must not exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name must contain only letters.")]
        public string LastName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        [Required]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [RegularExpression("Male|Female", ErrorMessage = "Gender must be 'Male' or 'Female'.")]
        public string Gender { get; set; } // Male, Female

        [Required]
        public DateTime RegistrationDate { get; set; }

        // Navigation Properties
        public ICollection<AssessmentModel> Assessments { get; set; } = new List<AssessmentModel>();
    }
}
