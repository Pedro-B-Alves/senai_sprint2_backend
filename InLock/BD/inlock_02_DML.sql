USE inlock_games_manha;
GO

INSERT INTO tiposUsuarios(titulo)
VALUES ('Administrador'),('Cliente');
GO

INSERT INTO usuarios(email,senha,idTipoUsuario)
VALUES ('admin@admin.com','admin',1),
	   ('cliente@cliente.com','cliente',2);
GO

INSERT INTO estudios(nomeEstudio)
VALUES ('Blizzard'),('Rockstar Studios'),('Square Enix');
GO

INSERT INTO jogos(nomeJogo,descricao,dataLancamento,valor,idEstudio)
VALUES ('Diablo 3','é um jogo que contém bastante ação e é
viciante, seja você um novato ou um fã','15-5-2012',99.00,1),
	   ('Red Dead Redemption II','jogo eletrônico de ação-aventura western','26-10-2018',120.00,2);
GO