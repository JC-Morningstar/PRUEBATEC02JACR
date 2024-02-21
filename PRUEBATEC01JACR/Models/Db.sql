-- base de datos "Dd"
CREATE DATABASE Dd;
USE Dd;
-- tabla de Músicos
CREATE TABLE Musicos (
    id INT PRIMARY KEY,
    nombre VARCHAR(50),
    instrumento VARCHAR(50),
    edad INT,
    banda_id INT,FOREIGN KEY (banda_id) REFERENCES Bandas(id)
);

-- tabla de Bandas
CREATE TABLE Bandas (
    id INT PRIMARY KEY,
    nombre VARCHAR(50),
    genero VARCHAR(50),
    año_formacion INT
	imagen VARCHAR(100);
);
	ALTER TABLE Bandas
ADD imagen varbinary(max);