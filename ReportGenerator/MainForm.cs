using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace ReportGeneratorUI_0._1
{
    public partial class MainForm : Form
    {
        private bool showHint = true;

        private Generator generator;

        private const string SearchPlaceholderMessage = "  Type something to search ...";

        public MainForm()
        {
            InitializeComponent();

            generator = Generator.Instance;
//            tbPathToDir.Text = @"D:\Documents\AllScript Automation\Test Debug reports\Reports 06 03"; //2DOinov: hardcoded for debug purposes

            tbFilter.Text = SearchPlaceholderMessage;
            tbFilter.ForeColor = Color.DarkGray;
            
        }

        /// <summary>
        /// The bind grid.
        /// </summary>
        private void BindGrid()
        {
            string filterText = string.Empty;
            bool? isPassed = null;

            if (tbFilter.Text != SearchPlaceholderMessage)
            {
                filterText = tbFilter.Text;
            }

            var radioButtonText = groupBoxFilter.Controls.OfType<RadioButton>().FirstOrDefault(x => x.Checked).Text;

            if (radioButtonText != "All")
            {
                isPassed = radioButtonText == "Passed";
            }

            var records = generator.GetResultByFilterCondition(isPassed, filterText);
            
            gvResults.DataSource = records;
            btnDownloadCSV.Enabled = records.Any();
        }

        /// <summary>
        /// The process files.
        /// </summary>
        private void ProcessFiles()
        {
            try
            {
                generator.ClearResult();
                generator.ReadFiles(tbPathToDir.Text);
                this.BindGrid();

                this.lblPassedCount.Text = generator.PassedCount.ToString();
                this.lblFailedCount.Text = generator.FailedCount.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// The btn directory_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnDirectory_Click(object sender, EventArgs e)
        {
            var dialog = new FolderBrowserDialog();

            if (dialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            tbPathToDir.Text = dialog.SelectedPath;
        }

        /// <summary>
        /// The btn download cs v_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnDownloadCSV_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog
                                     {
                                         Filter = "CSV File (*.csv)|*.csv", 
                                         RestoreDirectory = true
                                     };

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {              
                try
                {
                    generator.WriteToFile(saveFileDialog.FileName);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        /// <summary>
        /// The btn go_ click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void btnGo_Click(object sender, EventArgs e)
        {
            var path = tbPathToDir.Text;
            if (string.IsNullOrEmpty(path))
            {
                MessageBox.Show("Please select folder with report results");
                return;
            }

            ProcessFiles();
        }

        /// <summary>
        /// The gv results_ cell double click.
        /// </summary>
        /// <param name="sender">
        /// The sender.
        /// </param>
        /// <param name="e">
        /// The e.
        /// </param>
        private void gvResults_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
            {
                return;
            }

            var number = ((DataGridView)sender).Rows[e.RowIndex].Cells[0].Value;
            var detailForm = new DetailForm((int)number);
            detailForm.Show();
        }

        private void tbFilter_Enter(object sender, EventArgs e)
        {
            if (showHint)
            {
                tbFilter.Text = string.Empty;
                tbFilter.ForeColor = Color.Black;
                showHint = false;
            }
        }

        private void tbFilter_Leave(object sender, EventArgs e)
        {
            if (!showHint && string.IsNullOrEmpty(tbFilter.Text))
            {
                tbFilter.Text = SearchPlaceholderMessage;
                tbFilter.ForeColor = Color.DarkGray;
                showHint = true;
            }
        }

        private void filter_Changed(object sender, EventArgs e)
        {
            this.BindGrid();
        }
    }
}
