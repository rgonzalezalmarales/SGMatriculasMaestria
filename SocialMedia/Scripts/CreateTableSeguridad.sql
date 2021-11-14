CREATE TABLE Seguridad (
	IdSeguridad INT PRIMARY KEY IDENTITY(1,1) NOT NULL,
	Usuario varchar(50) NOT NULL,
	NombreUsuario varchar(100) NOT NULL,
	Contrasena varchar(200) NOT NULL,
	Rol varchar(15) NOT NULL
);

/*INSERT INTO Seguridad VALUES(1, "admin", "Administrador","xxx","Admin");*/