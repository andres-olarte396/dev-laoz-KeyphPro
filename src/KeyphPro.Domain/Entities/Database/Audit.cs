using KeyphPro.Domain.Entities.Commond;

namespace KeyphPro.Domain.Entities.Database
{
    public class Audit : EntityBase<int>
    {
        public string? IdAudit { get; set; }
        public string? Entity { get; set; }
        public bool Success { get; set; } = true;
    }
}
