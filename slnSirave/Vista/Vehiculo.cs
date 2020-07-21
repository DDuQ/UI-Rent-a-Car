using Control;
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
    public partial class Vehiculo : Form
    {

        #region Atributos

        Login frmLogin;
        ControlVehiculo controlVehiculo;
 
        #endregion

        #region Constructores 

        public Vehiculo()
        {
            InitializeComponent();
            controlVehiculo = new ControlVehiculo();
        }

        public Vehiculo(Login frmLogin)
        {
            InitializeComponent();
            controlVehiculo = new ControlVehiculo();
            this.frmLogin = frmLogin;
        }

        #endregion

        #region Metodos

        private void txtPlaca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back)) 
            {
                MessageBox.Show("Solo se permiten letras y números", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;//indico que el evento si fue controlado
                return;//Finaliza la función
            }
        }

        private void txtPlaca_TextChanged(object sender, EventArgs e)
        {
            Validaciones validar = new Validaciones();

            if (validar.validarPlaca(txtPlaca.Text) && txtPlaca.Text.Length==6)
            {
                txtPlaca.ForeColor = Color.Green;
                txtPlaca.Text = txtPlaca.Text.ToUpper();
            }
            else
            {
                txtPlaca.ForeColor = Color.Red;
            }
        }

        private void txtMarca_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(!(char.IsLetterOrDigit(e.KeyChar)) && (e.KeyChar != (char)Keys.Back) && (e.KeyChar != (char)Keys.Space)) //si la tecla oprimida no es letra, y es diferente a na tecla de regreso o la tecla espacio. Muestra mensaje
            {
                MessageBox.Show("Solo se permiten letras", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;//indico que el evento si fue controlado
                return;//Finaliza la función
            }
        }

        private void txtModelo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtPrecio_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsNumber(e.KeyChar)) && (e.KeyChar != (char)Keys.Back))
            {
                MessageBox.Show("Solo se permiten numeros", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                e.Handled = true;
                return;
            }
        }

        private void txtObservaciones_TextChanged(object sender, EventArgs e)
        {
            txtCaracteres.Text = ""+txtObservaciones.TextLength+"/400";

            if (txtObservaciones.TextLength >= 400)
            {
                //txtObservaciones.Enabled = false;
                txtCaracteres.ForeColor = Color.Red;
            }
        }

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (!controlVehiculo.BuscarVehiculo(txtPlaca.Text)) //si no encontro al vehiculo
                {
                    var respuesta = MessageBox.Show($"¿Está seguro de agregar un nuevo Vehiculo identificado con placa {txtPlaca.Text} a la base de datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.OK)
                    {

                        if (controlVehiculo.registrarVehiculo(txtPlaca.Text, txtModelo.Text, cbxGama.SelectedItem.ToString(), txtMarca.Text, cbxCapacidad.SelectedItem.ToString(), txtObservaciones.Text, txtPrecio.Text))
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
                    MessageBox.Show($"El vehiculo con placa {txtPlaca.Text} ya se encuentra registrado en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (ValidateData())
            {
                if (controlVehiculo.BuscarVehiculo(txtPlaca.Text))
                { 
                    var respuesta = MessageBox.Show($"¿Está seguro de Modificar el Vehiculo identificado con placa {txtPlaca.Text} a la base de datos?", "Advertencia", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);

                    if (respuesta == DialogResult.OK)
                    {

                        if (controlVehiculo.ModificarVehiculo(txtPlaca.Text, txtModelo.Text, cbxGama.SelectedItem.ToString(), txtMarca.Text, cbxCapacidad.SelectedItem.ToString(), txtObservaciones.Text,txtPrecio.Text))
                        {
                            btnVaciarCampos_Click(sender, e);

                            MessageBox.Show("Modificacion exitosa", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se realizó ninguna modificación", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }

                    }
                }
                else
                {
                    MessageBox.Show("El vehiculo que desea eliminar no existe en la base de datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtPlaca.Text) && txtPlaca.ForeColor != Color.Red)
            {
                if(controlVehiculo.BuscarVehiculo(txtPlaca.Text))
                {
                    if (controlVehiculo.eliminarVehiculo(txtPlaca.Text))
                    {
                        btnVaciarCampos_Click(sender, e);

                        MessageBox.Show("Borrado exitoso", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("No se realizó el borrado", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("El vehiculo que desea eliminar no existe en la base de datos", "Informacion", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(txtPlaca.Text) && txtPlaca.ForeColor != Color.Red)
            {
                if (controlVehiculo.BuscarVehiculo(txtPlaca.Text))
                {
                    btnVaciarCampos.Visible = true;
                    txtPlaca.Enabled = false; //la placa no puede ser editada

                    String[] infoVeh = controlVehiculo.informacionVehiculo(txtPlaca.Text);

                    txtPlaca.Text = infoVeh[0];
                    txtModelo.Text = infoVeh[1];
                    cbxGama.Text = infoVeh[2];
                    txtMarca.Text = infoVeh[3];
                    cbxCapacidad.Text = infoVeh[4];
                    txtObservaciones.Text = infoVeh[5];
                    txtPrecio.Text = infoVeh[6];

                }
                else
                {
                    MessageBox.Show($"El vehiculo con placa {txtPlaca.Text} no se encuentra registrado en la base de datos", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Digite una placa válida");
            }
        }

        private void btnVaciarCampos_Click(object sender, EventArgs e)
        {
            txtPlaca.Enabled = true;
            txtPlaca.Text = "";
            txtModelo.Text = "";
            cbxGama.SelectedItem = null;
            txtMarca.Text = "";
            cbxCapacidad.SelectedItem = null;//
            txtObservaciones.Text = "";
            txtPrecio.Text = "";
            btnVaciarCampos.Visible = false; 
        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Inicio(frmLogin).Show();
            this.Close();
        }

        public Boolean ValidateData()
        {

            bool valido = true;
            String error = "";

            if (String.IsNullOrWhiteSpace(txtPlaca.Text) || txtPlaca.ForeColor == Color.Red)
                error += "Digite una placa válida \n";

            if (String.IsNullOrWhiteSpace(txtModelo.Text))
                error += "Ingrese un modelo válido en el campo Modelo \n";

            if (cbxGama.SelectedItem == null)
                error += "Por favor seleccione una gama \n";

            if (String.IsNullOrWhiteSpace(txtMarca.Text))
                error += "Ingrese una marca válida en el campo Marca \n";

            if (cbxCapacidad.SelectedItem == null)
                error += "Por favor seleccione una capacidad para el vehiculo \n";

            if (String.IsNullOrWhiteSpace(txtPrecio.Text))
                error += "Ingrese un precio válido en el campo Precio \n";

            if (txtCaracteres.ForeColor == Color.Red)
                error += "El campo observaciones debe ser menor a 400 caracteres";

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
