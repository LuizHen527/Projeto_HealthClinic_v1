using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    public class MedicoRepository : IMedicoRepository
    {
        private readonly ClinicContext ctx;

        public MedicoRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Atualiza um medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        /// <param name="medico">Novos dados</param>
        public void Atualizar(Guid id, Medico medico)
        {
            ctx.Medico.Where(m => medico.IdMedico == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(m => m.Nome, medico.Nome)
                           .SetProperty(m => m.IdPerfil, medico.IdPerfil)
                           .SetProperty(m => m.IdEspecialidade, medico.IdEspecialidade));
        }

        /// <summary>
        /// Cadastra um novo medico
        /// </summary>
        /// <param name="medico">Novo medico</param>
        public void Cadastrar(Medico medico)
        {
            ctx.Medico.Add(medico);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um medico
        /// </summary>
        /// <param name="id">Id do medico</param>
        public void Delete(Guid id)
        {
            ctx.Medico.Where(m => m.IdMedico == id)
                .ExecuteDeleteAsync();
        }

        /// <summary>
        /// Lista todos os medicos
        /// </summary>
        /// <returns>Retorna lista com os medicos</returns>
        public List<Medico> Listar()
        {
            List<Medico> medicos = new List<Medico>();

            var todosMedicos = ctx.Medico.ToList();

            if(todosMedicos.Any())
            {
                foreach (var medico in todosMedicos)
                {
                    medicos.Add(new Medico()
                    {
                        IdMedico = medico.IdMedico,
                        Nome = medico.Nome,
                        IdPerfil = medico.IdPerfil,
                        IdEspecialidade = medico.IdEspecialidade
                    });
                }

                return medicos;
            }

            return null!;
        }
    }
}
