CREATE DATABASE M_Peoples;
GO

USE M_Peoples;
GO

CREATE TABLE funcionario
(
	idFuncionario	INT PRIMARY KEY IDENTITY
	,nome			VARCHAR(150) NOT NULL
	,sobrenome		VARCHAR(150) NOT NULL
);
GO