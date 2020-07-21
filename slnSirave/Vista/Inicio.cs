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
    public partial class Inicio : Form
    {

        #region Atributos

        Login frmLogin;

        #endregion

        #region Constructores

        public Inicio()
        {
            InitializeComponent();
        }

        public Inicio(Login frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
        }

        #endregion

        #region Metodos
        private void btnAdministrador_Click(object sender, EventArgs e)
        {
            Administrador administrador = new Administrador(frmLogin);
            administrador.Show();
            this.Close();
        }
        
        private void btnUsuario_Click(object sender, EventArgs e)
        {
            Cliente cliente = new Cliente(frmLogin);
            cliente.Show();
            this.Close();
        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            Vehiculo vehiculo = new Vehiculo(frmLogin);
            vehiculo.Show();
            this.Close();
        }

        private void btnReserva_Click(object sender, EventArgs e)
        {
            Reserva reserva = new Reserva(frmLogin);
            reserva.Show();
            this.Close();
        }   
        private void btnCerrarSesión_Click(object sender, EventArgs e)
        {
            frmLogin.Show();
            this.Close();
        }

        private void btnAyuda_Click(object sender, EventArgs e)
        {
            AcercaDe frmAcercaDe = new AcercaDe(frmLogin);
            frmAcercaDe.Show();
            this.Close();
        }

        #endregion

        
    }
}
