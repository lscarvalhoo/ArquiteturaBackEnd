using configuracaoArquiteturaBackEnd.api.Models.Usuarios;
using configuracaoArquiteturaBackEnd.api.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using configuracaoArquiteturaBackEnd.api.Filters;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using configuracaoArquiteturaBackEnd.api.Infra.Data;
using Microsoft.EntityFrameworkCore;
using configuracaoArquiteturaBackEnd.api.Business.Entities;
using configuracaoArquiteturaBackEnd.api.Business.Repositories;
using Microsoft.Extensions.Configuration;

namespace configuracaoArquiteturaBackEnd.api.Controllers
{

    [Route("api/v1/usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IConfiguration _configuration;
        private readonly IAuthenticationService _authentication;

        public UsuarioController(IUsuarioRepository usuarioRepository, 
                                 IConfiguration configuration,
                                 IAuthenticationService authentication)
        {
            _usuarioRepository = usuarioRepository;
            _configuration = configuration;
            _authentication = authentication;
        }

        [SwaggerResponse(statusCode: 200, description:"Sucesso", Type = typeof(LoginViewModelInput))]
        [SwaggerResponse(statusCode: 400, description:"Campo Obrigatório", Type = typeof(ValidaCampoViewModelOutput))]
        [SwaggerResponse(statusCode: 500, description:"Erro", Type = typeof(ErroGenericoViewModel))]
        [HttpPost]
        [Route("logar")]
        [ValidacaoModelStateCustomizado]
        public IActionResult Logar(LoginViewModelInput loginViewModelInput)
        {
            /*if (!ModelState.IsValid)
            {
                return BadRequest(new ValidaCampoViewModelOutput(ModelState.SelectMany(sm => sm.Value.Errors).Select(s => s.ErrorMessage)));
            }*/
            var usuarioViewModelOutput = new UsuarioViewModelOutput()
            {
                Codigo = 1,
                Login = "leo",
                Email = "leo@icloud.com"
            };

           /* var secret = Encoding.ASCII.GetBytes(_configuration.GetConnectionString("JwtConfigurations: Secret"));
            var symmetricSecurityKey = new SymmetricSecurityKey(secret);
            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, usuarioViewModelOutput.Codigo.ToString()),
                    new Claim(ClaimTypes.Name, usuarioViewModelOutput.Login.ToString()),
                    new Claim(ClaimTypes.Email, usuarioViewModelOutput.Email.ToString()),
                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature)
            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenGenerated = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(tokenGenerated);*/

            var token = _authentication.ObterToken(usuarioViewModelOutput);
            return Ok(new
            {
                Token = token,
                Usuario = usuarioViewModelOutput
            }
            );
        }

        [HttpPost]
        [ValidacaoModelStateCustomizado]
        [Route("registrar")]
        public IActionResult Registrar(RegistrarViewModelInput loginViewModelInput)
        {
            var usuario = new Usuario();
            usuario.Login = loginViewModelInput.Login;
            usuario.Senha = loginViewModelInput.Senha;
            usuario.Email = loginViewModelInput.Email;
            _usuarioRepository.Adicionar(usuario);
            _usuarioRepository.Commit();

            return Created("", loginViewModelInput);
        }
    }

}
