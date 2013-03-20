using System.Collections.Generic;
using System.IO;

using ReportGeneratorUI.Model;


namespace ReportGeneratorUI.Parsers
{
    /// <summary>
    /// Base parser
    /// </summary>
    public abstract class Parser
    {
        /// <summary>
        /// Gets or sets the search patter.
        /// </summary>
        private string searchPattern;

        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        /// <param name="searchPatter">
        /// The search patter.
        /// </param>
        protected Parser(string searchPatter)
        {
            this.searchPattern = searchPatter;
        }
        

        #region PUBLIC PROPERTIES

        /// <summary>
        /// Gets or sets the failed count.
        /// </summary>
        public int FailedCount { get; protected set; }

        /// <summary>
        /// Gets or sets the passed count.
        /// </summary>
        public int PassedCount { get; protected set; }
        
        /// <summary>
        /// Gets or sets Parsed result
        /// </summary>
        public IList<ResultRecord> Result { get; protected set; }

        #endregion PUBLIC PROPERTIES

        #region PROTECTED PROPERTIES

        /// <summary>
        /// Gets or sets the directory.
        /// </summary>
        protected string PathToDirectory { get; set; }

        #endregion PROTECTED PROPERTIES

        /// <summary>
        /// Parse all files of specific type from directory
        /// </summary>
        /// <param name="pathToDir">
        /// The path to directory
        /// </param>
        public virtual void ParseDirectory(string pathToDir)
        {
            this.Result = new List<ResultRecord>();

            this.PassedCount = 0;
            this.FailedCount = 0;

            this.PathToDirectory = pathToDir;

            var filePaths = Directory.EnumerateFiles(this.PathToDirectory, this.searchPattern);

            foreach (var filePath in filePaths)
            {
                this.ProcessFile(filePath);
            }
        }

        /// <summary>
        /// The process file.
        /// </summary>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        protected abstract void ProcessFile(string filePath);
    }
}
