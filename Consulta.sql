DROP TABLE IF EXISTS Inscripcion;
DROP TABLE IF EXISTS Clase;
DROP TABLE IF EXISTS Miembro;

CREATE TABLE Miembro (
    id_miembro INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre TEXT NOT NULL,
    telefono TEXT NOT NULL
);

CREATE TABLE Clase (
    id_clase INTEGER PRIMARY KEY AUTOINCREMENT,
    nombre_clase TEXT NOT NULL,
    dia_semana TEXT NOT NULL,
    horario TEXT NOT NULL
);

CREATE TABLE Inscripcion (
    id_inscripcion INTEGER PRIMARY KEY AUTOINCREMENT,
    id_miembro INTEGER NOT NULL,
    id_clase INTEGER NOT NULL,

    FOREIGN KEY (id_miembro) REFERENCES Miembro(id_miembro),
    FOREIGN KEY (id_clase) REFERENCES Clase(id_clase)
);
INSERT INTO Miembro (nombre, telefono) VALUES
('Ana Pérez', '8091234567'),
('Luis Gómez', '8292345678'),
('María López', '8493456789'),
('Carlos Rodríguez', '8094567890'),
('Sofía Martínez', '8295678901')

INSERT INTO Clase (nombre_clase, dia_semana, horario) VALUES
('Yoga', 'Lunes', '6:00 PM'),
('Spinning', 'Martes', '7:00 PM'),
('Zumba', 'Miércoles', '5:00 PM'),
('Pilates', 'Jueves', '6:30 PM'),
('CrossFit', 'Viernes', '7:30 PM');

INSERT INTO Inscripcion (id_miembro, id_clase) VALUES
(1, 1),
(1, 3),
(2, 2),
(3, 1),
(3, 4),
(4, 5),
(5, 3),
(5, 2),
(2, 4),
(4, 1);