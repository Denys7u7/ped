create database ped;
go

use ped;
go

create table cargos(
	id int identity primary key,
	cargo varchar(35) not null
);

insert into cargos values('Administrador'),('Conductor'),('Cliente');


/*create table destinos(
	id int identity primary key,
	destino varchar(50),
	lejania int
);

create table rutas(
	id int identity primary key,
	destino int foreign key references destinos(id),
);

create table estacionesRuta(
	idRuta int foreign key references rutas(id),
	idEstaciones int foreign key references destinos(id)
);*/


create table usuarios(
	id int identity primary key,
	nombre varchar(50) not null,
	apellido varchar(50) not null,
	dui varchar(10) unique check(dui LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9][-][0-9]'),
	edad int not null check(edad > 17),
	--nacionalidad varchar(50) not null,
	telefono varchar(9) unique check(telefono LIKE '[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]'),
	email varchar(50) null check (email LIKE '%@%'),
	--CAMPO EMPLEADO
	cargo int foreign key references cargos(id),
	contrasenia varchar(35),
	--CAMPO CONDUCTOR
	licencia varchar(17) check(licencia LIKE '[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][-][0-9]'),
);


insert into usuarios(nombre,apellido,dui,edad,telefono,email,contrasenia,cargo) values
('Denys','Cruz','12345678-9',20,'7865-9863','dennys@gmail.com','12345',1);
go

select * from usuarios;

create table coloresBuses(
	id int identity primary key,
	color varchar(50)
);

insert into coloresBuses values ('Amarillo'),('Blanco'),('Aqua');

create table marcasBuses(
	id int identity primary key,
	marca varchar(50)
);

insert into marcasBuses values ('Mercedes Benz'),('Toyota'),('Hyundai');

/*create table clasificacionAsientos(
	id int identity primary key,
	clasificacion varchar(30) not null
)*/

create table bus(
	id int identity primary key,
	placa varchar(8) unique check(placa LIKE 'AB%'),
	color int foreign key references coloresBuses(id),
	marca int foreign key references marcasBuses(id),
	capacidad int,
	caracteristicas varchar(500)
);
go


insert into bus values ('AB1234',1,1,60,'Bonito');

create proc insertarBus(
@placa varchar(8), @color int, @marca int, @capacidad int, @caracteristicas varchar(500)
) as
begin
	insert into bus values(@placa,@color,@marca,@capacidad,@caracteristicas);
end;
GO

create proc modificarBus(
@id int, @placa varchar(8), @color int, @marca int, @capacidad int, @caracteristicas varchar(500)
) as
begin
	update bus set placa = @placa, color = @color, marca = @marca, capacidad = @capacidad, caracteristicas = @caracteristicas where id = @id;
	--insert into bus values(@placa,@color,@marca,@capacidad,@caracteristicas);
end;
GO

create proc eliminarBus(
@id int
) as
begin
	delete from bus where id = @id;
end;
GO

create proc mostrarBus as
begin
	select bus.id, placa, coloresBuses.color, marcasBuses.marca, capacidad, caracteristicas from bus join coloresBuses on bus.color = coloresBuses.id
	join marcasBuses on bus.marca = marcasBuses.id;
end;
GO


/*create table asientos(
	id int identity primary key,
	bus int foreign key references bus(id) not null,
	numero int not null,
	clasificacion int foreign key references clasificacionAsientos(id)
);

create table viajes(
	id int identity primary key,
	fecha date not null,
	horaPartida time not null,
	horaLlegada time,
	ruta int foreign key references rutas(id) not null,
	bus int foreign key references bus(id) not null
);*/

create table ticket(
	id int identity primary key,
	viaje int foreign key references viajes(id),
	cliente int foreign key references usuarios(id),
	codigo varchar(35)
);
go

create proc logearse
(
@email varchar(50),
@pass nvarchar(30)
) as
begin
	select top 1 nombre from usuarios where email=@email AND contrasenia = @pass;
end
GO

create proc psInsertarCargo(
	@cargo varchar(35)
) as
begin
	insert into cargos values (@cargo);
end;
GO

exec psInsertarCargo 'Administrador';
GO
exec psInsertarCargo 'Conductor';
GO


create proc psMostrarCargos
as
begin
	select * from cargos;
end;
GO

exec psMostrarCargos;
GO


--Este proc seria para usuarios que no sean clientes
create proc psInsertarUsuario(
	@nombre varchar(50),
	@apellido varchar(50),
	@dui varchar(10),
	@edad int,
	@nacionalidad varchar(50),
	@telefono varchar(9),
	@email varchar(50),
	@pass varchar(35),
	@cargo int,
	@licencia varchar(17)
) as
begin
	


	insert into usuarios(nombre,apellido,dui,edad,nacionalidad,telefono,email,contrasenia,cargo) values
	(@nombre,@apellido,@dui,@edad,@nacionalidad,@telefono,@email,@pass,@cargo);
end;
GO