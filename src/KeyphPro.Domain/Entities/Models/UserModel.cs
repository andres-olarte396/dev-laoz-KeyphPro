using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    public class UserModel : ModelBase<Guid>
    {
        [Required]
        [StringLength(100, ErrorMessage = "Full Name must not exceed 100 characters.")]
        public string FullName { get; set; }

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
