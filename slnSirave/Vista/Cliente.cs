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
    public partial class Cliente : Form
    {

        #region Atributos

        Login frmLogin;
        ControlCliente controlCliente;

        #endregion

        #region constructores 

        public Cliente()
        {
            InitializeComponent();
            controlCliente = new ControlCliente();
        }

        public Cliente(Login frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            controlCliente = new ControlCliente();
        }

        #endregion

        #region Metodos

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Inicio(frmLogin).Show();
            this.Close();
        }

        /// <summary>
        /// evita que la cedula contenga letras
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtCedula_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// evita que el nombre digitado tenga numeros o caracteres especiales
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
       
        private void txtNombre_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetter(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space)) //si la tecla oprimida no es letra, y es diferente a na tecla de regreso o la tecla espacio. Muestra mensaje
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;//indico que el evento si fue controlado
                return;//Finaliza la función
            }
        }

        /// <summary>
        /// Torna de un color rojo si el correo es erroneo y verde si es valido en tiempo real
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtCorreo_TextChanged(object sender, EventArgs e)
        {
            Validaciones validar = new Validaciones();

            if (validar.validarEmail(txtCorreo.Text))
            {
                txtCorreo.ForeColor = Color.Green;
            }
            else
            {
                txtCorreo.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// evita que el usuario tenga espacios o caracteres especiales.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtUsuario_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) //si la tecla oprimida no es letra ni numero, y es diferente a la tecla de regreso. Muestra mensaje
            {
                MessageBox.Show("Solo se permiten letras y numeros. No se permiten espacios", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        /// <summary>
        /// valida que las contraseñas coincidan
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtRepetir_TextChanged(object sender, EventArgs e)
        {
            if (txtContraseña.Text.Equals(txtRepetir.Text))
            {
                txtRepetir.ForeColor = default;
            }
            else
            {
                txtRepetir.ForeColor = Color.Red;
            }
        }

        /// <summary>
        /// Valida que el telefono solo contenga numeros
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void txtTelefono_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true; 
                return;
            }
        }

        /// <summary>
        /// Permite la visibilidad de la contraseña 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnVisualizar_Click(object sender, EventArgs e)
        {
            if (txtContraseña.PasswordChar.Equals('*'))
            {
                txtContraseña.PasswordChar = default;
                txtRepetir.PasswordChar = default;
            }
            else
            {
                txtContraseña.PasswordChar = '*';
                txtRepetir.PasswordChar = '*';
            }
        }

        /// <summary>
        /// Llena los campos del frame con la información del cliente con la cedula digitada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!txtCedula.Text.Equals(""))
            {
                if(controlCliente.BuscarCliente(txtCedula.Text))
                {
                    btnVaciarCampos.Visible = true;
                    txtCedula.Enabled = false; //la cedula no puede ser editada

                    String[] infoCli = controlCliente.informacaionCliente(txtCedula.Text);

                    txtNombre.Text = infoCli[1];
                    txtCorreo.Text = infoCli[2];
                    txtUsuario.Text = infoCli[3];
                    txtContraseña.Text = infoCli[4];
                    txtRepetir.Text = infoCli[4];
                    txtTelefono.Text = infoCli[5];

                }
                else
                {
                    MessageBox.Show($"El cliente con cedula {txtCedula.Text} no se encuentra registrado en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Digite una cedula válida");
            }
        }

        /// <summary>
        /// Luego de validar que todos los campos estén correctos agrega un nuevo cliente a la base de datos siempre y cuando este no se encuentre ya registrado
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(ValidateData())
            {

                if (!controlCliente.BuscarCliente(txtCedula.Text)) //si no encontro al cliente
                {
                    var respuesta = MessageBox.Show($"¿Está seguro de agregar un nuevo cliente identificado con cédula {txtCedula.Text} a la base de datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.OK)
                    {

                        if (controlCliente.registrarCliente(txtCedula.Text, txtNombre.Text, txtCorreo.Text, txtUsuario.Text, txtContraseña.Text, txtTelefono.Text))
                        {
                            btnVaciarCampos_Click(sender, e);

                            MessageBox.Show("Registro exitoso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Error en el registro", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                    MessageBox.Show($"El cliente con cedula {txtCedula.Text} ya se encuentra registrado en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            }
        }

        /// <summary>
        /// Luego de validar que los campos estén correctos permite modificar el cliente consultado por la cedula digitada
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (controlCliente.BuscarCliente(txtCedula.Text))
                {
                    var respuesta = MessageBox.Show($"¿Está seguro de modificar los datos del cliente identificado con cedula {txtCedula.Text}?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.OK)
                    {

                        if (controlCliente.ModificarCliente(txtCedula.Text, txtNombre.Text, txtCorreo.Text, txtUsuario.Text, txtContraseña.Text, txtTelefono.Text))
                        {
                            MessageBox.Show("Modificación exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            btnVaciarCampos_Click(sender, e);

                        }
                        else
                        {
                            MessageBox.Show("Error en la modificación", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("El cliente que desea modificar no existe en la base de datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
        }

        /// <summary>
        /// Unicamente tomando el valor de la cedula y validando que sea correcta, se busca al cliente por ella y se confirma el borrado de la base de datos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if(txtCedula.Text != "")
            {
                if (controlCliente.BuscarCliente(txtCedula.Text))
                {
                    if (controlCliente.eliminarCliente(txtCedula.Text))
                    {
                        MessageBox.Show("Borrado exitoso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        btnVaciarCampos_Click(sender, e);
                    }
                    else
                    {
                        MessageBox.Show("No se realizó el borrado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El cliente que desea eliminar no existe en la base de datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
            }
        }

        /// <summary>
        /// Asigna un valor vacio a todos los campos del frame
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnVaciarCampos_Click(object sender, EventArgs e)
        {
            txtCedula.Enabled = true;
            txtCedula.Text = "";
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtRepetir.Text = "";
            txtTelefono.Text = "";
            btnVaciarCampos.Visible = false;
        }

        /// <summary>
        /// valida que los campos no estén nulos o únicamente con espacios en blanco 
        /// </summary>
        /// <returns></returns>

        public bool ValidateData()
        {
            bool valido = true;
            String error = "";

            if (String.IsNullOrWhiteSpace(txtCedula.Text))
                error += "Digite una cedula válida \n";

            if (String.IsNullOrWhiteSpace(txtNombre.Text))
                error += "Ingrese un nombre válido en el campo nombre \n";

            if (String.IsNullOrWhiteSpace(txtCorreo.Text) || txtCorreo.ForeColor == Color.Red)
                error += "Ingrese un correo válido en el campo Correo \n";

            if (String.IsNullOrWhiteSpace(txtContraseña.Text))
                error += "Ingrese una contraseña válida en el campo contraseña, preferiblemente usando caracteres especiales como * / - + \n";

            if (String.IsNullOrWhiteSpace(txtRepetir.Text) || txtRepetir.ForeColor == Color.Red)
                error += "las contraseñas no coinciden \n";

            if (String.IsNullOrWhiteSpace(txtTelefono.Text))
                error += "Ingrese un telefono válido en el campo Telefono \n";

            if (!error.Equals(""))
            {
                valido = false;
                MessageBox.Show(error, "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            return valido;
        }

        #endregion

    }
}
