create database INVENET;
use INVENET;

create table Usuarios
(
	Id int identity(1,1) primary key,
	Usuario varchar(50) not null,
	Clave varchar(50) not null,
	Nombres varchar(50) not null,
	Apellidos varchar(50) not null,
	Fecha date default GETDATE()
);

create table Proveedores
(
	Id int identity(1,1) primary key,
	Nombre varchar(500) not null,
	Nit varchar(50) not null,
	Telefono varchar(50) not null,
	Fecha date default GETDATE()
);

create table Pedidos
(
	Id int identity(1,1) primary key,
	Estado varchar(50) default 'Creado',
	Total decimal not null,
	FechaCreacion date default GETDATE(),
	FechaAprobacion date,
	FechaRecepcion date
);

create table Categorias
(
	Id int identity(1,1) primary key,
	Nombre varchar(50) not null,
	Descripcion varchar(500),
	Fecha date default GETDATE()
);

create table Productos
(
	Id int identity(1,1) primary key,
	Nombre varchar(50) not null,
	Descripcion varchar(500),
	Marca varchar(50) not null,
	Precio decimal not null,
	Existencia int not null,
	FechaCreacion date,
	FechaCaducidad date,
	Fecha date default GETDATE(),
	IdProveedor int foreign key references Proveedores(Id),
	IdCategoria int foreign key references Categorias(Id)
);

create table DetallesPedidos
(
	Id int identity(1,1) primary key,
	Cantidad int not null,
	Subtotal decimal not null,
	Fecha date default GETDATE(),
	IdProducto int foreign key references Productos(Id),
	IdPedido int foreign key references Pedidos(Id)
);
