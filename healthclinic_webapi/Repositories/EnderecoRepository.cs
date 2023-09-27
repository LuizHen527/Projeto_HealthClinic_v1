using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Repositories
{

    /// <summary>
    /// Classe com os metodos de endereco
    /// </summary>

    public class EnderecoRepository : IEnderecoRepository
    {
        private readonly ClinicContext ctx;

        /// <summary>
        /// Instancia a context
        /// </summary>

        public EnderecoRepository()
        {
            ctx = new ClinicContext();
        }

        /// <summary>
        /// Cadastra um endereco
        /// </summary>
        /// <param name="endereco">Novo endereco</param>

        public void Cadastrar(Endereco endereco)
        {
            ctx.Endereco.Add(endereco);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deleta um endereco
        /// </summary>
        /// <param name="id">Id do endereco que sera deletado</param>

        public void Deletar(Guid id)
        {
            ctx.Endereco.Where(e => e.IdEndereco == id)
                .ExecuteDeleteAsync();
        }
    }
}
