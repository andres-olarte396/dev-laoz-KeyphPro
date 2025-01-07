using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    public class MetricModel : ModelBase<int>
    {
        [Required]
        public int AssessmentId { get; set; } // Foreign Key

        [Required]
        [StringLength(50, ErrorMessage = "Type must not exceed 50 characters.")]
        public string Type { get; set; } // e.g., Weight, Body Fat, Muscle Mass, etc.

        [Required]
        [Range(0, 9999.99, ErrorMessage = "Value must be a valid decimal number.")]
        public decimal Value { get; set; }

        // Navigation Properties
        public AssessmentModel Assessment { get; set; }
    }
}
