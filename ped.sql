create database ped;
go

use ped;
go

create table cargos(
	id int identity primary key,
	cargo varchar(35) not null
);
GO

insert into cargos values('Administrador'),('Conductor'),('Cliente');
GO

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

SELECT id,nombre FROM usuarios WHERE licencia <> ''
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
GO

insert into usuarios(nombre,apellido,dui,edad,telefono,email,cargo,contrasenia) values
('Kevin','Galdamez','12345678-9',20,'7845-6863','kevingaldamezxd@gmail.com',1,'GM123');
go

select * from usuarios;
GO

create table coloresBuses(
	id int identity primary key,
	color varchar(50)
);
GO

insert into coloresBuses values ('Amarillo'),('Blanco'),('Aqua');
GO

create table marcasBuses(
	id int identity primary key,
	marca varchar(50)
);
GO

insert into marcasBuses values ('Mercedes Benz'),('Toyota'),('Hyundai');
GO
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
GO

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

/*create table ticket(
	id int identity primary key,
	viaje int foreign key references viajes(id),
	cliente int foreign key references usuarios(id),
	codigo varchar(35)
);
go*/



/*Inicio Kevin y Rodrigo*/

Create table Ruta(
id_ruta int identity primary key,
lugar varchar(200) not null,
)

Create table Destinos(
id_destino int identity primary key,
id_ruta int foreign key references Ruta(id_ruta),
destino1 varchar(50),
destino2 varchar(50),
destino3 varchar(50)
)

create table Viajes(
id_viaje int identity primary key,
id_ruta int foreign key references Ruta(id_ruta),
id_bus int foreign key references Bus(id), 
id_conductor int foreign key references usuarios(id), 
viaje varchar(100) not null,
fecha smalldatetime not null,
estado bit not null default 1 
)
GO
CREATE SEQUENCE Cod_asiento
AS smallint
START WITH 1
INCREMENT BY 1
NO CYCLE
NO CACHE

GO

create table asientos(
id_asiento int identity primary key,
id_viaje int foreign key references Viajes(id_viaje),
Destino varchar(100) not null default 'NULL', --opcion de ir vacios 
colorAsiento int not null default 0,--opcion de ir vacios
id_persona int not null default 0, --Opcion de ir vacios
codigo_asiento char(5) NOT NULL DEFAULT 'AS' + RIGHT('00' + CAST(NEXT VALUE FOR Cod_asiento AS varchar), 3),
)
/*select * from Viajes
INSERT INTO Viajes VALUES(17,1,2,'supraa','2020-12-12 10:20:00',1)
SELECT * FROM asientos
UPDATE top(1) asientos SET Destino = 'destino2', colorAsiento = 2 WHERE id_viaje = 19 AND Destino = 'NULL'*/
GO
CREATE TRIGGER GenerarAsientos 
ON Viajes
AFTER  INSERT
AS 
DECLARE @cnt INT = 0;
DECLARE @B INT = 0;
DECLARE @A INT = 0;

SELECT  @B = id_bus FROM INSERTED
SELECT @A = capacidad FROM Bus WHERE id = @B
PRINT @B
PRINT @A

WHILE @cnt < @A
BEGIN
INSERT INTO asientos(id_viaje) 
SELECT id_viaje from INSERTED
SET @cnt = @cnt + 1;
END
GO


create proc InsertRuta(
@ruta varchar(100)
)as
begin
INSERT INTO Ruta VALUES(@ruta);
SELECT SCOPE_IDENTITY();

end
go

/*Fin Kevin y Rodrigo*/


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


create proc psMostrarCargos
as
begin
	select * from cargos;
end;
GO

exec psMostrarCargos;
GO


--Este proc seria para usuarios que no sean clientes
/*create proc psInsertarUsuario(
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
GO*/


/*PROCEDIMIENTOS ANDRES*/


CREATE PROC MostrarConductores
as
SELECT usuarios.id as Id, usuarios.nombre AS Nombre, usuarios.apellido AS Apellido, usuarios.dui AS DUI, usuarios.edad AS Edad, usuarios.telefono AS Teléfono, usuarios.email AS Correo, usuarios.contrasenia as Contraseña, usuarios.licencia AS Licencia FROM usuarios where cargo = 2;
go

exec MostrarConductores;
GO

CREATE PROC InsertarConductores
@nombre varchar(50),
@apellido varchar(50),
@dui varchar(10),
@edad int,
@telefono varchar(9),
@email varchar(50),
@pass varchar(35),
@licencia varchar(17)
AS
INSERT INTO usuarios (nombre, apellido, dui, edad, telefono, email, cargo, contrasenia, licencia) 
		VALUES (@nombre, @apellido, @dui, @edad, @telefono, @email, 2, @pass, @licencia)
GO

exec InsertarConductores 'Test', 'Test A', '11112222-9', 40, '1234-1234', 'test@gmail.com', '11111', '1234-666666-123-1';
GO


CREATE PROC EditarConductores
@nombre varchar(50),
@apellido varchar(50),
@dui varchar(10),
@edad int,
@telefono varchar(9),
@email varchar(50),
@pass varchar(35),
@licencia varchar(17),
@id int
AS
UPDATE usuarios SET nombre=@nombre, apellido=@apellido, dui=@dui, edad=@edad, telefono=@telefono, email=@email, contrasenia=@pass, licencia=@licencia
WHERE id=@id
GO

CREATE PROC EliminarConductores
@id int
AS
DELETE FROM usuarios WHERE id = @id
GO



/*FIN PROC ANDRES*/

