using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly ClinicContext ctx;

        /// <summary>
        /// Chama context
        /// </summary>
        public PacienteRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Atualiza um paciente
        /// </summary>
        /// <param name="id">Id do paciente que sera atualizado</param>
        /// <param name="paciente">Novos dados de paciente</param>
        public void Atualizar(Guid id, Paciente paciente)
        {
            ctx.Paciente.Where(p => p.IdPaciente == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(p => p.Convenio, paciente.Convenio)
                           .SetProperty(p => p.IdPerfil, paciente.IdPerfil));
        }

        /// <summary>
        /// Cadastra um novo paciente
        /// </summary>
        /// <param name="paciente">Novo paciente</param>
        public void Cadastrar(Paciente paciente)
        {
            ctx.Paciente.Add(paciente);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="id">Id do paciente que sera deletado</param>
        public void Delete(Guid id)
        {
            ctx.Paciente.Where(p => p.IdPaciente == id)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Retorna lista com os pacientes</returns>
        public List<Paciente> ListarTodos()
        {
            List<Paciente> pacientes = new List<Paciente>();

            var todosPacientes = ctx.Paciente.ToList();

            if(todosPacientes.Any() )
            {
                foreach (var paciente in todosPacientes)
                {
                    pacientes.Add(new Paciente()
                    {
                        IdPaciente = paciente.IdPaciente,
                        Convenio = paciente.Convenio,
                        IdProntuario = paciente.IdProntuario,
                        IdPerfil = paciente.IdPerfil
                    });
                        
                }

                return pacientes;
            }

            return null!;
        }
    }
}
