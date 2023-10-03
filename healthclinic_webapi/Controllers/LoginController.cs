using healthclinic_webapi.Domains;
using healthclinic_webapi.Interfaces;
using healthclinic_webapi.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace healthclinic_webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        public IPerfilRepository _perfilRepository;

        public LoginController()
        {
            _perfilRepository = new PerfilRepository();
        }

        /// <summary>
        /// Efetua um login
        /// </summary>
        /// <param name="perfil">Dados digitados</param>
        /// <returns>Retorna um token</returns>
        [HttpPost]

        public IActionResult Login(Perfil perfil)
        {
            try
            {
                Perfil p = _perfilRepository.BuscarPorEmailSenha(perfil.Email, perfil.Senha);

                if (p == null)
                {
                    return StatusCode(404);
                }

                //Caso encontre prossegue para a criacao do token

                //Parte 1: Definir informacoes(Claims) que serao fornecidas no token(Payload)

                var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti, p.IdPerfil.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, p.Email!),
                    new Claim(ClaimTypes.Role, p.TiposUsuario!.Tipo!),

                    //Existe a possibilidade de criar uma claim personalizada

                    new Claim("Claim personalizada", "Valor da Claim personalizada")
                };

                //Parte 2: Definir chave de acesso ao token
                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("HealthClinic-chave-autenticacao-webapi-dev"));

                //Parte 3: Definir as credenciais do token (Header)
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                //Parte 4: Gerar token

                var token = new JwtSecurityToken
                (
                    //emissor do token 
                    issuer: "healthclinic_webapi",

                    //Destinatario do token
                    audience: "healthclinic_webapi",

                    //Dados definidos nas claims(informacoes)
                    claims: claims,

                    //Tempo de expiracao
                    expires: DateTime.Now.AddMinutes(5),

                    //Credenciais do token
                    signingCredentials: creds
                );

                //Parte 5: Retornar um token 

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token)
                });
            }
            catch (Exception erro)
            {

                return BadRequest(erro.Message);
            }
        }
    }
}
