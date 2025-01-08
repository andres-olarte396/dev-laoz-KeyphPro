using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    /// <summary>
    /// Representa un modelo de usuario con información personal y evaluaciones asociadas.
    /// </summary>
    public class UserModel : ModelBase<Guid>
    {
        /// <summary>
        /// Obtiene o establece el nombre del usuario.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "First Name must not exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "First Name must contain only letters.")]
        public string FirstName { get; set; }

        /// <summary>
        /// Obtiene o establece el apellido del usuario.
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Last Name must not exceed 50 characters.")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Last Name must contain only letters.")]
        public string LastName { get; set; }

        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece la fecha de nacimiento del usuario.
        /// </summary>
        [Required]
        public DateTime DateOfBirth { get; set; }

        /// <summary>
        /// Obtiene o establece el género del usuario.
        /// </summary>
        [Required]
        [RegularExpression("Male|Female", ErrorMessage = "Gender must be 'Male' or 'Female'.")]
        public string Gender { get; set; } // Male, Female

        /// <summary>
        /// Obtiene o establece la fecha de registro del usuario.
        /// </summary>
        [Required]
        public DateTime RegistrationDate { get; set; }

        /// <summary>
        /// Obtiene o establece las evaluaciones asociadas al usuario.
        /// </summary>
        public ICollection<AssessmentModel> Assessments { get; set; } = new List<AssessmentModel>();
    }
}