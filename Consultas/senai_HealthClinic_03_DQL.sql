--DQL Data Query Language

--Exibindo:
-- IdConsulta
-- Data da Consulta
-- Horario da Consulta
-- Nome da Clinica
-- Nome do Paciente
-- Nome do Medico
-- Especialidade do Medico
-- CRM
-- Prontuário ou Descricao
-- FeedBack(Comentario da consulta)

USE Manha_HealthClinic

SELECT
IdConsulta,
Agendamento AS [Data],
Horario AS Horario,
NomeFantasia,
Nome
FROM Clinica
INNER JOIN Endereco
ON Clinica.IdClinica = Endereco.IdClinica

INNER JOIN Consulta
ON Endereco.IdEndereco = Consulta.IdEndereco

INNER JOIN Paciente
ON Paciente.IdPaciente = Consulta.IdConsulta

INNER JOIN Perfil
ON Perfil.IdPerfil = Paciente.IdPerfil