using System.Collections.Generic;
using System.IO;
using CsvHelper;
using ReportGeneratorUI.Model;

namespace ReportGeneratorUI
{    
    /// <summary>
    /// Generates file in csv format
    /// </summary>
    public class CsvGenerator : FileGenerator
    {
        /// <summary>
        /// The save records.
        /// </summary>
        /// <param name="results">
        /// The results.
        /// </param>
        /// <param name="filePath">
        /// The file path.
        /// </param>
        protected override void SaveRecords(IEnumerable<ResultRecordBase> results, string filePath)
        {
            using (var csv = new CsvWriter(new StreamWriter(filePath)))
            {
                csv.WriteRecords(results);
            }
        }
    }
}
