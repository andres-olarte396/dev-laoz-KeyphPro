using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    public class AssessmentModel : ModelBase<int>
    {
        [Required]
        public int UserId { get; set; } // Foreign Key

        [Required]
        public DateTime Date { get; set; }

        [Required]
        [Range(30, 300, ErrorMessage = "Weight must be between 30 and 300 kg.")]
        public decimal Weight { get; set; }

        [Range(10, 50, ErrorMessage = "BMI must be between 10 and 50.")]
        public decimal BMI { get; set; } // Calculated property

        [Required]
        [Range(5, 50, ErrorMessage = "Body Fat Percentage must be between 5% and 50%.")]
        public decimal BodyFatPercentage { get; set; }

        [Required]
        [Range(20, 70, ErrorMessage = "Muscle Mass Percentage must be between 20% and 70%.")]
        public decimal MuscleMassPercentage { get; set; }

        [Range(500, 5000, ErrorMessage = "Daily Calories must be between 500 and 5000 kcal.")]
        public int DailyCalories { get; set; }

        [Required]
        [Range(70, 150, ErrorMessage = "Shoulder measurement must be between 70 and 150 cm.")]
        public decimal Shoulder { get; set; }

        [Required]
        [Range(20, 60, ErrorMessage = "Arm measurement must be between 20 and 60 cm.")]
        public decimal Arm { get; set; }

        [Required]
        [Range(50, 150, ErrorMessage = "Waist measurement must be between 50 and 150 cm.")]
        public decimal Waist { get; set; }

        [Required]
        [Range(70, 160, ErrorMessage = "Hip measurement must be between 70 and 160 cm.")]
        public decimal Hip { get; set; }

        [Required]
        [Range(40, 100, ErrorMessage = "Leg measurement must be between 40 and 100 cm.")]
        public decimal Leg { get; set; }

        [Required]
        [Range(20, 60, ErrorMessage = "Calf measurement must be between 20 and 60 cm.")]
        public decimal Calf { get; set; }

        [Required]
        [StringLength(20)]
        [RegularExpression("Normal|Altered|Not Measured", ErrorMessage = "Metabolic State must be 'Normal', 'Altered', or 'Not Measured'.")]
        public string MetabolicState { get; set; }

        // Navigation Properties
        public UserModel User { get; set; }

        public ICollection<MetricModel> Metrics { get; set; } = new List<MetricModel>();
    }
}
