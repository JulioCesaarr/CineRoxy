using APIFilmes.Data.Dtos;
using APIFilmes.Models;
using AutoMapper;

namespace APIFilmes.Profiles
{
    public class EnderecoProfile : Profile
    {
        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>();
            CreateMap<Endereco, ReadEnderecoDto>();
            CreateMap<UpdateEnderecoDto, Endereco>(); 
        }
    }
}
