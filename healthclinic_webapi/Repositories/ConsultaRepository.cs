using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    public class ConsultaRepository : IConsultaRepository
    {
        private readonly ClinicContext ctx;

        public ConsultaRepository()
        {
            ctx= new ClinicContext();
        }

        /// <summary>
        /// atualiza uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que sera atualizada</param>
        /// <param name="consulta">Novos dados de consulta</param>
        public void Atualizar(Guid id, Consulta consulta)
        {
            ctx.Consulta.Where(c => c.IdConsulta == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(c => c.AgendamentoData, consulta.AgendamentoData)
                           .SetProperty(c => c.AgendamentoHora, consulta.AgendamentoHora)
                           .SetProperty(c => c.Status, consulta.Status));
        }

        /// <summary>
        /// Busca por todas as consultas de um medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        /// <returns>Retorna lista com todas as consultas de um medico</returns>
        public List<Consulta> BuscarPorIdMedico(Guid id)
        {
            try
            {
                return ctx.Consulta.Where(c => c.IdMedico == id).Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    AgendamentoData = c.AgendamentoData,
                    AgendamentoHora = c.AgendamentoHora,
                    Status = c.Status,
                    Endereco = new Endereco
                    {
                        Localidade = c.Endereco.Localidade,
                    },

                    Paciente = new Paciente
                    {
                        Prontuario = new Prontuario
                        {
                            Descricao = c.Paciente.Prontuario!.Descricao
                        },

                        Perfil = new Perfil
                        {
                            Usuario = new Usuario
                            {
                                Nome = c.Paciente.Perfil!.Usuario!.Nome,
                            }
                        }
                    }
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }

        /// <summary>
        /// Busca por todas as consultas de um medico
        /// </summary>
        /// <param name="id">Id do paciente</param>
        /// <returns>Retorna lista com todas as consultas de um paciente</returns>
        public List<Consulta> BuscarPorIdPaciente(Guid id)
        {
            try
            {
                return ctx.Consulta.Where(c => c.IdPaciente == id).Select(c => new Consulta
                {
                    IdConsulta = c.IdConsulta,
                    Status = c.Status,
                    AgendamentoData = c.AgendamentoData,
                    AgendamentoHora = c.AgendamentoHora,

                    IdEndereco = c.IdEndereco,
                    Endereco = new Endereco
                    {
                        Localidade = c.Endereco!.Localidade,
                    },

                    IdMedico = c.IdMedico,
                    Medico = new Medico
                    {
                        IdEspecialidade = c.Medico.IdEspecialidade,
                        Especialidade = new Especialidade
                        {
                            EspecialidadeNome = c.Medico!.Especialidade!.EspecialidadeNome
                        },

                        IdPerfil = c.Medico.IdPerfil,
                        Perfil = new Perfil
                        {

                            IdUsuario = c.Medico.Perfil!.IdUsuario,
                            Usuario = new Usuario
                            {
                                Nome = c.Medico.Perfil!.Usuario!.Nome
                            }
                        }
                    }
                }).ToList();

                
            }
            catch (Exception)
            {

                throw;
            }
        }


        /// <summary>
        /// Cadastra uma nova consulta 
        /// </summary>
        /// <param name="consulta">Nova consulta</param>
        public void Cadastrar(Consulta consulta)
        {
            ctx.Consulta.Add(consulta);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma consulta
        /// </summary>
        /// <param name="id">Id da consulta que sera deletada</param>
        public void Delete(Guid id)
        {
            ctx.Consulta.Where(c => c.IdConsulta == id)
                .ExecuteDeleteAsync();
        }


        /// <summary>
        /// Lista todas as consultas 
        /// </summary>
        /// <returns>retorna lista com as consultas</returns>
        public List<Consulta> Listar()
        {
            try
            {
                return ctx.Consulta.Select(consulta => new Consulta
                {
                    IdConsulta = consulta.IdConsulta,
                    AgendamentoData = consulta.AgendamentoData,
                    AgendamentoHora = consulta.AgendamentoHora,
                    Status = consulta.Status,
                    Endereco = new Endereco
                    {
                        Localidade = consulta.Endereco!.Localidade,
                    },
                    Paciente = new Paciente
                    {
                        Prontuario = new Prontuario
                        {
                            Descricao = consulta.Paciente!.Prontuario!.Descricao
                        },

                        Perfil = new Perfil
                        {
                            Usuario = new Usuario
                            {
                                Nome = consulta.Paciente.Perfil!.Usuario!.Nome,
                                CPF = consulta.Paciente.Perfil.Usuario.CPF
                            }
                        }
                    },
                    Medico = new Medico
                    {
                        Especialidade = new Especialidade
                        {
                            EspecialidadeNome = consulta.Medico!.Especialidade!.EspecialidadeNome
                        },
                        Perfil = new Perfil
                        {
                            Usuario = new Usuario
                            {
                                Nome = consulta.Medico.Perfil!.Usuario!.Nome
                            }
                        }
                    }
                }).ToList();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}


//

//List<Consulta> consultasPaciente = new List<Consulta>();

//var todasConsultasPaciente = ctx.Consulta.Where(c => c.IdPaciente == id).ToList();

//if (todasConsultasPaciente.Any())
//{
//    foreach (var c in todasConsultasPaciente)
//    {
//        consultasPaciente.Add(new Consulta
//        {
//            Status = c.Status,
//            Agendamento = c.Agendamento,
//            Endereco = new Endereco
//            {
//                Localidade = c.Endereco.Localidade,
//            },

//            Medico = new Medico
//            {
//                Especialidade = new Especialidade
//                {
//                    EspecialidadeNome = c.Medico.Especialidade!.EspecialidadeNome
//                },
//                Perfil = new Perfil
//                {
//                    Usuario = new Usuario
//                    {
//                        Nome = c.Medico.Perfil!.Usuario!.Nome
//                    }
//                }
//            },
//        });
//    }
//    return consultasPaciente;
//}
//return null!;