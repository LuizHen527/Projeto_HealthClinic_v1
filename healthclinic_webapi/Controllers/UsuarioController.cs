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
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        /// <summary>
        /// Chama o repository de usuario
        /// </summary>
        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        /// <summary>
        /// Cadastra um usuario
        /// </summary>
        /// <param name="usuario">Novo usuario</param>
        /// <returns>Retorna status code 201</returns>

        [HttpPost]

        public IActionResult Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.IdUsuario = Guid.NewGuid();

                _usuarioRepository.Cadastrar(usuario);

                return StatusCode(201);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id">Id do usuario que sera deletado</param>
        /// <returns></returns>

        [HttpDelete]

        public IActionResult Deletar(Guid id)
        {
            try
            {
                _usuarioRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
