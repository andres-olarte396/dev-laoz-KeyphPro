using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    /// <summary>
    /// Representa un modelo de métrica asociado a una evaluación.
    /// </summary>
    public class MetricModel : ModelBase<int>
    {
        /// <summary>
        /// Obtiene o establece el ID de la evaluación asociada a esta métrica.
        /// </summary>
        [Required]
        public int AssessmentId { get; set; } // Foreign Key

        /// <summary>
        /// Obtiene o establece el tipo de métrica (por ejemplo, Peso, Grasa Corporal, Masa Muscular, etc.).
        /// </summary>
        [Required]
        [StringLength(50, ErrorMessage = "Type must not exceed 50 characters.")]
        public string Type { get; set; } // e.g., Weight, Body Fat, Muscle Mass, etc.

        /// <summary>
        /// Obtiene o establece el valor de la métrica.
        /// </summary>
        [Required]
        [Range(0, 9999.99, ErrorMessage = "Value must be a valid decimal number.")]
        public decimal Value { get; set; }

        /// <summary>
        /// Obtiene o establece la evaluación asociada a esta métrica.
        /// </summary>
        public AssessmentModel Assessment { get; set; }
    }
}
