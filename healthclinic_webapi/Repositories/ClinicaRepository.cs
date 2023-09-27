using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Classe com os metodos da clinica
    /// </summary>
    public class ClinicaRepository : IClinicaRepository
    {
        private readonly ClinicContext ctx;

        public ClinicaRepository()
        {
            ctx= new ClinicContext();
        }

        /// <summary>
        /// Cadastra uma clinica
        /// </summary>
        /// <param name="clinica">Nova clinica</param>
        public void Cadastrar(Clinica clinica)
        {
            ctx.Clinica.Add(clinica);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta uma clinica existente
        /// </summary>
        /// <param name="id">Id da Clinica que sera deletada</param>
        public void Deletar(Guid id)
        {
            ctx.Clinica.Where(c => c.IdClinica == id)
                .ExecuteDeleteAsync();
        }
    }
}
