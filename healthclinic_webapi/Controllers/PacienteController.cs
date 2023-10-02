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
    public class PacienteController : ControllerBase
    {
        private readonly IPacienteRepository _pacienteRepository;

        /// <summary>
        /// Chama a classe com os metodos
        /// </summary>
        public PacienteController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// Cadastra um paciente
        /// </summary>
        /// <param name="paciente">Novo paciente</param>
        /// <returns>Retorna status code 200</returns>

        [HttpPost]

        public IActionResult Cadastrar(Paciente paciente)
        {
            try
            {
                paciente.IdPaciente = Guid.NewGuid();

                _pacienteRepository.Cadastrar(paciente);

                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Lista todos os pacientes
        /// </summary>
        /// <returns>Retorna uma lista com todos os pacientes</returns>

        [HttpGet]

        public IActionResult Listar()
        {
            try
            {
                List<Paciente> pacientes = _pacienteRepository.ListarTodos();

                return Ok(pacientes);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Atualiza um paciente
        /// </summary>
        /// <param name="id">Id do paciente que sera atualizado</param>
        /// <param name="paciente">Novos dados</param>
        /// <returns>Retorna um status code 200</returns>

        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, Paciente paciente) 
        {
            try
            {
                _pacienteRepository.Atualizar(id, paciente);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um paciente
        /// </summary>
        /// <param name="id">Id do usuario que sera deletado</param>
        /// <returns></returns>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _pacienteRepository.Delete(id);
                return Ok();
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
