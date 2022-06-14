using AutoMapper;
using Filmes.Data.DTO;
using Filmes.Model;

namespace Filmes.Profiles
{
    public class FilmeProfile : Profile
    {
        public FilmeProfile()
        {
            CreateMap<CreateFilmeDTO, Filme>();
        }
    }
}
