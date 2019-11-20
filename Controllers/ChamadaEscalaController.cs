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
    public class ChamadaEscalaController:ControllerBase
    {
        private readonly IChamadaEscalaBll _chamadaEscalaBll;
        private ILoggerManager _logger;
        private IMapper _mapper;
        
        public ChamadaEscalaController(IChamadaEscalaBll chamadaEscalaBll, ILoggerManager logger, IMapper mapper)
        {
            _chamadaEscalaBll = chamadaEscalaBll;
            _logger = logger;
            _mapper = mapper;
        }

        [HttpPost("InserirChamadaEscala")]
        public IActionResult InserirChamadaEscala([FromBody]ChamadaEscalaDTO chamada)
        {            
            _chamadaEscalaBll.InserirChamadaEscala(_mapper.Map<ChamadaEscala>(chamada));

            return Ok(new ApiResponse(200, "Chamada inserida com sucesso."));
        }
        
        [HttpGet("ObterTodasChamadasEscala/{idEscala}")]
        public ActionResult<List<ChamadaEscalaDTO>> ObterTodasChamadasEscala(string idEscala)
        {
            var model = _chamadaEscalaBll.ObterTodasChamadasEscala(idEscala);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, "Chamadas não encontradas."));
            }

            List<ChamadaEscalaDTO> listaChamadas = new List<ChamadaEscalaDTO>();

            foreach (var item in model)
            {
                listaChamadas.Add(_mapper.Map<ChamadaEscalaDTO>(item));
            }

            return Ok(new ApiOkResponse(listaChamadas));
        }

        [HttpGet("ObterPorId/{idChamadaEscala}")]
        public ActionResult<ChamadaEscalaDTO> ObterPorId(string idChamadaEscala)
        {
            var model = _chamadaEscalaBll.ObterPorId(idChamadaEscala);

            if (model == null)
            {
                return NotFound(new ApiResponse(404, $"A Chamada com o id->{idChamadaEscala} não foi encontrada."));
            }            

            return Ok(new ApiOkResponse(_mapper.Map<ChamadaEscalaDTO>(model)));
        }

        [HttpPut("AtualizarChamadaEscala/{idChamadaEscala}")]
        public IActionResult AtualizarChamadaEscala(string idChamadaEscala, ChamadaEscalaDTO chamada)
        {
            _chamadaEscalaBll.AtualizarChamadaEscala(idChamadaEscala, _mapper.Map<ChamadaEscala>(chamada));

            return Ok(new ApiResponse(200, $"Chamada {idChamadaEscala} atualizada com sucesso."));
        } 

        [HttpPut("ConfirmarChamadaEscala/{idChamadaEscala}")]
        public IActionResult ConfirmarChamadaEscala(string idChamadaEscala)
        {
            _chamadaEscalaBll.ConfirmarChamadaEscala(idChamadaEscala);

            return Ok(new ApiResponse(200, $"Chamada {idChamadaEscala} confirmada com sucesso."));
        }
    }
}
