using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Control
{
    public class Validaciones
    {

        /// <summary>
        /// codigo validarEmail tomado de: https://webprogramacion.com/108/csharp/validacion-de-una-direccion-de-correo-electronico.aspx
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>

        public bool validarEmail(string email)
        {

            String expresion;

            expresion = "\\w+([-+.']\\w+)*@\\w+([-.]\\w+)*\\.\\w+([-.]\\w+)*";

            if (Regex.IsMatch(email, expresion))
            {
                if (Regex.Replace(email, expresion, String.Empty).Length == 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }


        }

        /// <summary>
        /// Valida si la placa contiene letras y números
        /// </summary>
        /// <param name="Placa"></param>
        /// <returns></returns>

        public Boolean validarPlaca(String Placa)
        {
            if (Regex.IsMatch(Placa, "^[aA-zZ]{1,5}[0-9]{1,5}$"))
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        /// <summary>
        /// Valida que la fecha inicio no sea mayor a la fecha final del alquiler
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="fechaFin"></param>
        /// <returns></returns>

        public Boolean validarFechas(DateTime fechaInicio, DateTime fechaFin)
        {
            try
            {
                int result = DateTime.Compare(fechaInicio, fechaFin);

                if (result >= 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error " + ex.Message);
                return false;
            }
        }

    }
}
