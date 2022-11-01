using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ApiCZ
{
    public partial class ImportResaultDialog : Form
    {
        public ImportResaultDialog(DataTable dataTable)
        {
            InitializeComponent();
            dataGrid.DataSource = dataTable;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}
