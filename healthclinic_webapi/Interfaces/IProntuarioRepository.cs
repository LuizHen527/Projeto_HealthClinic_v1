using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IProntuarioRepository
    {
        void Cadastrar(Prontuario prontuario);

        void Deletar(Guid id);

        void Atualizar(Guid id, Prontuario prontuario);
    }
}
