using healthclinic_webapi.Contexts;
using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;

namespace healthclinic_webapi.Repositories
{
    /// <summary>
    /// Classe com os metodos de perfil
    /// </summary>
    public class PerfilRepository : IPerfilRepository
    {
        private readonly ClinicContext ctx;

        /// <summary>
        /// Chama a context
        /// </summary>
        public PerfilRepository()
        {
            ctx = new ClinicContext();
        }


        public void Atualizar(Guid id, Perfil perfil)
        {
            throw new NotImplementedException();
        }

        public void Cadastrar(Perfil perfil)
        {
            throw new NotImplementedException();
        }

        public void Deletar(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
