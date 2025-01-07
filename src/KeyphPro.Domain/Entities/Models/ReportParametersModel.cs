using System.ComponentModel.DataAnnotations;

namespace KeyphPro.Domain.Entities.Models
{
    public class ReportParametersModel
    {
        /// <summary>
        /// Identifiers of the users for whom the report will be generated.
        /// If empty, the report will include all users.
        /// </summary>
        public List<int> UserIds { get; set; } = new List<int>();

        /// <summary>
        /// Start date for the report.
        /// </summary>
        [Required(ErrorMessage = "The Start Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "The Start Date must be a valid date.")]
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date for the report.
        /// </summary>
        [Required(ErrorMessage = "The End Date is required.")]
        [DataType(DataType.Date, ErrorMessage = "The End Date must be a valid date.")]
        public DateTime EndDate { get; set; }

        /// <summary>
        /// List of metric types to include in the report.
        /// If empty, all metrics will be included.
        /// </summary>
        public List<string> MetricTypes { get; set; } = new List<string>();

        /// <summary>
        /// Grouping option for the report data (e.g., daily, weekly, monthly).
        /// Default is None, meaning no grouping will be applied.
        /// </summary>
        public string Grouping { get; set; } = "None"; // Possible values: "None", "Daily", "Weekly", "Monthly"

        /// <summary>
        /// Indicates if the report should include graphical data.
        /// </summary>
        public bool IncludeGraphs { get; set; } = false;

        /// <summary>
        /// Indicates if the report should include summary insights.
        /// </summary>
        public bool IncludeInsights { get; set; } = true;

        /// <summary>
        /// Format for the generated report (e.g., PDF, Excel, JSON).
        /// Default is JSON.
        /// </summary>
        public string OutputFormat { get; set; } = "JSON"; // Possible values: "JSON", "PDF", "Excel"

        /// <summary>
        /// Additional filters for the report, defined as key-value pairs.
        /// </summary>
        public Dictionary<string, string> AdditionalFilters { get; set; } = new Dictionary<string, string>();
    }

}
