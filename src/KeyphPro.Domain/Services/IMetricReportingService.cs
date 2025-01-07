using KeyphPro.Domain.Entities.Commond;
using KeyphPro.Domain.Entities.Models;

namespace KeyphPro.Domain.Services
{
    public interface IMetricReportingService
    {
        Task<ResultModelBase<ReportDataModel>> GenerateReport(Guid userId, ReportParametersModel parameters);
        Task<ResultModelBase<ReportDataModel>> GetInteractiveReport(Guid userId);
    }
}
