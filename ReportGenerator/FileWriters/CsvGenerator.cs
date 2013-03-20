using System.IO;

using CsvHelper;

using ReportGeneratorUI.Model;

namespace ReportGeneratorUI
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    /// <summary>
    /// TODO: Update summary.
    /// </summary>
    public class CsvGenerator : FileGenerator
    {
        protected override void SaveRecords(IEnumerable<ResultRecordBase> results, string filePath)
        {
            using (var csv = new CsvWriter(new StreamWriter(filePath)))
            {
                csv.WriteRecords(results);
            }
        }
    }
}
