using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo
{
    public class Administrador
    {
        private String cedula;
        private String nombre;
        private String correo;
        private String usuario;
        private String contraseña;
        private String telefono;

        public Administrador() 
        {
        }

        public Administrador(string cedula, string nombre, string correo, string usuario, string contraseña, string telefono)
        {
            this.Cedula = cedula;
            this.Nombre = nombre;
            this.Correo = correo;
            this.Usuario = usuario;
            this.Contraseña = contraseña;
            this.Telefono = telefono;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Telefono { get => telefono; set => telefono = value; }


    }
    public class Cliente
    {
        private String cedula;
        private String nombre;
        private String correo;
        private String usuario;
        private String contraseña;
        private String telefono;

        public Cliente()
        {
        }

        public Cliente(string cedula, string nombre, string correo, string usuario, string contraseña, string telefono)
        {
            this.cedula = cedula;
            this.nombre = nombre;
            this.correo = correo;
            this.usuario = usuario;
            this.contraseña = contraseña;
            this.telefono = telefono;
        }

        public string Cedula { get => cedula; set => cedula = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Usuario { get => usuario; set => usuario = value; }
        public string Contraseña { get => contraseña; set => contraseña = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        
    }
    public class Vehiculo
    {
        private String placa;
        private String modelo;
        private String gama;
        private String marca;
        private int capacidad;
        private String observaciones;
        private double precio;
        private String disponibilidad;
        private String cedulaCliente;
        private DateTime fechaInicioAlquiler;
        private DateTime fechaFinAlquiler;
        
        public Vehiculo()
        {
        }

        public Vehiculo(string placa, string modelo, string gama, string marca, int capacidad, string observaciones, double precio, String disponibilidad, string cedulaCliente, DateTime fechaInicioAlquiler, DateTime fechaFinAlquiler)
        {
            this.placa = placa;
            this.modelo = modelo;
            this.gama = gama;
            this.marca = marca;
            this.capacidad = capacidad;
            this.observaciones = observaciones;
            this.precio = precio;
            this.disponibilidad = disponibilidad;
            this.cedulaCliente = cedulaCliente;
            this.fechaInicioAlquiler = fechaInicioAlquiler;
            this.fechaFinAlquiler = fechaFinAlquiler;
        }

        public string Placa { get => placa; set => placa = value; }
        public string Modelo { get => modelo; set => modelo = value; }
        public string Gama { get => gama; set => gama = value; }
        public string Marca { get => marca; set => marca = value; }
        public int Capacidad { get => capacidad; set => capacidad = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public double Precio { get => precio; set => precio = value; }
        public String Disponibilidad { get => disponibilidad; set => disponibilidad = value; }
        public string CedulaCliente { get => cedulaCliente; set => cedulaCliente = value; }
        public DateTime FechaInicioAlquiler { get => fechaInicioAlquiler; set => fechaInicioAlquiler = value; }
        public DateTime FechaFinAlquiler { get => fechaFinAlquiler; set => fechaFinAlquiler = value; }
    }
}

