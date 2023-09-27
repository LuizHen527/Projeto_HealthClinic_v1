using healthclinic_webapi.Domains;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Interfaces
{

    /// <summary>
    /// interface de Clinica
    /// </summary>
    public interface IClinicaRepository
    {

        /// <summary>
        /// Cadastra uma clinica
        /// </summary>
        /// <param name="clinica">Nova clinica</param>
        void Cadastrar(Clinica clinica);

        /// <summary>
        /// Deleta uma clinica existente
        /// </summary>
        /// <param name="id">Id da Clinica que sera deletada</param>
        void Deletar (Guid id);
    }
}
