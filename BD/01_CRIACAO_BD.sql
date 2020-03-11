CREATE DATABASE Senatur_Manha
GO

USE Senatur_Manha

CREATE TABLE tipoUsuario
	(
		IdTipoUsuario		INT PRIMARY KEY IDENTITY,
		Titulo				VARCHAR(200)
	);

CREATE TABLE Usuario
	(
		IdUsuario			INT PRIMARY KEY IDENTITY,
		Email				VARCHAR(255) NOT NULL UNIQUE,
		Senha				VARCHAR(255) NOT NULL,
		IdTipoUsuario		INT FOREIGN KEY REFERENCES tipoUsuario(IdTipoUsuario)
	);

CREATE TABLE Pacote
	(
		IdPacote			INT PRIMARY KEY IDENTITY,
		NomePacote			VARCHAR(255) NOT NULL,
		Descricao			TEXT NOT NULL,
		DataIda				DATE,
		DataVolta			DATE,
		Valor				DECIMAL NOT NULL,
		Ativo				BIT NOT NULL,
		NomeCidade			VARCHAR(255) NOT NULL 
	);
GO


