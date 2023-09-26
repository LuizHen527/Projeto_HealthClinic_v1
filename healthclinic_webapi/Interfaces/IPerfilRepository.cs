using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IPerfilRepository
    {
        void Cadastrar(Perfil perfil);

        void Deletar(Guid id);
    }
}
