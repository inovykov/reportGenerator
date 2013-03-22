using System;

namespace ReportGeneratorUI
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Xml.Linq;
    using System.Xml.XPath;

    using ReportGeneratorUI.Model;
    using ReportGeneratorUI.Parsers;

    /// <summary>
    /// Parser of XML files
    /// </summary>
    public class XmlParser : Parser
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XmlParser"/> class.
        /// </summary>
        public XmlParser() : base("*.xml")
        {
        }

        /// <summary>
        /// The process file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        protected override void ProcessFile(string filePath)
        {
            if (filePath.Contains("SummaryReport"))
            {
                return;
            }

            var doc = XElement.Load(filePath);

            IEnumerable<XElement> failures =
                ((IEnumerable)doc.XPathEvaluate("./*[@level='FAILURE']")).Cast<XElement>();
            
            var testNumber = int.Parse(doc.Value.Substring(22, 6));
            
            var htmlPath = filePath.Replace(".xml", ".html");

            if (failures.Any())
            {
                var stackTrace = this.getLastMessageByXPath(doc, "./*[@level='DEBUG']");

                this.Result.FailedCount++;

                var step = this.getLastMessageByXPath(doc, "./*[@level='INFO' and @category='Step']");

                var message = failures.ToList().First().Attribute("message").Value;

                var pathToThumb = this.getLastMessageByXPath(doc, "./*[@level='INFO' and @category='Screenshot']/a/img", "src");

                var pathToFullImg = this.getLastMessageByXPath(doc, "./*[@level='INFO' and @category='Screenshot']/a", "href");
                
                var imageThumb = string.IsNullOrEmpty(pathToFullImg) ? null : string.Format("{0}//{1}", this.PathToDirectory, pathToThumb);

                var fullImagePath = string.IsNullOrEmpty(pathToFullImg) ? null : string.Format("{0}//{1}", this.PathToDirectory, pathToFullImg);

                this.Result.Result.Add(new ResultRecord(testNumber, message, imageThumb, fullImagePath, stackTrace, step, htmlPath));
                
                return;
            }

            this.Result.PassedCount++;

            this.Result.Result.Add(new ResultRecord(testNumber, Constants.Passed, htmlPath: htmlPath));
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
