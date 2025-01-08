using KeyphPro.Domain.Entities.Commond;

namespace KeyphPro.Domain.Entities.Database
{
    public class Assessment : EntityBase<int>
    {
        public Guid UserId { get; set; } // Foreign Key
        public Guid CoachId { get; set; } // Foreign Key
        public DateTime Date { get; set; }
        public decimal Weight { get; set; }
        public decimal BMI { get; set; } // Calculated property
        public decimal BodyFatPercentage { get; set; }
        public decimal ViseralFat { get; set; }
        public decimal MuscleMassPercentage { get; set; }
        public int DailyCalories { get; set; }
        public decimal Shoulder { get; set; }
        public decimal Arm { get; set; }
        public decimal Waist { get; set; }
        public decimal Hip { get; set; }
        public decimal Leg { get; set; }
        public decimal Calf { get; set; }
        public string MetabolicState { get; set; } // Normal, Altered, Not Measured
        public ICollection<Metric> Metrics { get; set; } = [];
    }
}
