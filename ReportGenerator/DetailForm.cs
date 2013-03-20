using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ReportGeneratorUI;
using ReportGeneratorUI.Model;

namespace ReportGeneratorUI_0._1
{
    public partial class DetailForm : Form
    {
        /// <summary>
        /// The generator.
        /// </summary>
        private readonly Generator generator = Generator.Instance;

        private string pathToHtlmVersion;

        /// <summary>
        /// Initializes a new instance of the <see cref="DetailForm"/> class.
        /// </summary>
        /// <param name="testNumber">
        /// The test number.
        /// </param>
        public DetailForm(int testNumber)
        {
            InitializeComponent();
            
            ResultRecord resultRecord = generator.GetResultByTestNumber(testNumber);

            if (resultRecord == null || resultRecord.FullImagePath == null || resultRecord.StackTrace == null)
            {
                tbStackTrace.Text = "This test case was passed so there is no additional information required";
                return;
            }

            var fullImagePath = resultRecord.FullImagePath;

            tbStackTrace.Text = resultRecord.StackTrace;

            imgPanelScreenShot.SizeMode = PictureBoxSizeMode.StretchImage;

            lblStepNumber.Text = resultRecord.StepNumber;

            this.pathToHtlmVersion = resultRecord.PathToHtlmVersion;

            this.imgPanelScreenShot.Image = new Bitmap(fullImagePath);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnOpenInBrowser_Click(object sender, EventArgs e)
        {
            var processStartInfo = new ProcessStartInfo(Convert.ToString(this.pathToHtlmVersion));
            Process.Start(processStartInfo);
        }
    }
}
