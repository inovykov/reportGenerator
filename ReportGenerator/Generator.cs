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
        /// The parser.
        /// </summary>
        private readonly Parser parser;

        /// <summary>
        /// The file generator.
        /// </summary>
        private readonly FileGenerator fileGenerator;
        
        /// <summary>
        /// The result.
        /// </summary>
        private IList<ResultRecord> result;

        #endregion PRIVATE FIELDS

        #region CONSTRUCTORS

        /// <summary>
        /// Prevents a default instance of the <see cref="Generator"/> class from being created. 
        /// </summary>
        private Generator()
        {
            this.result = new List<ResultRecord>();

            // 2DOinov: move choosing of parser and generator type on UI
            this.parser = new XmlParser();
            this.fileGenerator = new CsvGenerator();
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


        #region PUBLIC PROPERTIES

        /// <summary>
        /// Gets the failed count.
        /// </summary>
        public int FailedCount { get; private set; }

        /// <summary>
        /// Gets the passed count.
        /// </summary>
        public int PassedCount { get; private set; }

        #endregion PUBLIC PROPERTIES


        /// <summary>
        /// The read files.
        /// </summary>
        /// <param name="directoryPath">
        /// The directory path.
        /// </param>
        public void ReadFiles(string directoryPath)
        {
            this.parser.ParseDirectory(directoryPath);
            this.result = this.parser.Result;

            this.PassedCount = this.parser.PassedCount;
            this.FailedCount = this.parser.FailedCount;
        }

        /// <summary>
        /// The write to file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void WriteToFile(string filePath)
        {
            this.fileGenerator.GenerateReport(this.result, filePath, this.PassedCount, this.FailedCount);
        }

        /// <summary>
        /// The get results.
        /// </summary>
        /// <returns>
        /// The <see cref="IEnumerable"/>.
        /// </returns>
        public IEnumerable<ResultRecord> GetAllResults()
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
            return this.result.FirstOrDefault(x => x.TestNumber == testNumber);
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
            IEnumerable<ResultRecord> query = this.result;

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
