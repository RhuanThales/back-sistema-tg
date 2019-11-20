using System;
using System.IO;
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
using ChoETL;

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

        [HttpGet("ObterPelotao/{NumeroPelotao}")]
        public ActionResult<List<AtiradorDTO>> ObterPorPelotao(int NumeroPelotao)
        {
            var teste = _atiradorBll.ObterPorPelotao(NumeroPelotao);

            if (teste == null)
            {
                return NotFound(new ApiResponse(404, $"O Atirador com o numero de Pelotao->{NumeroPelotao} não foi encontrado."));
            }            

            List<AtiradorDTO> listaAtirador = new List<AtiradorDTO>();

            foreach (var item in teste)
            {
                listaAtirador.Add(_mapper.Map<AtiradorDTO>(item));
            }

            return Ok(new ApiOkResponse(listaAtirador));
        }

        [HttpGet("ObterMonitores")]
        public ActionResult<List<AtiradorDTO>> ObterMonitores()
        {
            var teste = _atiradorBll.ObterMonitores();

            if (teste == null)
            {
                return NotFound(new ApiResponse(404, $"O Atirador nao e monitor."));
            }            

            List<AtiradorDTO> listaAtirador = new List<AtiradorDTO>();

            foreach (var item in teste)
            {
                listaAtirador.Add(_mapper.Map<AtiradorDTO>(item));
            }

            return Ok(new ApiOkResponse(listaAtirador));
        }

        [HttpGet("ObterDesligados")]
        public ActionResult<List<AtiradorDTO>> ObterDesligados()
        {
            var teste = _atiradorBll.ObterDesligados();

            if (teste == null)
            {
                return NotFound(new ApiResponse(404, $"Nao ha atiradores desligados."));
            }            

            List<AtiradorDTO> listaAtirador = new List<AtiradorDTO>();

            foreach (var item in teste)
            {
                listaAtirador.Add(_mapper.Map<AtiradorDTO>(item));
            }

            return Ok(new ApiOkResponse(listaAtirador));
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

        [HttpPost("ImportarAtiradores")]
        public IActionResult ImportarAtiradores([FromBody]ArquivoDTO arquivo)
        {
            if (arquivo != null)
            {
                var bytes = Convert.FromBase64String(arquivo.Arquivo);
                var header = new string[] { };

                List<object[]> campos = new List<object[]>();

                using (var memoryStr = new MemoryStream(bytes))
                {
                    using (var reader = new StreamReader(memoryStr))
                    {
                        using (var csvReader = new ChoCSVReader(reader).WithFirstLineHeader())
                        {
                            csvReader.WithDelimiter(";");

                            foreach (var item in csvReader)
                            {
                                campos.Add(item.ValuesArray);
                            }
                        }
                    }
                }

                try
                {
                    ConstruirObjetoAtirador(campos);
                    return Ok(new ApiResponse(200, "Importação de Atirdores realizada com sucesso."));
                }

                catch (Exception)
                {
                    return BadRequest(new ApiResponse(418, "Ocorreu algum erro durante a importação."));
                }
            }

            return null;
        }

        protected void ConstruirObjetoAtirador(List<object[]> campos)
		{
            System.Globalization.CultureInfo cultureinfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            foreach (var item in campos)
            {
                var nomeAtirador  = item.GetValue(0).ToString().ToLower();
                nomeAtirador  = cultureinfo.TextInfo.ToTitleCase(nomeAtirador);

                var naturalidade  = item.GetValue(0).ToString().ToLower();
                naturalidade  = cultureinfo.TextInfo.ToTitleCase(naturalidade);

                var crAtirador  = item.GetValue(0).ToString().ToLower();
                crAtirador  = cultureinfo.TextInfo.ToTitleCase(crAtirador);

                var naturalidadeCR  = item.GetValue(0).ToString().ToLower();
                naturalidadeCR  = cultureinfo.TextInfo.ToTitleCase(naturalidadeCR);

                var nomeGuerra  = item.GetValue(0).ToString().ToLower();
                nomeGuerra  = cultureinfo.TextInfo.ToTitleCase(nomeGuerra);

                var numAtirador  = item.GetValue(0).ToString();
                var numeroAtirador  = Convert.ToInt32(numAtirador);

                var numPelotao  = item.GetValue(0).ToString();
                var numeroPelotao  = Convert.ToInt32(numPelotao);

                var funcao  = item.GetValue(0).ToString().ToLower();
                funcao  = cultureinfo.TextInfo.ToTitleCase(funcao);

                var nomePai  = item.GetValue(0).ToString().ToLower();
                nomePai  = cultureinfo.TextInfo.ToTitleCase(nomePai);

                var nomeMae  = item.GetValue(0).ToString().ToLower();
                nomeMae  = cultureinfo.TextInfo.ToTitleCase(nomeMae);

                var religiao  = item.GetValue(0).ToString().ToLower();
                religiao  = cultureinfo.TextInfo.ToTitleCase(religiao);

                var escolaridade  = item.GetValue(0).ToString().ToLower();
                escolaridade  = cultureinfo.TextInfo.ToTitleCase(escolaridade);

                RegistroGeral reg = new RegistroGeral();
                TituloEleitor titEleitor = new TituloEleitor();
                EnderecoCompleto end = new EnderecoCompleto();
                
                if(_atiradorBll.VerificarDadosAtiradores(crAtirador) != true)
                {     
                    // Setando os valores para o registro geral
                    reg.OrgaoEmissor = item.GetValue(0).ToString().ToLower();
                    reg.NumeroRg = item.GetValue(0).ToString().ToLower();

                    // Setando os valores para o titulo de eleitor
                    titEleitor.ZonaTitulo = item.GetValue(0).ToString().ToLower();
                    titEleitor.NumeroTitulo = item.GetValue(0).ToString().ToLower();

                    // Setando os valores para o endereco
                    end.Logradouro = item.GetValue(0).ToString().ToLower();
                    end.Bairro = item.GetValue(0).ToString().ToLower();
                    var numEndereco = item.GetValue(0).ToString();
                    end.NumeroEndereco = Convert.ToInt32(numEndereco);
                    end.CEP = item.GetValue(0).ToString().ToLower();
                    end.Cidade = item.GetValue(0).ToString().ToLower();
                    end.Estado = item.GetValue(0).ToString().ToLower();
                    
                    // Setenado os valores para o Atirador
                    Atirador atirador = new Atirador()
                    {
                        NomeAtirador = nomeAtirador,
                        DataNascimento = item.GetValue(0).ToString().ToLower(),
                        CPF = item.GetValue(0).ToString().ToLower(),
                        RegistroGeral = reg,
                        TituloEleitor = titEleitor,
                        Naturalidade = naturalidade,
                        NomePai = nomePai,
                        NomeMae = nomeMae,
                        Religiao = religiao,
                        Escolaridade = escolaridade,

                        // Dados de Endereço/Contato
                        Endereco = end,
                        Telefone = item.GetValue(0).ToString().ToLower(),
                        TelefonePai = item.GetValue(0).ToString().ToLower(),
                        TelefoneMae = item.GetValue(0).ToString().ToLower(),

                        // Dados do Tiro de Guerra
                        CR = crAtirador,
                        NaturalidadeCR = naturalidadeCR,
                        NomeGuerra = nomeGuerra,
                        NumeroAtirador = numeroAtirador,
                        NumeroPelotao = numeroPelotao,
                        Funcao = funcao,
                        Volutario = false,
                        StatusAtirador = false,
                
                        // Dados de Pontuação
                        PontosJustificados = 0,
                        PontosNaoJustificados = 0,

                        // Dados de Horas/Tempo de Serviço
                        HorasCfc = 0,
                        HorasInstrucao = 0,
                        HorasExtras = 0,
                        HorasServico = 0,
                    };

                    _atiradorBll.Inserir(atirador);
                } 
            }
        }
    }
}
