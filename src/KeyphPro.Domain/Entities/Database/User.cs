using KeyphPro.Domain.Entities.Commond;

namespace KeyphPro.Domain.Entities.Database
{
    public class User : EntityBase<Guid>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; } // Male, Female
        public DateTime RegistrationDate { get; set; }

        // Navigation Properties
        public ICollection<Assessment> Assessments { get; set; } = [];
    }
}
