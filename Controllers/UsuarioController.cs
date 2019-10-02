using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using back_sistema_tg.BLL;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.Utils;
using back_sistema_tg.BLL.Exceptions;
using Newtonsoft.Json;
using System.Threading.Tasks;
using back_sistema_tg.DAL.Models;
using back_sistema_tg.Extensions.Responses;
using AutoMapper;

namespace back_sistema_tg.Controllers
{
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController:ControllerBase
    {
        private readonly IUsuarioBll _usuarioBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public UsuarioController(IUsuarioBll usuarioBll, ILoggerManager logger, IMapper mapper)
        {
            _usuarioBll = usuarioBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody]UsuarioDTO usuario)
        {            
            _usuarioBll.Inserir(_mapper.Map<Usuario>(usuario));

            return Ok(new ApiResponse(200, "Inserido com sucesso."));
        }
        
        [HttpGet("ObterTodos")]
        public ActionResult<List<UsuarioDTO>> ObterTodos()
        {
            var model = _usuarioBll.ObterTodos();

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Usuários não encontrados."));
            }

            List<UsuarioDTO> listaUsuarios = new List<UsuarioDTO>();

            foreach (var item in model)
            {
                listaUsuarios.Add(_mapper.Map<UsuarioDTO>(item));
            }

            return Ok(new ApiOkResponse(listaUsuarios));
        }

        [HttpGet("ObterPorId/{id}")]
        public ActionResult<UsuarioDTO> ObterPorId(string id)
        {
            var model = _usuarioBll.ObterPorId(id);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"O Usuário com o id->{id} não foi encontrado."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<UsuarioDTO>(model)));
        }

        [HttpGet("ObterPorLogin/{login}")]
        public ActionResult<UsuarioDTO> ObterPorLogin(string login)
        {
            var model = _usuarioBll.ObterPorLogin(login);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"O Usuário com o login->{login} não foi encontrado."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<UsuarioDTO>(model)));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, UsuarioDTO usuario)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            } */

            _usuarioBll.Atualizar(id, _mapper.Map<Usuario>(usuario));

            return Ok(new ApiResponse(200, $"Usuário {id} atualizado com sucesso."));
        } 
        

        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            } */

            _usuarioBll.Excluir(id);

            return Ok(new ApiResponse(200, $"Usuário {id} removido com sucesso."));
        }
        


    }
}
