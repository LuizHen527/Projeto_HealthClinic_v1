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
    public class PerfilController : ControllerBase
    {
        private readonly IPerfilRepository _perfilRepository;

        public PerfilController()
        {
            _perfilRepository = new PerfilRepository();
        }

        /// <summary>
        /// cadastra um novo perfil
        /// </summary>
        /// <param name="perfil">Perfil que sera cadastrado</param>
        /// <returns>Retorna status code 201s</returns>

        [HttpPost]

        public IActionResult Cadastrar(Perfil perfil)
        {
            try
            {
                perfil.IdPerfil = Guid.NewGuid();

                _perfilRepository.Cadastrar(perfil);
                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }


        /// <summary>
        /// Atualiza um perfil
        /// </summary>
        /// <param name="id">Id do perfil que sera atualizado</param>
        /// <param name="perfil">Novos dados de perfil</param>
        [HttpPut("{id}")]

        public IActionResult Atualizar(Guid id, Perfil perfil)
        {
            try
            {
                _perfilRepository.Atualizar(id, perfil);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um perfil
        /// </summary>
        /// <param name="id">Id do perfil que sera deletado</param>

        [HttpDelete("{id}")]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _perfilRepository.Deletar(id);
                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
