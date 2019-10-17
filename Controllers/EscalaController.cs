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
    public class EscalaController:ControllerBase
    {
        private readonly IEscalaBll _escalaBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public EscalaController(IEscalaBll escalaBll, ILoggerManager logger, IMapper mapper)
        {
            _escalaBll = escalaBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody]EscalaDTO escala)
        {            
            _escalaBll.Inserir(_mapper.Map<Escala>(escala));

            return Ok(new ApiResponse(200, "Escala inserido com sucesso."));
        }
        
        [HttpGet("ObterTodos")]
        public ActionResult<List<EscalaDTO>> ObterTodos()
        {
            var model = _escalaBll.ObterTodos();

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Escala não encontrados."));
            }

            List<EscalaDTO> listaEscala = new List<EscalaDTO>();

            foreach (var item in model)
            {
                listaEscala.Add(_mapper.Map<EscalaDTO>(item));
            }

            return Ok(new ApiOkResponse(listaEscala));
        }

        [HttpGet("ObterPorId/{id}")]
        public ActionResult<EscalaDTO> ObterPorId(string id)
        {
            var model = _escalaBll.ObterPorId(id);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"O Escala com o id->{id} não foi encontrado."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<EscalaDTO>(model)));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, EscalaDTO escala)
        {
            _escalaBll.Atualizar(id, _mapper.Map<Escala>(escala));

            return Ok(new ApiResponse(200, $"Escala {id} atualizado com sucesso."));
        } 
        
        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            _escalaBll.Excluir(id);

            return Ok(new ApiResponse(200, $"Escala {id} removido com sucesso."));
        }
    }
}
