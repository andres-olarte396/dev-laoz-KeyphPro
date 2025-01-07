using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Models;

namespace KeyphPro.Domain.Services
{
    public interface IMetricService
    {
        Task<ResultModelBase<AssessmentModel>> CreateMetric(MetricModel metric);
        Task<ResultModelBase<AssessmentModel>> UpdateMetric(int metricId, MetricModel metric);
        Task<ResultModelBase<IEnumerable<MetricModel>>> GetMetricsByAssessment(int assessmentId);
    }
}
