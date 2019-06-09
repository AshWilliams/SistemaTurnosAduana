CREATE TABLE CalidadJuridica
(
IdCalidadJuridica INTEGER NOT NULL IDENTITY UNIQUE ,
VTipoCalidadJuridica VARCHAR(20),
PRIMARY KEY (IdCalidadJuridica)
);

CREATE TABLE Estado
(
IdEstado INTEGER NOT NULL IDENTITY UNIQUE ,
VDescripcionEstado VARCHAR(255),
PRIMARY KEY (IdEstado)
);

CREATE TABLE Lugar
(
IdLugar INTEGER NOT NULL IDENTITY UNIQUE ,
VDescripcionLugar VARCHAR(255),
PRIMARY KEY (IdLugar)
);

CREATE TABLE Rol
(
IdRol INTEGER NOT NULL IDENTITY UNIQUE ,
VNombreRol VARCHAR(20),
PRIMARY KEY (IdRol)
);

CREATE TABLE TipoContrato
(
IdTipoContrato INTEGER NOT NULL IDENTITY UNIQUE ,
IdCalidadJuridica INTEGER,
IDuracion INTEGER,
PRIMARY KEY (IdTipoContrato)
);

CREATE TABLE TipoPermiso
(
IdTipoPermiso INTEGER NOT NULL IDENTITY UNIQUE ,
VDescripcionPermiso VARCHAR(255),
PRIMARY KEY (IdTipoPermiso)
);

CREATE TABLE TipoUsuario
(
IdTipoUsuario INTEGER NOT NULL IDENTITY UNIQUE ,
TipoUsuario VARCHAR(20),
Permisos VARCHAR(20),
IdRol INTEGER,
PRIMARY KEY (IdTipoUsuario)
);

CREATE TABLE Turnos
(
IdTurno INTEGER NOT NULL IDENTITY UNIQUE ,
VNombreTurno VARCHAR(255),
PRIMARY KEY (IdTurno)
);

CREATE TABLE Usuario
(
IdUsuario INTEGER NOT NULL IDENTITY UNIQUE ,
VEmail VARCHAR(50),
VPass VARCHAR(20),
VRut VARCHAR(10),
VNombre CHAR(20),
VApellido CHAR(20),
IdTipoUsuario INTEGER,
PRIMARY KEY (IdUsuario)
);

CREATE TABLE TurnoUsuario
(
IdTurnoUsuario INTEGER NOT NULL IDENTITY UNIQUE ,
DFechaincio DATE,
DFechaTermino DATE,
IdLugar INTEGER,
IdTurno INTEGER,
IdUsuario INTEGER,
PRIMARY KEY (IdTurnoUsuario)
);

CREATE TABLE Contrato
(
IdContrato INTEGER NOT NULL IDENTITY UNIQUE ,
DFechaInicio DATE,
DFechaFin DATE,
IdTipoContrato INTEGER,
IdUsuario INTEGER,
PRIMARY KEY (IdContrato)
);

CREATE TABLE Permisos
(
IdPermisos INT NOT NULL IDENTITY UNIQUE ,
DFechaInicio DATE,
ICantDias INT,
ICantHoras INT,
DFechaFin DATE,
IdTipoPermiso INTEGER,
IdUsuario INTEGER,
PRIMARY KEY (IdPermisos)
);

CREATE TABLE CambioTurno
(
IdCambioTurno INTEGER NOT NULL IDENTITY UNIQUE ,
IdUsuario INTEGER,
IdUsuarioold INTEGER,
IdEstado INTEGER,
VObservaciones VARCHAR(255),
IdTurnoUsuario INTEGER,
PRIMARY KEY (IdCambioTurno)
);

ALTER TABLE TipoContrato ADD CONSTRAINT IdCalidadJuridica_idxfk  FOREIGN KEY(IdCalidadJuridica) REFERENCES CalidadJuridica (IdCalidadJuridica);

ALTER TABLE TipoUsuario ADD CONSTRAINT IdRol_idxfk  FOREIGN KEY(IdRol) REFERENCES Rol (IdRol);

ALTER TABLE Usuario ADD CONSTRAINT IdTipoUsuario_idxfk  FOREIGN KEY(IdTipoUsuario) REFERENCES TipoUsuario (IdTipoUsuario);

ALTER TABLE TurnoUsuario ADD CONSTRAINT IdLugar_idxfk  FOREIGN KEY(IdLugar) REFERENCES Lugar (IdLugar);

ALTER TABLE TurnoUsuario ADD CONSTRAINT IdTurno_idxfk  FOREIGN KEY(IdTurno) REFERENCES Turnos (IdTurno);

ALTER TABLE TurnoUsuario ADD CONSTRAINT IdUsuario_idxfk FOREIGN KEY(IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE Contrato ADD CONSTRAINT IdTipoContrato_idxfk FOREIGN KEY(IdTipoContrato) REFERENCES TipoContrato (IdTipoContrato);

ALTER TABLE Contrato ADD CONSTRAINT IdUsuario_idxfk_1 FOREIGN KEY(IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE Permisos ADD CONSTRAINT IdTipoPermiso_idxfk FOREIGN KEY (IdTipoPermiso) REFERENCES TipoPermiso (IdTipoPermiso);

ALTER TABLE Permisos ADD CONSTRAINT IdUsuario_idxfk_2  FOREIGN KEY(IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE CambioTurno ADD CONSTRAINT IdUsuario_idxfk_3  FOREIGN KEY(IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE CambioTurno ADD CONSTRAINT IdUsuarioold_idxfk  FOREIGN KEY(IdUsuarioold) REFERENCES Usuario (IdUsuario);

ALTER TABLE CambioTurno ADD CONSTRAINT IdEstado_idxfk  FOREIGN KEY(IdEstado) REFERENCES Estado (IdEstado);

ALTER TABLE CambioTurno ADD CONSTRAINT IdTurnoUsuario_idxfk  FOREIGN KEY(IdTurnoUsuario) REFERENCES TurnoUsuario (IdTurnoUsuario);
