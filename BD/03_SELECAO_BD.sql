USE Senatur_Manha
GO

SELECT * FROM Usuario;

SELECT IdTipoUsuario, Titulo FROM tipoUsuario

SELECT IdUsuario, Email, Senha, tu.IdTipoUsuario, Titulo FROM Usuario u
INNER JOIN tipoUsuario tu on tu.IdTipoUsuario = u.IdTipoUsuario

SELECT IdPacote, NomePacote, Descricao, DataIda, DataVolta, Valor, Ativo, NomeCidade FROM Pacote