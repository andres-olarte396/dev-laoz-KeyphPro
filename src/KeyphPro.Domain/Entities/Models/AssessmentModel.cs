using KeyphPro.Domain.Entities.Commond;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    /// <summary>
    /// Representa un modelo de evaluación con varias métricas y propiedades relacionadas con la salud.
    /// </summary>
    public class AssessmentModel : ModelBase<int>
    {
        /// <summary>
        /// Obtiene o establece el ID del usuario asociado a esta evaluación.
        /// </summary>
        [Required]
        public Guid UserId { get; set; } // Foreign Key

        /// <summary>
        /// Obtiene o establece el ID del usuario asociado al entrenador.
        /// </summary>
        [Required]
        public Guid CoachId { get; set; } // Foreign Key

        /// <summary>
        /// Obtiene o establece la fecha de la evaluación.
        /// </summary>
        [Required]
        public DateTime Date { get; set; }

        /// <summary>
        /// Obtiene o establece el peso del usuario en kilogramos.
        /// </summary>
        [Required]
        [Range(30, 300, ErrorMessage = "Weight must be between 30 and 300 kg.")]
        public decimal Weight { get; set; }

        /// <summary>
        /// Obtiene o establece la altura del usuario en centímetros.
        /// </summary>
        [Required]
        [Range(100, 200, ErrorMessage = "Heigth must be between 100 and 200 cm.")]
        public decimal Heigth { get; set; }

        /// <summary>
        /// Obtiene o establece el índice de masa corporal (IMC) del usuario.
        /// </summary>
        [Range(10, 50, ErrorMessage = "BMI must be between 10 and 50.")]
        public decimal BMI { get; set; } // Calculated property

        /// <summary>
        /// Obtiene o establece el porcentaje de grasa corporal del usuario.
        /// </summary>
        [Required]
        [Range(5, 50, ErrorMessage = "Body Fat Percentage must be between 5% and 50%.")]
        public decimal BodyFatPercentage { get; set; }

        /// <summary>
        /// Obtiene o establece el porcentaje de grasa viseral del usuario.
        /// </summary>
        /// <value>
        /// The viseral fat.
        /// </value>
        [Required]
        [Range(5, 50, ErrorMessage = "Viseral Fat Percentage must be between 5% and 50%.")]
        public decimal ViseralFat { get; set; }

        /// <summary>
        /// Obtiene o establece el porcentaje de masa muscular del usuario.
        /// </summary>
        [Required]
        [Range(20, 70, ErrorMessage = "Muscle Mass Percentage must be between 20% and 70%.")]
        public decimal MuscleMassPercentage { get; set; }

        /// <summary>
        /// Obtiene o establece las calorías diarias del usuario.
        /// </summary>
        [Range(500, 5000, ErrorMessage = "Daily Calories must be between 500 and 5000 kcal.")]
        public int DailyCalories { get; set; }

        /// <summary>
        /// Obtiene o establece la medida de los hombros del usuario en centímetros.
        /// </summary>
        [Required]
        [Range(70, 150, ErrorMessage = "Shoulder measurement must be between 70 and 150 cm.")]
        public decimal Shoulder { get; set; }

        /// <summary>
        /// Obtiene o establece la medida del brazo del usuario en centímetros.
        /// </summary>
        [Required]
        [Range(20, 60, ErrorMessage = "Arm measurement must be between 20 and 60 cm.")]
        public decimal Arm { get; set; }

        /// <summary>
        /// Obtiene o establece la medida de la cintura del usuario en centímetros.
        /// </summary>
        [Required]
        [Range(50, 150, ErrorMessage = "Waist measurement must be between 50 and 150 cm.")]
        public decimal Waist { get; set; }

        /// <summary>
        /// Obtiene o establece la medida de la cadera del usuario en centímetros.
        /// </summary>
        [Required]
        [Range(70, 160, ErrorMessage = "Hip measurement must be between 70 and 160 cm.")]
        public decimal Hip { get; set; }

        /// <summary>
        /// Obtiene o establece la medida de la pierna del usuario en centímetros.
        /// </summary>
        [Required]
        [Range(40, 100, ErrorMessage = "Leg measurement must be between 40 and 100 cm.")]
        public decimal Leg { get; set; }

        /// <summary>
        /// Obtiene o establece la medida de la pantorrilla del usuario en centímetros.
        /// </summary>
        [Required]
        [Range(20, 60, ErrorMessage = "Calf measurement must be between 20 and 60 cm.")]
        public decimal Calf { get; set; }

        /// <summary>
        /// Obtiene o establece el estado metabólico del usuario.
        /// </summary>
        [Required]
        [StringLength(20)]
        [RegularExpression("Normal|Altered|Not Measured", ErrorMessage = "Metabolic State must be 'Normal', 'Altered', or 'Not Measured'.")]
        public string MetabolicState { get; set; }
        /// <summary>
        /// Obtiene o establece las métricas asociadas a esta evaluación.
        /// </summary>
        public ICollection<MetricModel> Metrics { get; set; } = new List<MetricModel>();
    }
}
