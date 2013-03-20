namespace ReportGeneratorUI.Model
{
    /// <summary>
    /// Short form of record for downloading
    /// </summary>
    public class ShortResultRecord : ResultRecordBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ShortResultRecord"/> class.
        /// </summary>
        public ShortResultRecord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortResultRecord"/> class.
        /// </summary>
        /// <param name="testNumber">
        /// The test number.
        /// </param>
        /// <param name="testResult">
        /// The test result.
        /// </param>
        /// <param name="stackTrace">
        /// The stack Trace.
        /// </param>
        public ShortResultRecord(int? testNumber, string testResult, string stackTrace = null)
        {
            if (testNumber.HasValue)
            {
                this.TestNumber = testNumber;
            }

            this.TestResult = testResult;
            this.StackTrace = stackTrace;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortResultRecord"/> class.
        /// </summary>
        /// <param name="testResult">
        /// The test result.
        /// </param>
        public ShortResultRecord(string testResult)
        {
            this.TestResult = testResult;
        }
    }
}
