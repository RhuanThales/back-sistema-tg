using AutoMapper;
using back_sistema_tg.DAL.DTO;
using back_sistema_tg.DAL.Models;

namespace back_sistema_tg
{
    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
        {
            // Mapeando a classe USUARIO
            CreateMap<UsuarioDTO, Usuario>().
                AfterMap((dto, model) => model.Id = dto.Id);
            CreateMap<Usuario, UsuarioDTO>()
                .AfterMap((model, dto) => dto.Id = model.Id);

            // Mapeando a classe Atirador
            CreateMap<AtiradorDTO, Atirador>().
                AfterMap((dto, model) => model.IdAtirador = dto.IdAtirador);
            CreateMap<Atirador, AtiradorDTO>()
                .AfterMap((model, dto) => dto.IdAtirador = model.IdAtirador);

                // Mapeando a classe Oficial
            CreateMap<OficialDTO, Oficial>().
                AfterMap((dto, model) => model.IdOficial = dto.IdOficial);
            CreateMap<Oficial, OficialDTO>()
                .AfterMap((model, dto) => dto.IdOficial = model.IdOficial);

                // Mapeando a classe Pelotao
            CreateMap<PelotaoDTO, Pelotao>().
                AfterMap((dto, model) => model.IdPelotao = dto.IdPelotao);
            CreateMap<Pelotao, PelotaoDTO>()
                .AfterMap((model, dto) => dto.IdPelotao = model.IdPelotao);

                // Mapeando a classe Escala
            CreateMap<EscalaDTO, Escala>().
                AfterMap((dto, model) => model.IdEscala = dto.IdEscala);
            CreateMap<Escala, EscalaDTO>()
                .AfterMap((model, dto) => dto.IdEscala = model.IdEscala);

                // Mapeando a classe Frequencia
            CreateMap<FrequenciaDTO, Frequencia>().
                AfterMap((dto, model) => model.IdFrequencia = dto.IdFrequencia);
            CreateMap<Frequencia, FrequenciaDTO>()
                .AfterMap((model, dto) => dto.IdFrequencia = model.IdFrequencia);

                    // Mapeando a classe Frequencia
            CreateMap<ChamadaDTO, Chamada>().
                AfterMap((dto, model) => model.IdChamada = dto.IdChamada);
            CreateMap<Chamada, ChamadaDTO>()
                .AfterMap((model, dto) => dto.IdChamada = model.IdChamada);
        }
    }
}
