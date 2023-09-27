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
    public class EspecialidadeController : ControllerBase
    {
        private readonly IEspecialidadeRepository _especialidadeRepository;

        /// <summary>
        /// Chama repository de especialidade
        /// </summary>
        public EspecialidadeController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Cadastra uma nova especialidade
        /// </summary>
        /// <param name="especialidade">Nova especialidade</param>
        /// <returns>Retorna status code 201</returns>

        [HttpPost]

        public IActionResult Cadastrar(Especialidade especialidade)
        {
            try
            {
                especialidade.IdEspecialidade = Guid.NewGuid();

                _especialidadeRepository.Cadastrar(especialidade);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta uma especialidade
        /// </summary>
        /// <param name="id">Id da especialidade que sera deletada</param>
        /// <returns>Retorna status code 204</returns>

        [HttpDelete]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _especialidadeRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
