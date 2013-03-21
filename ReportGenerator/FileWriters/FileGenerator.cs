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
        /// <param name="resultInfo">
        /// The whole info about result
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        /// <exception cref="ApplicationException">
        /// Exception in case no records for downloading
        /// </exception>
        public void GenerateReport(ResultInfo resultInfo, string filePath)
        {
            if (!resultInfo.Result.Any())
            {
                throw new ApplicationException("No records for file download");
            }

            var preparedResult = new List<ShortResultRecord>
                                     {
                                         new ShortResultRecord(string.Format(Constants.PassedMessagePattern, resultInfo.PassedCount)),
                                         new ShortResultRecord(string.Format(Constants.FailedMessagePattern, resultInfo.FailedCount)),
                                         new ShortResultRecord()
                                     };

            preparedResult.AddRange(resultInfo.Result.Select(x => new ShortResultRecord(x.TestNumber, x.TestResult, x.StackTrace)));

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
