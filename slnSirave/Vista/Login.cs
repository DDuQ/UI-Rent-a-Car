using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Control;

namespace Vista
{
    public partial class Login : Form
    {

        #region Constructor

        public Login()
        {
            InitializeComponent();
        }

        #endregion

        #region Metodos

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            ControlAdministrador cAdministrador = new ControlAdministrador();

            if (cAdministrador.Logined(txtUsuario.Text, txtContraseña.Text))
            {
                Inicio inicio = new Inicio(this);  
                inicio.Show();
                this.Visible = false;
            }
            else
            {
                MessageBox.Show("Usuario y/o contraseña incorrectas");
            }

        }

        private void btnVisiualizar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar.Equals('•'))
            {
                txtContraseña.PasswordChar = default;
            }
            else
            {
                txtContraseña.PasswordChar = '•';
            } 
        }

        private void txtContraseña_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Enter )
            {
                btnIngresar_Click(sender,e);
                e.Handled = true; 
            }

        }  
        
        private void txtContraseña_Click(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '•';
            if (String.IsNullOrWhiteSpace(txtUsuario.Text))
            {
                txtUsuario.Text = "Usuario";
            }
            txtContraseña.Clear();

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtUsuario_Click(object sender, EventArgs e)
        {
            
            if (String.IsNullOrWhiteSpace(txtContraseña.Text))
            {
                txtContraseña.Text = "Contraseña";
                txtContraseña.PasswordChar = default;
            }
            txtUsuario.Clear();
        }

        private void txtUsuario_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtUsuario.Text) || txtUsuario.Text.Equals("Usuario"))
            {
                lineaUser.BackColor = Color.White;
                picUser.Image = Properties.Resources.UserBl;
            }
            else
            {
                lineaUser.BackColor = Color.Blue;
                picUser.Image = Properties.Resources.UserAz;
            }
        }

        private void txtContraseña_TextChanged(object sender, EventArgs e)
        {
            txtContraseña.PasswordChar = '•';
            if (String.IsNullOrWhiteSpace(txtContraseña.Text) || txtContraseña.Text.Equals("Contraseña"))
            {
                lineaPass.BackColor = Color.White;
                picPass.Image = Properties.Resources.PassBl;
            }
            else
            {
                lineaPass.BackColor = Color.Blue;
                picPass.Image = Properties.Resources.passAz;
            }
        }

        #endregion


    }
}
