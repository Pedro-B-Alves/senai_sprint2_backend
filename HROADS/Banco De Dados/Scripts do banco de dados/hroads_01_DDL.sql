CREATE DATABASE SENAI_HROADS_MANHA;
GO

USE SENAI_HROADS_MANHA;
GO

CREATE TABLE TipoDeHabilidade
(
	idTipoHab	INT PRIMARY KEY IDENTITY
	,Tipo		VARCHAR(150) NOT NULL
);
GO

CREATE TABLE Habilidade
(
	idHab INT PRIMARY KEY IDENTITY
	,Habilidade VARCHAR(150) NOT NULL
	,idTipoHab INT FOREIGN KEY REFERENCES TipoDeHabilidade (idTipoHab)
);
GO

CREATE TABLE Classe
(
	idClasse INT PRIMARY KEY IDENTITY
	,Classe VARCHAR(150) NOT NULL
);
GO

CREATE TABLE ClasseHabilidade
(
	idClasse	INT FOREIGN KEY REFERENCES Classe (idClasse)
	,idHab		INT FOREIGN KEY REFERENCES Habilidade (idHab)
);
GO

CREATE TABLE Personagem
(
	idPersonagem INT PRIMARY KEY IDENTITY
	,Nome VARCHAR(150) NOT NULL
	,CapVida VARCHAR(150) NOT NULL
	,CapMana VARCHAR(150) NOT NULL
	,DataAtualizacao VARCHAR(150) NOT NULL
	,DataCriacao VARCHAR(150) NOT NULL
	,idClasse INT FOREIGN KEY REFERENCES Classe (idClasse)
);
GO

CREATE TABLE TipoUsuario
(
	idTipoUsuario INT PRIMARY KEY IDENTITY
	,tipo VARCHAR(150) NOT NULL
);
GO

CREATE TABLE Usuario
(
	idUsuario INT PRIMARY KEY IDENTITY
	,email VARCHAR(150) NOT NULL
	,senha VARCHAR(150) NOT NULL
	,idTipoUsuario INT FOREIGN KEY REFERENCES TipoUsuario (idTipoUsuario)
);
GO