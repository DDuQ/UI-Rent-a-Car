using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{
    public partial class AcercaDe : Form
    {
        private Login frmLogin;

        public AcercaDe()
        {
            InitializeComponent();
        }

        public AcercaDe(Login frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
        }

        private void AcercaDe_Load(object sender, EventArgs e)
        {

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            new Inicio(frmLogin).Show();
            this.Close();
        }
    }
}
