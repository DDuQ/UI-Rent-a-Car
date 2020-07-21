CREATE DATABASE Sirave
go
USE Sirave
go
CREATE TABLE Administrador(
	Cedula VARCHAR(11),
	Nombre Varchar(40),
	Correo Varchar(50),
	Usuario varchar(30),
	Contraseña Varchar(30),
	Telefono Varchar(11),
	PRIMARY KEY (Cedula)
)
CREATE TABLE Cliente(
	Cedula VARCHAR(11),
	Nombre Varchar(40),
	Correo Varchar(50),
	Usuario varchar(30),
	Contraseña Varchar(30),
	Telefono Varchar(11),
	PRIMARY KEY (Cedula)
)
CREATE TABLE Vehiculo(
	Placa Varchar(6),
	Modelo Varchar(30),
	Gama Varchar(30),
	Marca Varchar(30),
	Capacidad Smallint,
	Observaciones Varchar(400),
	precio Money,
	disponibilidad VARCHAR(20),
	cedulaCliente VARCHAR(11),
	fechaInicioAlquiler VARCHAR(30),
	fechaFinAlquiler VARCHAR(30), 
	PRIMARY KEY(Placa)
)
go

insert into Administrador(Cedula,Nombre,Correo,Usuario,Contraseña,Telefono) values ('1234','c','c@s.com','admin','1234','123')
go

ALTER TABLE Vehiculo ADD FOREIGN KEY (cedulaCliente)
REFERENCES Cliente (Cedula)






