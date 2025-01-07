using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Models;
using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Services
{
    public interface IAssessmentService
    {
        Task<ResultModelBase<AssessmentModel>> CreateAssessment(AssessmentModel assessment);
        Task<ResultModelBase<bool>> UpdateAssessment(int assessmentId, AssessmentModel assessment);
        Task<ResultModelBase<AssessmentModel>> GetAssessment(int assessmentId);
        Task<ResultModelBase<IEnumerable<AssessmentModel>>> GetAssessmentsByUser(Guid userId);
        decimal ComputeBMI(decimal weight, decimal height);
        IList<ValidationResult> ValidateAssessmentData(AssessmentModel assessment);
        Task<ResultModelBase<IEnumerable<string>>> CheckWarningConditions(decimal bodyFat, decimal muscleMass);
    }
}
