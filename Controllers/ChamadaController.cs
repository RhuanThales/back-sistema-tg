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
    public class ChamadaController:ControllerBase
    {
        private readonly IChamadaBll _chamadaBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public ChamadaController(IChamadaBll chamadaBll, ILoggerManager logger, IMapper mapper)
        {
            _chamadaBll = chamadaBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody]ChamadaDTO chamada)
        {            
            _chamadaBll.Inserir(_mapper.Map<Chamada>(chamada));

            return Ok(new ApiResponse(200, "Chamada inserida com sucesso."));
        }
        
        [HttpGet("ObterTodos")]
        public ActionResult<List<ChamadaDTO>> ObterTodos()
        {
            var model = _chamadaBll.ObterTodos();

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Chamada não encontrados."));
            }

            List<ChamadaDTO> listaChamadas = new List<ChamadaDTO>();

            foreach (var item in model)
            {
                listaChamadas.Add(_mapper.Map<ChamadaDTO>(item));
            }

            return Ok(new ApiOkResponse(listaChamadas));
        }

        [HttpGet("ObterPorId/{id}")]
        public ActionResult<ChamadaDTO> ObterPorId(string id)
        {
            var model = _chamadaBll.ObterPorId(id);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"A Chamada com o id->{id} não foi encontrada."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<ChamadaDTO>(model)));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, ChamadaDTO chamada)
        {
            _chamadaBll.Atualizar(id, _mapper.Map<Chamada>(chamada));

            return Ok(new ApiResponse(200, $"Chamada {id} atualizada com sucesso."));
        } 
        
        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            _chamadaBll.Excluir(id);

            return Ok(new ApiResponse(200, $"Chamada {id} removida com sucesso."));
        }
    }
}
