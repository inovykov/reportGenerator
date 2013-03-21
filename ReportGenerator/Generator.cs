namespace ReportGeneratorUI
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    using ReportGeneratorUI.Model;
    using ReportGeneratorUI.Parsers;

    /// <summary>
    /// The generator.
    /// </summary>
    public class Generator
    {
        #region PRIVATE FIELDS

        /// <summary>
        /// The instance.
        /// </summary>
        private static Generator instance;
        
        /// <summary>
        /// The result.
        /// </summary>
        private ResultInfo result;

        #endregion PRIVATE FIELDS

        #region CONSTRUCTORS

        /// <summary>
        /// Prevents a default instance of the <see cref="Generator"/> class from being created. 
        /// </summary>
        private Generator()
        {
            this.result = new ResultInfo();
        }

        /// <summary>
        /// Gets the instance.
        /// </summary>
        public static Generator Instance
        {
            get
            {
                return instance ?? (instance = new Generator());
            }
        }

        #endregion CONSTRUCTORS

        /// <summary>
        /// The read files.
        /// </summary>
        /// <param name="parser">
        /// The parser.
        /// </param>
        /// <param name="directoryPath">
        /// The directory path.
        /// </param>
        public void ReadFiles(Parser parser, string directoryPath)
        {
            parser.ParseDirectory(directoryPath);
            this.result = parser.Result;
        }

        /// <summary>
        /// The write to file.
        /// </summary>
        /// <param name="fileGenerator">
        /// The file Generator.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void WriteToFile(FileGenerator fileGenerator, string filePath)
        {
            fileGenerator.GenerateReport(this.result, filePath);
        }

        /// <summary>
        /// The get results.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public ResultInfo GetResultInfo()
        {
            return this.result;
        }

        /// <summary>
        /// The get result by test number.
        /// </summary>
        /// <param name="testNumber">
        /// The test number.
        /// </param>
        /// <returns>
        /// The <see cref="ResultRecord"/>.
        /// </returns>
        public ResultRecord GetResultByTestNumber(int testNumber)
        {
            return this.result.Result.Cast<ResultRecord>().FirstOrDefault(x => x.TestNumber == testNumber);
        }

        /// <summary>
        /// The get result by filter condition.
        /// </summary>
        /// <param name="isPassed">
        /// The is passed.
        /// </param>
        /// <param name="filter">
        /// The filter.
        /// </param>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ResultRecord> GetResultByFilterCondition(bool? isPassed, string filter)
        {
            IEnumerable<ResultRecord> query = this.result.Result.Cast<ResultRecord>();

            if (isPassed.HasValue)
            {
                query = query.Where(x => (isPassed.Value ? x.TestResult == Constants.Passed : x.TestResult != Constants.Passed));
            }

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => Convert.ToString(x.TestNumber).Contains(filter) || x.TestResult.Contains(filter));
            }

            return query.ToList();
        }
    }
}
