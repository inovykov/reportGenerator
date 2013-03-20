namespace ReportGeneratorUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using ReportGeneratorUI.Model;

    /// <summary>
    /// Write result to file with specific format
    /// </summary>
    public abstract class FileGenerator
    {
        /// <summary>
        /// The generate report.
        /// </summary>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <param name="passedCount">
        /// The passed Count.
        /// </param>
        /// <param name="failedCount">
        /// The failed Count.
        /// </param>
        /// <exception cref="ApplicationException">
        /// Exception in case no records for downloading
        /// </exception>
        public void GenerateReport(IEnumerable<ResultRecordBase> results, string filePath, int passedCount, int failedCount)
        {
            if (!results.Any())
            {
                throw new ApplicationException("No records for file download");
            }

            var preparedResult = new List<ShortResultRecord>
                                     {
                                         new ShortResultRecord(string.Format(Constants.PassedMessagePattern, passedCount)),
                                         new ShortResultRecord(string.Format(Constants.FailedMessagePattern, failedCount)),
                                         new ShortResultRecord()
                                     };

            preparedResult.AddRange(results.Select(x => new ShortResultRecord(x.TestNumber, x.TestResult, x.StackTrace)));

            this.SaveRecords(preparedResult, filePath);
        }

        /// <summary>
        /// The save records.
        /// </summary>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        protected abstract void SaveRecords(IEnumerable<ResultRecordBase> results, string filePath);
    }
}
