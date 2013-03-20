using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.XPath;
using CsvHelper;

using ReportGeneratorUI_0._1.Model;

namespace ReportGeneratorUI_0._1
{
    /// <summary>
    /// The generator.
    /// </summary>
    public class Generator
    {
        /// <summary>
        /// The passed message.
        /// </summary>
        private const string PassedMessagePattern = "{0} test cases are passed";

        /// <summary>
        /// The failed message.
        /// </summary>
        private const string FailedMessagePattern = "{0} test cases are failed";

        /// <summary>
        /// The failed count.
        /// </summary>
        public int FailedCount;

        /// <summary>
        /// The passed count.
        /// </summary>
        public int PassedCount;

        /// <summary>
        /// The passed.
        /// </summary>
        private const string Passed = "Passed";

        /// <summary>
        /// The result.
        /// </summary>
        private IList<ResultRecord> result;

        /// <summary>
        /// The instance.
        /// </summary>
        private static Generator instance;

        private string directoryPath;

        /// <summary>
        /// Initializes a new instance of the <see cref="Generator"/> class.
        /// </summary>
        private Generator()
        {
            this.result = new List<ResultRecord>();
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

        /// <summary>
        /// The read files.
        /// </summary>
        /// <param name="directoryPath">
        /// The directory path.
        /// </param>
        public void ReadFiles(string directoryPath)
        {
            this.directoryPath = directoryPath;
            var filePaths = Directory.EnumerateFiles(directoryPath, "*.xml");

            foreach (var filePath in filePaths)
            {
                this.ProcessFile(filePath);
            }
        }

        /// <summary>
        /// The write to file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        public void WriteToFile(string filePath)
        {
            if (this.result.Count == 0)
            {
                throw new ApplicationException("No records to display");
            }

            var preparedResult = new List<ShortResultRecord>
                                     {
                                         new ShortResultRecord(string.Format(PassedMessagePattern, this.PassedCount)),
                                         new ShortResultRecord(string.Format(FailedMessagePattern, this.FailedCount)),
                                         new ShortResultRecord()
                                     };

            preparedResult.AddRange(this.result.Select(x => new ShortResultRecord(x.TestNumber, x.TestResult)));

            using (var csv = new CsvWriter(new StreamWriter(filePath)))
            {
                csv.WriteRecords(preparedResult);
            }
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
                query = query.Where(x => (isPassed.Value ? x.TestResult == Passed : x.TestResult != Passed));
            }

            if (!string.IsNullOrEmpty(filter))
            {
                query = query.Where(x => Convert.ToString(x.TestNumber).Contains(filter) || x.TestResult.Contains(filter));
            }


            return query.ToList();
        }

        public void ClearResult()
        {
            this.result = new List<ResultRecord>();
            this.FailedCount = 0;
            this.PassedCount = 0;

        }

        /// <summary>
        /// The process file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        private void ProcessFile(string filePath)
        {
            var doc = XElement.Load(filePath);
            
            IEnumerable<XElement> failures =
                ((IEnumerable)doc.XPathEvaluate("./*[@level='FAILURE']")).Cast<XElement>();


            var testNumber = int.Parse(doc.Value.Substring(22, 6));

            if (failures.Any())
            {
                var stackTrace = this.getLastMessageByXPath(doc, "./*[@level='DEBUG']");

                this.FailedCount++;

                var step = this.getLastMessageByXPath(doc, "./*[@level='INFO' and @category='Step']");

                var message = failures.ToList().First().Attribute("message").Value;

                var pathToThumb = this.getLastMessageByXPath(doc, "./*[@level='INFO' and @category='Screenshot']/a/img", "src");

                var pathToFullImg = this.getLastMessageByXPath(doc, "./*[@level='INFO' and @category='Screenshot']/a", "href");
                
                var imageThumb = new Bitmap(string.Format("{0}//{1}", this.directoryPath, pathToThumb));

                var fullImagePath = string.Format("{0}//{1}", this.directoryPath, pathToFullImg);

                this.result.Add(new ResultRecord(testNumber, message, imageThumb, fullImagePath, stackTrace, step));
                return;
            }

            this.PassedCount++;

            this.result.Add(new ResultRecord(testNumber, Passed));
        }

        /// <summary>
        /// The get last message by x path.
        /// </summary>
        /// <param name="doc">
        /// The doc.
        /// </param>
        /// <param name="xpath">
        /// The xpath.
        /// </param>
        /// <param name="attribute">
        /// The attribute.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        private string getLastMessageByXPath(XElement doc, string xpath, string attribute = "message")
        {
            var xElement = ((IEnumerable)doc.XPathEvaluate(xpath)).Cast<XElement>().ToList().LastOrDefault();

            return xElement == null ? string.Empty : xElement.Attribute(attribute).Value;
        }
    }
}
