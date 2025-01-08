using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    /// <summary>
    /// Representa el modelo de datos para el inicio de sesión de un usuario.
    /// </summary>
    public class LoginModel
    {
        /// <summary>
        /// Obtiene o establece el correo electrónico del usuario.
        /// </summary>
        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string Email { get; set; }

        /// <summary>
        /// Obtiene o establece la contraseña del usuario.
        /// </summary>
        [Required(ErrorMessage = "Password is required.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Password must be between 6 and 100 characters.")]
        public string Password { get; set; }
    }
}
