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

        public void Atualizar(Guid id, Consulta consulta)
        {
            ctx.Consulta.Where(c => c.IdConsulta == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(c => c.Agendamento, consulta.Agendamento)
                           .SetProperty(c => c.Status, consulta.Status));
        }

        public List<Consulta> BuscarPorIdMedico(Guid id)
        {
            List<Consulta> consultasMedico =new List<Consulta>();

            var todasConsultasMedico = ctx.Consulta.Where(c => c.IdConsulta == id).ToList();

            if(todasConsultasMedico.Any())
            {
                foreach (var c in todasConsultasMedico)
                {
                    consultasMedico.Add(new Consulta
                    {
                        Agendamento= c.Agendamento,
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
                        },

                    });
                }
                return consultasMedico;
            }

            return null!;
        }

        public List<Consulta> BuscarPorIdPaciente(Guid id)
        {
            List<Consulta> consultasPaciente = new List<Consulta>();

            var todasConsultasPaciente = ctx.Consulta.Where(c => c.IdConsulta == id).ToList();

            if(todasConsultasPaciente.Any())
            {
                foreach (var c in todasConsultasPaciente)
                {
                    consultasPaciente.Add(new Consulta
                    {
                        Status = c.Status,
                        Agendamento = c.Agendamento,
                        Endereco = new Endereco
                        {
                            Localidade = c.Endereco.Localidade,
                        },

                        Medico = new Medico
                        {
                            Especialidade = new Especialidade
                            {
                                EspecialidadeNome = c.Medico.Especialidade.EspecialidadeNome
                            },
                            Perfil = new Perfil
                            {
                                Usuario = new Usuario
                                {
                                    Nome = c.Medico.Perfil.Usuario.Nome
                                }
                            }
                        },
                    });
                }
                return consultasPaciente;
            }
            return null!;
        }

        public void Cadastrar(Consulta consulta)
        {
            ctx.Consulta.Add(consulta);

            ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            ctx.Consulta.Where(c => c.IdConsulta == id)
                .ExecuteDeleteAsync();
        }

        public List<Consulta> Listar()
        {
            List<Consulta> consultas = new List<Consulta>();

            var todasConsultas = ctx.Consulta.ToList();

            if(todasConsultas.Any())
            {
                foreach (var consulta in todasConsultas)
                {
                    consultas.Add(new Consulta()
                    {
                        IdConsulta = consulta.IdConsulta,
                        Agendamento = consulta.Agendamento,
                        Status = consulta.Status,
                        Endereco = new Endereco
                        {
                            Localidade = consulta.Endereco.Localidade,
                        },
                        Paciente = new Paciente
                        {
                            Prontuario = new Prontuario
                            {
                                Descricao = consulta.Paciente.Prontuario!.Descricao
                            }, 

                            Perfil = new Perfil
                            {
                                Usuario = new Usuario
                                {
                                    Nome = consulta.Paciente.Perfil.Usuario.Nome,
                                }
                            }
                        },
                        Medico = new Medico
                        {
                            Especialidade = new Especialidade
                            {
                                EspecialidadeNome = consulta.Medico.Especialidade.EspecialidadeNome
                            },
                            Perfil = new Perfil
                            {
                                Usuario = new Usuario
                                {
                                    Nome = consulta.Medico.Perfil.Usuario.Nome
                                }
                            }
                        },

                        
                    });
                }

                return consultas;
            }

            return null!;
        }
    }
}
