using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArcadisMain;

namespace ArcadisMain
{
    public partial class Metrics_Form : Form
    {
        public Metrics_Form()
        {
            InitializeComponent();
        }

        private void Metrics_Form_Load(object sender, EventArgs e)
        {
            IList<string> logs = Metrics.GetSessionLogs();

            foreach(string log in logs)
            {
                LogTextBox.AppendText(log + "\r\n");
            }
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
