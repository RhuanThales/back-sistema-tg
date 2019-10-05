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
    [Route("api/[controller]")]
    [ApiController]
    public class AtiradorController:ControllerBase
    {
        private readonly IAtiradorBll _atiradorBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public AtiradorController(IAtiradorBll atiradorBll, ILoggerManager logger, IMapper mapper)
        {
            _atiradorBll = atiradorBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody]AtiradorDTO atirador)
        {            
            _atiradorBll.Inserir(_mapper.Map<Atirador>(atirador));

            return Ok(new ApiResponse(200, "Atirador inserido com sucesso."));
        }
        
        [HttpGet("ObterTodos")]
        public ActionResult<List<AtiradorDTO>> ObterTodos()
        {
            var model = _atiradorBll.ObterTodos();

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Atirador não encontrado."));
            }

            List<AtiradorDTO> listaAtirador = new List<AtiradorDTO>();

            foreach (var item in model)
            {
                listaAtirador.Add(_mapper.Map<AtiradorDTO>(item));
            }

            return Ok(new ApiOkResponse(listaAtirador));
        }

        [HttpGet("ObterPorId/{id}")]
        public ActionResult<AtiradorDTO> ObterPorId(string IdAtirador)
        {
            var model = _atiradorBll.ObterPorId(IdAtirador);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"O Atirador com o id->{IdAtirador} não foi encontrado."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<AtiradorDTO>(model)));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, AtiradorDTO atirador)
        {
            _atiradorBll.Atualizar(id, _mapper.Map<Atirador>(atirador));

            return Ok(new ApiResponse(200, $"Atirador {id} atualizado com sucesso."));
        } 
        

        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            _atiradorBll.Excluir(id);

            return Ok(new ApiResponse(200, $"Atirador {id} removido com sucesso."));
        }
    }
}
