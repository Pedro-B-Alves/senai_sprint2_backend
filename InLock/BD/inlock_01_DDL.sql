CREATE DATABASE inlock_games_manha;
GO

USE inlock_games_manha;
GO

CREATE TABLE estudios(
idEstudio int primary key identity,
nomeEstudio varchar(200));
GO

CREATE TABLE jogos(
idJogo int primary key identity,
nomeJogo varchar(200),
descricao varchar(500),
dataLancamento date,
valor smallmoney,
idEstudio int foreign key references estudios);
GO
CREATE TABLE tiposUsuarios(
idTipoUsuario int primary key identity,
titulo varchar(100));
GO

CREATE TABLE usuarios(
idUsuario int primary key identity,
email varchar(200),
senha varchar(50),
idTipoUsuario int foreign key references tiposUsuarios)
GO