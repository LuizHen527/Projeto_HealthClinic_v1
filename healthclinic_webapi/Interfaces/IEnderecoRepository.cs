using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{

    /// <summary>
    /// Interface de endereco
    /// </summary>

    public interface IEnderecoRepository
    {

        /// <summary>
        /// Cadastra um endereco
        /// </summary>
        /// <param name="endereco">Novo endereco</param>

        void Cadastrar(Endereco endereco);

        /// <summary>
        /// Deleta um endereco
        /// </summary>
        /// <param name="id">Id do endereco que sera deletado</param>

        void Deletar(Guid id);
    }
}
