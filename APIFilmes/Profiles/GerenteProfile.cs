using APIFilmes.Data.Dtos.Gerentes;
using APIFilmes.Models;
using AutoMapper;
using System.Linq;

namespace APIFilmes.Profiles
{
    public class GerenteProfile : Profile
    {
        public GerenteProfile()
        {
            CreateMap<CreateGerenteDto, Gerente>();
            CreateMap<Gerente, ReadGerenteDto>()
                .ForMember(gerente => gerente.Cinemas, opts => opts
                .MapFrom(gerente => gerente.Cinemas
                .Select(c => new { c.Id, c.Nome, c.Endereco, c.EnderecoId })));
        }
    }
}
