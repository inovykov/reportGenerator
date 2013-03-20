namespace ReportGeneratorUI_0._1.Model
{
    /// <summary>
    /// Short form of record for downloading
    /// </summary>
    public class ShortResultRecord
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
        public ShortResultRecord(int? testNumber, string testResult)
        {
            if (testNumber.HasValue)
            {
                TestNumber = testNumber;
            }

            TestResult = testResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ShortResultRecord"/> class.
        /// </summary>
        /// <param name="testResult">
        /// The test result.
        /// </param>
        public ShortResultRecord(string testResult)
        {
            TestResult = testResult;
        }

        /// <summary>
        /// Gets or sets number of the test case
        /// </summary>
        public int? TestNumber { get; set; }

        /// <summary>
        /// Gets or sets resutls of the test case
        /// </summary>
        public string TestResult { get; set; }
    }
}
