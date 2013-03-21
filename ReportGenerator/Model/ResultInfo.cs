namespace ReportGeneratorUI.Model
{
    using System.Collections.Generic;

    /// <summary>
    /// Class contains whole information about test results
    /// </summary>
    public class ResultInfo
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultInfo"/> class.
        /// </summary>
        public ResultInfo()
        {
            this.Result = new List<ResultRecordBase>();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultInfo"/> class.
        /// </summary>
        /// <param name="resultRecordList">
        /// The result Record List.
        /// </param>
        /// <param name="passedCount">
        /// The passed Count.
        /// </param>
        /// <param name="failedCount">
        /// The failed Count.
        /// </param>
        public ResultInfo(IList<ResultRecordBase> resultRecordList, int passedCount, int failedCount) : this()
        {
            if (resultRecordList != null)
            {
                this.Result = resultRecordList;
            }
            
            this.PassedCount = passedCount;
            this.FailedCount = failedCount;
        }

        /// <summary>
        /// Gets the result.
        /// </summary>
        public IList<ResultRecordBase> Result { get; private set; }

        /// <summary>
        /// Gets or sets the passed count.
        /// </summary>
        public int PassedCount { get; set; }

        /// <summary>
        /// Gets or sets the failed count.
        /// </summary>
        public int FailedCount { get; set; }

        /// <summary>
        /// Clear result info object
        /// </summary>
        public void ClearResult()
        {
            this.Result = new List<ResultRecordBase>();
            this.PassedCount = 0;
            this.FailedCount = 0;
        }
    }
}
