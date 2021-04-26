USE SENAI_HROADS_MANHA;
GO

--Selecionar todos os personagens; 
SELECT Nome AS Personagem
FROM Personagem;

--Selecionar todos as classes; 
SELECT*FROM Classe;

--Selecionar somente o nome das classes; 
SELECT Classe
FROM Classe;

--Selecionar todas as habilidades;
SELECT Habilidade
FROM Habilidade;

-- Selecionar somente os id’s das habilidades classificando-os por ordem crescente;
SELECT idHab AS [Id's Das Habilidades]
FROM Habilidade;

--Selecionar todos os tipos de habilidades;
SELECT Tipo AS [Tipo De Habilidade]
FROM TipoDeHabilidade;

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte; 
SELECT Habilidade, Tipo FROM Habilidade
LEFT JOIN TipoDeHabilidade
ON Habilidade.idTipoHab = TipoDeHabilidade.idTipoHab;

--Selecionar todos os personagens e suas respectivas classes; 
SELECT Nome AS Personagem, Classe FROM Personagem
LEFT JOIN Classe
ON Personagem.idClasse = Classe.idClasse;

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens); 
SELECT Nome AS Personagem, Classe FROM Personagem
RIGHT JOIN Classe
ON Personagem.idClasse = Classe.idClasse;

--Selecionar todas as classes e suas respectivas habilidades; 
SELECT Classe, Habilidade FROM Classe
INNER JOIN ClasseHabilidade
ON (Classe.idClasse = ClasseHabilidade.idClasse)
INNER JOIN Habilidade
ON (Habilidade.idHab = ClasseHabilidade.idHab);

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT Habilidade,Classe FROM Habilidade
INNER JOIN ClasseHabilidade
ON (Habilidade.idHab = ClasseHabilidade.idHab)
INNER JOIN Classe
ON (Classe.idClasse = ClasseHabilidade.idClasse);

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência). 
SELECT Habilidade,Classe FROM Habilidade
RIGHT JOIN ClasseHabilidade
ON (Habilidade.idHab = ClasseHabilidade.idHab)
RIGHT JOIN Classe
ON (Classe.idClasse = ClasseHabilidade.idClasse);

SELECT * FROM TipoUsuario;

SELECT * FROM Usuario;
