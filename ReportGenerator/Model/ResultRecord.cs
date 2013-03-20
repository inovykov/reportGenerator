using System.Drawing;

namespace ReportGeneratorUI.Model
{
    /// <summary>
    /// Class represents record from results list
    /// </summary>
    public class ResultRecord : ResultRecordBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResultRecord"/> class. 
        /// Default constructor
        /// </summary>
        public ResultRecord()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultRecord"/> class.
        /// </summary>
        /// <param name="testResult">
        /// The test result.
        /// </param>
        public ResultRecord(string testResult)
        {
            this.TestResult = testResult;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResultRecord"/> class.
        /// </summary>
        /// <param name="testNumber">
        /// The test number.
        /// </param>
        /// <param name="testResult">
        /// The test result.
        /// </param>
        /// <param name="imageThumbnailPath">
        /// The imageThumbnailPath.
        /// </param>
        /// <param name="fullImagePath">
        /// The full Image Path.
        /// </param>
        /// <param name="stackTrace">
        /// The stack Trace.
        /// </param>
        /// <param name="stepNumber">
        /// The step Number.
        /// </param>
        public ResultRecord(int testNumber, string testResult, string imageThumbnailPath = null, string fullImagePath = null, string stackTrace = null, string stepNumber = null, string htmlPath = null)
        {
            this.TestNumber = testNumber;    
            
            this.TestResult = testResult;

            if (!string.IsNullOrEmpty(imageThumbnailPath))
            {
                this.ImageThumbnail = new Bitmap(imageThumbnailPath);
            }

            this.FullImagePath = fullImagePath;

            this.StackTrace = stackTrace;

            this.StepNumber = stepNumber;

            this.PathToHtlmVersion = htmlPath;

        }

        /// <summary>
        /// Gets or sets path to imageThumbnailPath if any
        /// </summary>
        public Image ImageThumbnail { get; set; }

        /// <summary>
        /// Gets or sets the full image.
        /// </summary>
        public string FullImagePath { get; set; }

        /// <summary>
        /// Gets or sets the step number.
        /// </summary>
        public string StepNumber { get; set; }

        /// <summary>
        /// Gets or sets the path to htlm version.
        /// </summary>
        public string PathToHtlmVersion { get; set; }

    }
}
