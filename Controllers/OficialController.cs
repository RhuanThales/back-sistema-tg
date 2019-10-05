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

    public class OficialController:ControllerBase
    {
        private readonly IOficialBll _oficialBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public OficialController(IOficialBll oficialBll, ILoggerManager logger, IMapper mapper)
        {
            _oficialBll = oficialBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody]OficialDTO oficial)
        {            
            _oficialBll.Inserir(_mapper.Map<Oficial>(oficial));

            return Ok(new ApiResponse(200, "Oficial inserido com sucesso."));
        }
        
        [HttpGet("ObterTodos")]
        public ActionResult<List<OficialDTO>> ObterTodos()
        {
            var model = _oficialBll.ObterTodos();

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Oficial não encontrado."));
            }

            List<OficialDTO> listaOficial = new List<OficialDTO>();

            foreach (var item in model)
            {
                listaOficial.Add(_mapper.Map<OficialDTO>(item));
            }

            return Ok(new ApiOkResponse(listaOficial));
        }

        [HttpGet("ObterPorId/{id}")]
        public ActionResult<OficialDTO> ObterPorId(string IdOficial)
        {
            var model = _oficialBll.ObterPorId(IdOficial);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"O Oficial com o id->{IdOficial} não foi encontrado."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<OficialDTO>(model)));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, OficialDTO oficial)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            } */

            _oficialBll.Atualizar(id, _mapper.Map<Oficial>(oficial));

            return Ok(new ApiResponse(200, $"Oficial {id} atualizado com sucesso."));
        } 
        

        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            } */

            _oficialBll.Excluir(id);

            return Ok(new ApiResponse(200, $"Oficial {id} removido com sucesso."));
        }
        


    }
        
}