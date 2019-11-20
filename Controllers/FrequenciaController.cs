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
    public class FrequenciaController:ControllerBase
    {
        private readonly IFrequenciaBll _frequenciaBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public FrequenciaController(IFrequenciaBll frequenciaBll, ILoggerManager logger, IMapper mapper)
        {
            _frequenciaBll = frequenciaBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("Inserir")]
        public IActionResult Inserir([FromBody]FrequenciaDTO frequencia)
        {            
            _frequenciaBll.Inserir(_mapper.Map<Frequencia>(frequencia));

            return Ok(new ApiResponse(200, "Frequencia inserido com sucesso."));
        }
        
        [HttpGet("ObterTodos")]
        public ActionResult<List<FrequenciaDTO>> ObterTodos()
        {
            var model = _frequenciaBll.ObterTodos();

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Frequencia não encontrada."));
            }

            List<FrequenciaDTO> listaFrequencia = new List<FrequenciaDTO>();

            foreach (var item in model)
            {
                listaFrequencia.Add(_mapper.Map<FrequenciaDTO>(item));
            }

            return Ok(new ApiOkResponse(listaFrequencia));
        }

        [HttpGet("ObterFrequenciasPorAtirador/{crAtirador}")]
        public ActionResult<List<FrequenciaDTO>> ObterFrequenciasPorAtirador(string crAtirador)
        {
            var model = _frequenciaBll.ObterFrequenciasPorAtirador(crAtirador);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Frequencias não encontradas para esse Atirador."));
            }

            List<FrequenciaDTO> listaFrequencia = new List<FrequenciaDTO>();

            foreach (var item in model)
            {
                listaFrequencia.Add(_mapper.Map<FrequenciaDTO>(item));
            }

            return Ok(new ApiOkResponse(listaFrequencia));
        }

        [HttpGet("ObterPorId/{IdFrequencial}")]
        public ActionResult<FrequenciaDTO> ObterPorId(string IdFrequencia)
        {
            var model = _frequenciaBll.ObterPorId(IdFrequencia);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"A Frequencia com o id->{IdFrequencia} não foi encontrado."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<FrequenciaDTO>(model)));
        }

        [HttpPut("Atualizar/{id}")]
        public IActionResult Atualizar(string id, FrequenciaDTO frequencia)
        {
            _frequenciaBll.Atualizar(id, _mapper.Map<Frequencia>(frequencia));

            return Ok(new ApiResponse(200, $"Frequencia {id} atualizada com sucesso."));
        } 
        

        [HttpDelete("Excluir/{id}")]
        public IActionResult Excluir(string id)
        {
            _frequenciaBll.Excluir(id);

            return Ok(new ApiResponse(200, $"Frequencia {id} removida com sucesso."));
        }
    }
}