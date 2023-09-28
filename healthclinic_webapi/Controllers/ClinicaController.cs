using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace healthclinic_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ClinicaController : ControllerBase
    {
        private readonly IClinicaRepository _clinicaRepository;

        public ClinicaController()
        {
            _clinicaRepository = new ClinicaRepository();
        }

        /// <summary>
        /// Cadastra uma nova clinica
        /// </summary>
        /// <param name="clinica">Nova clinica</param>
        /// <returns>Retorna status code 201</returns>

        [HttpPost]

        public IActionResult Cadastrar(Clinica clinica)
        {
            try
            {
                clinica.IdClinica = Guid.NewGuid();

                _clinicaRepository.Cadastrar(clinica);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma clinica 
        /// </summary>
        /// <param name="id">Id da clinica que sera deletada</param>
        /// <returns>Retorna status code 204</returns>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _clinicaRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
