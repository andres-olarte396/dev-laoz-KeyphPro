namespace KeyphPro.Domain.Entities.Models
{
    public class ReportDataModel
    {
        /// <summary>
        /// Title of the report, providing a high-level summary.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Description or additional context for the report.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Date range covered by the report.
        /// </summary>
        public DateRange DateRange { get; set; }

        /// <summary>
        /// List of metrics included in the report.
        /// </summary>
        public List<MetricReport> Metrics { get; set; } = new List<MetricReport>();

        /// <summary>
        /// Additional insights or warnings related to the report data.
        /// </summary>
        public List<string> Insights { get; set; } = new List<string>();

        /// <summary>
        /// Graphical representations of the report data.
        /// </summary>
        public List<GraphData> Graphs { get; set; } = new List<GraphData>();
    }

    public class DateRange
    {
        /// <summary>
        /// Start date of the range.
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// End date of the range.
        /// </summary>
        public DateTime EndDate { get; set; }
    }

    public class MetricReport
    {
        /// <summary>
        /// Name of the metric (e.g., Body Fat, Weight).
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Aggregated value of the metric for the report period.
        /// </summary>
        public decimal AggregatedValue { get; set; }

        /// <summary>
        /// List of data points for the metric.
        /// </summary>
        public List<MetricDataPoint> DataPoints { get; set; } = new List<MetricDataPoint>();
    }

    public class MetricDataPoint
    {
        /// <summary>
        /// Date of the data point.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Value of the metric on the specific date.
        /// </summary>
        public decimal Value { get; set; }
    }

    public class GraphData
    {
        /// <summary>
        /// Title of the graph.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Type of the graph (e.g., Line, Bar, Pie).
        /// </summary>
        public string GraphType { get; set; }

        /// <summary>
        /// Data points for the graph.
        /// </summary>
        public List<GraphDataPoint> DataPoints { get; set; } = new List<GraphDataPoint>();
    }

    public class GraphDataPoint
    {
        /// <summary>
        /// Label for the data point (e.g., date or metric name).
        /// </summary>
        public string Label { get; set; }

        /// <summary>
        /// Value associated with the label.
        /// </summary>
        public decimal Value { get; set; }
    }
}
