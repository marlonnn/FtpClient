using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FtpClient
{
    public partial class FtpClientForm : GenericSaveForm.GenericSavForm
    {
        private FtpSettings _ftpSettings;
        public FtpClientForm()
        {
            InitializeComponent();
        }

        private void FtpClientForm_Load(object sender, EventArgs e)
        {

        }
    }
}
