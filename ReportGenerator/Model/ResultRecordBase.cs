namespace ReportGeneratorUI.Model
{
    /// <summary>
    /// Base class for all types of result record
    /// </summary>
    public class ResultRecordBase
    {
        /// <summary>
        /// Gets or sets number of the test case
        /// </summary>
        public int? TestNumber { get; set; }

        /// <summary>
        /// Gets or sets results of the test case
        /// </summary>
        public string TestResult { get; set; }

        /// <summary>
        /// Gets or sets the stack trace.
        /// </summary>
        public string StackTrace { get; set; }
    }
}
