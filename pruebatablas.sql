-- Crear tablas sin dependencias primero
CREATE TABLE Usuario (
    idUsuario INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    email VARCHAR(100) NOT NULL UNIQUE,
    contraseña VARCHAR(255) NOT NULL,
    rol VARCHAR(50) CHECK (rol IN ('encargado', 'administrador', 'cliente', 'recepcionista')) NOT NULL
);

CREATE TABLE Actividad (
    idActividad INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    descripcion TEXT,
    nivelIntensidad VARCHAR(50),
    sala INT,
    plazasDisponibles INT DEFAULT 16
);

-- Crear tablas que dependen de las anteriores
CREATE TABLE Cliente (
    idCliente INT IDENTITY(1,1) PRIMARY KEY,
    telefono VARCHAR(15),
    direccion VARCHAR(255),
    idUsuario INT,
    FOREIGN KEY (idUsuario) REFERENCES Usuario(idUsuario)
);

CREATE TABLE Monitor (
    idMonitor INT IDENTITY(1,1) PRIMARY KEY,
    nombre VARCHAR(100) NOT NULL,
    apellido VARCHAR(100) NOT NULL,
    idActividad INT,
    FOREIGN KEY (idActividad) REFERENCES Actividad(idActividad)
);

-- Modificar Actividad para agregar la clave foránea a Monitor
ALTER TABLE Actividad
ADD idMonitor INT,
FOREIGN KEY (idMonitor) REFERENCES Monitor(idMonitor);

CREATE TABLE Horario (
    idHorario INT IDENTITY(1,1) PRIMARY KEY,
    diaSemana VARCHAR(15) NOT NULL,
    horaInicio TIME NOT NULL,
    horaFin TIME NOT NULL,
    idActividad INT,
    FOREIGN KEY (idActividad) REFERENCES Actividad(idActividad)
);

CREATE TABLE Reserva (
    idReserva INT IDENTITY(1,1) PRIMARY KEY,
    idCliente INT,
    idHorario INT,
    FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente),
    FOREIGN KEY (idHorario) REFERENCES Horario(idHorario)
);

CREATE TABLE ListaEspera (
    idListaEspera INT IDENTITY(1,1) PRIMARY KEY,
    idActividad INT,
    idHorario INT,
    idCliente INT,
    posicion INT,
    FOREIGN KEY (idActividad) REFERENCES Actividad(idActividad),
    FOREIGN KEY (idHorario) REFERENCES Horario(idHorario),
    FOREIGN KEY (idCliente) REFERENCES Cliente(idCliente)
);
