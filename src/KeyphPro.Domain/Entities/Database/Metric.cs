using KeyphPro.Domain.Entities.Commond;

namespace KeyphPro.Domain.Entities.Database
{
    public class Metric : EntityBase<int>
    {
        public int AssessmentId { get; set; } // Foreign Key
        public string Type { get; set; } // e.g., Weight, Body Fat, Muscle Mass, etc.
        public decimal Value { get; set; }
    }

}
