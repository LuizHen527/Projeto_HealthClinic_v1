using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IUsuarioRepository
    {
        void Cadastrar(Usuario usuario);

        void Deletar(Guid id);
    }
}
