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
using Modelo;

namespace Vista
{
    public partial class Reserva : Form
    {
        #region Atributos

        Login frmLogin;
        ControlReserva controlReserva;
        Validaciones validar;
        Object[] vecVehiculo;

        #endregion

        #region Constructores

        public Reserva()
        {
            InitializeComponent();
            controlReserva = new ControlReserva();
            validar = new Validaciones();
        }

        /// <summary>
        /// Recibe el objeto con la información del objeto login, Inicializa los componentes de reserva
        /// y llena el combobox del frame con los vehiculos y cedulas de clientes existentes en la BD
        /// </summary>
        /// <param name="frmLogin"></param>

        public Reserva(Login frmLogin)
        {
            InitializeComponent();
            this.frmLogin = frmLogin;
            controlReserva = new ControlReserva();
            validar = new Validaciones();

            //Llenar combobox de placas y cedulas
            cbxPlaca = controlReserva.cargarComboBoxDePlacas(cbxPlaca);
            cbxCedula = controlReserva.cargarComboBoxDeCedulas(cbxCedula); 
        }

        #endregion

        #region Metodos

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Inicio(frmLogin).Show();
            this.Close();
        }

        /// <summary>
        /// Llena los campos del frame con información según la placa del vehiculo seleccionada dependiendo de si este está reservado o no
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void cbxPlaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(cbxPlaca.SelectedItem != null)
            {
                vecVehiculo = controlReserva.informacionVehiculo(cbxPlaca.SelectedItem.ToString());

                if (vecVehiculo[8] == null) //si la cedula es nula significa que el vehiculo no está reservado
                {

                    cbxCedula.Enabled = true;
                    cbxCedula.SelectedItem = null;
                    txtDisponibilidad.Text = "Disponible";

                    dateInicioAlquiler.Format = DateTimePickerFormat.Custom;
                    dateFinAlquiler.Format = DateTimePickerFormat.Custom;

                    dateInicioAlquiler.CustomFormat = " ";
                    dateFinAlquiler.CustomFormat = " ";
                }
                else
                {
                    dateInicioAlquiler.Format = DateTimePickerFormat.Long;
                    dateFinAlquiler.Format = DateTimePickerFormat.Long;

                    cbxCedula.Enabled = false;
                    cbxCedula.Text = vecVehiculo[8].ToString();
                    txtDisponibilidad.Text = "En Reserva";
                    dateInicioAlquiler.Value = Convert.ToDateTime(vecVehiculo[9]);
                    dateFinAlquiler.Value = Convert.ToDateTime(vecVehiculo[10]);
                }
            }
        }

        /// <summary>
        /// Valida que los campos sean correctamente digitados, al igual que las fechas si coincidan y vacía los campos luego de realizada o no la reserva.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnCrear_Click(object sender, EventArgs e)
        {
            if(cbxPlaca.SelectedItem != null)
            {
                if (vecVehiculo[7].Equals("Disponible"))
                {
                    if(cbxCedula.SelectedItem != null)
                    {
                        if(validar.validarFechas(dateInicioAlquiler.Value, dateFinAlquiler.Value))
                        {
                            vecVehiculo[7] = "En Reserva"; //Actualiza la disponibilidad
                            vecVehiculo[8] = cbxCedula.SelectedItem.ToString(); //Asigna la cedula del reservador
                            vecVehiculo[9] = dateInicioAlquiler.Value; //Asigna la fecha de inicio de alquiler
                            vecVehiculo[10] = dateFinAlquiler.Value; //Asgigna la fecha fin del alquiler

                            if (controlReserva.realizarReserva(vecVehiculo))
                            {
                                MessageBox.Show($"Se ha reservado exitosamente el vehiculo de placa {cbxPlaca.Text} al cliente con cedula {cbxCedula.Text}", "Avisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("No se registró la reserva");
                                vecVehiculo[8] = null;
                                vecVehiculo[7] = "Disponible";

                            }

                            VaciarCampos();

                        }
                        else
                        {
                            MessageBox.Show("Error en las fechas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        MessageBox.Show("Elija el cliente que reservará el vehiculo", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("La reserva no puede ser creada porque esta reserva ya existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo para reservar", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }
        
        /// <summary>
        /// valida que los campos estén llenos y las fechas ingresadas coincidan y vacía los campos luego de realizarse o no la modificación
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (cbxPlaca.SelectedItem != null)
            {
                if (!vecVehiculo[7].Equals("Disponible")) //Si esto se cumple significa que la reserva existe
                {
                    if (validar.validarFechas(dateInicioAlquiler.Value, dateFinAlquiler.Value))
                    {
                        vecVehiculo[9] = dateInicioAlquiler.Value; //Asigna la fecha de inicio de alquiler
                        vecVehiculo[10] = dateFinAlquiler.Value; //Asgigna la fecha fin del alquiler

                        if (controlReserva.modificarReserva(vecVehiculo))
                        {
                            MessageBox.Show($"Se ha modificado la reserva exitosamente para el vehiculo de placa {cbxPlaca.Text} al cliente con cedula {cbxCedula.Text}", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            
                        }
                        else
                        {
                            MessageBox.Show("No se modificó la reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        VaciarCampos();
                    }
                    else
                    {
                        MessageBox.Show("Error en las fechas", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("No se puede modificar una reserva sin ser creada", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo para modficar su reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Deja en blanco todos los campos del frame.
        /// </summary>

        private void VaciarCampos()
        {
            cbxPlaca.SelectedItem = null;
            cbxCedula.SelectedItem = null;
            txtDisponibilidad.Text = "";

            dateInicioAlquiler.Format = DateTimePickerFormat.Custom;
            dateFinAlquiler.Format = DateTimePickerFormat.Custom;

            dateInicioAlquiler.CustomFormat = " ";
            dateFinAlquiler.CustomFormat = " ";
        }

        /// <summary>
        /// valida que si se haya seleccionado la placa del vehiculo y elimina la reserva hecha al vehiculo siempre y cuando este si esté en estado de reserva
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (cbxPlaca.SelectedItem != null)
            {
                if (!vecVehiculo[7].Equals("Disponible")) //Si esto se cumple significa que la reserva existe
                {

                        if (controlReserva.deshacerReserva(cbxPlaca.SelectedItem.ToString()))
                        {
                            MessageBox.Show($"¡Listo! el vehiculo de placa {cbxPlaca.Text} nuevamente está disponible para ser reservado", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se deshizo la reserva", "Adevertencia", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }

                        VaciarCampos();
                }
                else
                {
                    MessageBox.Show("La reserva no puede ser desecha puesto que no existe", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
            else
            {
                MessageBox.Show("Seleccione un vehiculo para eliminar la reserva", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// Asigna al campo de fecha de inicio en alquiler el formato predeterminado Long
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dateInicioAlquiler_ValueChanged(object sender, EventArgs e)
        {
            dateInicioAlquiler.Format = DateTimePickerFormat.Long;
        }

        /// <summary>
        /// Asigna al campo de fecha de inicio en alquiler el formato predeterminado Long
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void dateFinAlquiler_ValueChanged(object sender, EventArgs e)
        {
            dateFinAlquiler.Format = DateTimePickerFormat.Long;
        }

        #endregion
    }
}
