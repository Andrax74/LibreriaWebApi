using AutoMapper;
using LibreriaWebApi.Dtos;
using LibreriaWebApi.Models;

namespace LibreriaWebApi.Profiles
{
    public class LibriProfile : Profile
    {
        public LibriProfile()
        {
            CreateMap<Libri, LibriDto>();
        }
    }
}