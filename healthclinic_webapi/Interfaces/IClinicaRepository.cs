using healthclinic_webapi.Domains;
using Microsoft.EntityFrameworkCore;

namespace healthclinic_webapi.Interfaces
{
    public interface IClinicaRepository
    {
        void Cadastrar(Clinica clinica);

        void Deletar (Guid id);
    }
}
