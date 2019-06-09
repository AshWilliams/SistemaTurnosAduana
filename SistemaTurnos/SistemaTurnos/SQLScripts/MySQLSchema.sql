/* SQLEditor (MySQL (2))*/


CREATE TABLE CalidadJuridica
(
IdCalidadJuridica INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
VTipoCalidadJuridica VARCHAR(20),
PRIMARY KEY (IdCalidadJuridica)
);

CREATE TABLE Estado
(
IdEstado INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
VDescripcionEstado VARCHAR(255),
PRIMARY KEY (IdEstado)
);

CREATE TABLE Lugar
(
IdLugar INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
VDescripcionLugar VARCHAR(255),
PRIMARY KEY (IdLugar)
);

CREATE TABLE Rol
(
IdRol INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
VNombreRol VARCHAR(20),
PRIMARY KEY (IdRol)
);

CREATE TABLE TipoContrato
(
IdTipoContrato INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
IdCalidadJuridica INTEGER(10),
IDuracion INTEGER(10),
PRIMARY KEY (IdTipoContrato)
);

CREATE TABLE TipoPermiso
(
IdTipoPermiso INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
VDescripcionPermiso VARCHAR(255),
PRIMARY KEY (IdTipoPermiso)
);

CREATE TABLE TipoUsuario
(
IdTipoUsuario INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
TipoUsuario VARCHAR(20),
Permisos VARCHAR(20),
IdRol INTEGER(10),
PRIMARY KEY (IdTipoUsuario)
);

CREATE TABLE Turnos
(
IdTurno INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
VNombreTurno VARCHAR(255),
PRIMARY KEY (IdTurno)
);

CREATE TABLE Usuario
(
IdUsuario INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
VEmail VARCHAR(50),
VPass VARCHAR(20),
VRut VARCHAR(10),
VNombre CHAR(20),
VApellido CHAR(20),
IdTipoUsuario INTEGER(10),
PRIMARY KEY (IdUsuario)
);

CREATE TABLE TurnoUsuario
(
IdTurnoUsuario INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
DFechaincio DATE,
DFechaTermino DATE,
IdLugar INTEGER(10),
IdTurno INTEGER(10),
IdUsuario INTEGER(10),
PRIMARY KEY (IdTurnoUsuario)
);

CREATE TABLE Contrato
(
IdContrato INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
DFechaInicio DATE,
DFechaFin DATE,
IdTipoContrato INTEGER(10),
IdUsuario INTEGER(10),
PRIMARY KEY (IdContrato)
);

CREATE TABLE Permisos
(
IdPermisos INT(10) NOT NULL AUTO_INCREMENT UNIQUE ,
DFechaInicio DATE,
ICantDias INT(3),
ICantHoras INT(3),
DFechaFin DATE,
IdTipoPermiso INTEGER(10),
IdUsuario INTEGER(10),
PRIMARY KEY (IdPermisos)
);

CREATE TABLE CambioTurno
(
IdCambioTurno INTEGER(10) NOT NULL AUTO_INCREMENT UNIQUE ,
IdUsuario INTEGER(10),
IdUsuarioold INTEGER(10),
IdEstado INTEGER(10),
VObservaciones VARCHAR(255),
IdTurnoUsuario INTEGER(10),
PRIMARY KEY (IdCambioTurno)
);

ALTER TABLE TipoContrato ADD FOREIGN KEY IdCalidadJuridica_idxfk (IdCalidadJuridica) REFERENCES CalidadJuridica (IdCalidadJuridica);

ALTER TABLE TipoUsuario ADD FOREIGN KEY IdRol_idxfk (IdRol) REFERENCES Rol (IdRol);

ALTER TABLE Usuario ADD FOREIGN KEY IdTipoUsuario_idxfk (IdTipoUsuario) REFERENCES TipoUsuario (IdTipoUsuario);

ALTER TABLE TurnoUsuario ADD FOREIGN KEY IdLugar_idxfk (IdLugar) REFERENCES Lugar (IdLugar);

ALTER TABLE TurnoUsuario ADD FOREIGN KEY IdTurno_idxfk (IdTurno) REFERENCES Turnos (IdTurno);

ALTER TABLE TurnoUsuario ADD FOREIGN KEY IdUsuario_idxfk (IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE Contrato ADD FOREIGN KEY IdTipoContrato_idxfk (IdTipoContrato) REFERENCES TipoContrato (IdTipoContrato);

ALTER TABLE Contrato ADD FOREIGN KEY IdUsuario_idxfk_1 (IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE Permisos ADD FOREIGN KEY IdTipoPermiso_idxfk (IdTipoPermiso) REFERENCES TipoPermiso (IdTipoPermiso);

ALTER TABLE Permisos ADD FOREIGN KEY IdUsuario_idxfk_2 (IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE CambioTurno ADD FOREIGN KEY IdUsuario_idxfk_3 (IdUsuario) REFERENCES Usuario (IdUsuario);

ALTER TABLE CambioTurno ADD FOREIGN KEY IdUsuarioold_idxfk (IdUsuarioold) REFERENCES Usuario (IdUsuario);

ALTER TABLE CambioTurno ADD FOREIGN KEY IdEstado_idxfk (IdEstado) REFERENCES Estado (IdEstado);

ALTER TABLE CambioTurno ADD FOREIGN KEY IdTurnoUsuario_idxfk (IdTurnoUsuario) REFERENCES TurnoUsuario (IdTurnoUsuario);
