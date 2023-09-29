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

        public void Atualizar(Guid id, Medico medico)
        {
            ctx.Medico.Where(m => medico.IdMedico == id)
                .ExecuteUpdateAsync(updates =>
                    updates.SetProperty(m => m.Nome, medico.Nome)
                           .SetProperty(m => m.IdPerfil, medico.IdPerfil)
                           .SetProperty(m => m.IdEspecialidade, medico.IdEspecialidade));
        }

        public void Cadastrar(Medico medico)
        {
            ctx.Medico.Add(medico);

            ctx.SaveChanges();
        }

        public void Delete(Guid id)
        {
            ctx.Medico.Where(m => m.IdMedico == id)
                .ExecuteDeleteAsync();
        }

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
