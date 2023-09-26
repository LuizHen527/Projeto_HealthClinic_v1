using healthclinic_webapi.Domains;

namespace healthclinic_webapi.Interfaces
{
    public interface IEnderecoRepositoty
    {
        void Cadastrar(Endereco endereco);

        void Deletar(Guid id);
    }
}
