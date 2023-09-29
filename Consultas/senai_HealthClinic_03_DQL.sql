--DQL Data Query Language

--Exibindo:
-- IdConsulta (Consulta)
-- Data da Consulta (Consulta)
-- Horario da Consulta (Consulta)
-- Nome da Clinica (Clinica)
-- Nome do Paciente (Perfil)
-- Nome do Medico (Perfil)
-- Especialidade do Medico (Especialidade)
-- CRM (Medico)
-- Prontuário ou Descricao (Prontuario)
-- FeedBack(Comentario)

USE HealthClinic_Manha

SELECT * FROM Usuario

SELECT * FROM Paciente

SELECT * FROM Perfil

SELECT * FROM Prontuario

SELECT * FROM Clinica

SELECT * FROM Endereco

SELECT * FROM Medico

/*Selecione e execute tudo daqui pra baixo*/

SELECT
Consulta.IdConsulta,
Agendamento AS [Data],
Horario AS Horario,
NomeFantasia,
Nome AS Paciente,
medicoConsulta.Médico AS Medico,
Especialidade.Especialidade,
CRM,
Descricao,
Comentario

FROM Clinica
INNER JOIN Endereco
ON Clinica.IdClinica = Endereco.IdClinica

INNER JOIN Consulta
ON Endereco.IdEndereco = Consulta.IdEndereco

INNER JOIN Paciente
ON Paciente.IdPaciente = Consulta.IdConsulta

/* Abaixo usei uma Subquery para criar uma outra tabela como fonte da consulta inicial.
Coloque essa Subquery dentro de um JOIN para fazer a ligação dessa tabela personalizada com as outras tabelas.
Isso resolveria o problema de chamar os nomes do paciente e do medico,
como os dois dados estão na mesma coluna de uma mesma tabela eu não conseguia chamar os dois tipos de dados separados
*/

INNER JOIN (
	SELECT IdConsulta, IdPaciente, Perfil.Nome AS Médico, Perfil.IdPerfil
	FROM Consulta
	INNER JOIN Medico
	ON Medico.IdMedico = Consulta.IdMedico
	INNER JOIN Perfil
	ON Perfil.IdPerfil = Medico.IdPerfil
	) AS medicoConsulta
	ON Paciente.IdPaciente = medicoConsulta.IdPaciente

INNER JOIN Perfil
ON Perfil.IdPerfil = medicoConsulta.IdPerfil

INNER JOIN Medico
ON Medico.IdMedico = Consulta.IdMedico

INNER JOIN Especialidade
ON Especialidade.IdEspecialidade = Medico.IdMedico

INNER JOIN Prontuario
ON Prontuario.IdProntuario = Paciente.IdProntuario

INNER JOIN Feedback
ON Feedback.IdFeedback = Consulta.IdFeedback