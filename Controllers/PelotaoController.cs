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

    public class PelotaoController:ControllerBase 
    {
        private readonly IPelotaoBll _pelotaoBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public PelotaoController(IPelotaoBll pelotaoBll, ILoggerManager logger, IMapper mapper)
        {
            _pelotaoBll = pelotaoBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody]PelotaoDTO pelotao)
        {            
            _pelotaoBll.Inserir(_mapper.Map<Pelotao>(pelotao));

            return Ok(new ApiResponse(200, "Pelotao inserido com sucesso."));
        }
        
        [HttpGet("ObterTodos")]
        public ActionResult<List<OficialDTO>> ObterTodos()
        {
            var model = _pelotaoBll.ObterTodos();

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Pelotao não encontrado."));
            }

            List<PelotaoDTO> listaPelotao = new List<PelotaoDTO>();

            foreach (var item in model)
            {
                listaPelotao.Add(_mapper.Map<PelotaoDTO>(item));
            }

            return Ok(new ApiOkResponse(listaPelotao));
        }

        [HttpGet("ObterPorId/{IdPelotao}")]
        public ActionResult<PelotaoDTO> ObterPorId(string IdPelotao)
        {
            var model = _pelotaoBll.ObterPorId(IdPelotao);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"O Pelotao com o id->{IdPelotao} não foi encontrado."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<PelotaoDTO>(model)));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, PelotaoDTO pelotao)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            } */

            _pelotaoBll.Atualizar(id, _mapper.Map<Pelotao>(pelotao));

            return Ok(new ApiResponse(200, $"Pelotao {id} atualizado com sucesso."));
        } 
        

        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            /* if (!ModelState.IsValid)
            {
                return BadRequest(new ApiBadRequestResponse(ModelState));
            } */

            _pelotaoBll.Excluir(id);

            return Ok(new ApiResponse(200, $"Pelotao {id} removido com sucesso."));
        }
        


    }

}
