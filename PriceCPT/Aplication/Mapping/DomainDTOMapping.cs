using AutoMapper;
using PriceCPT.Domain.DTOs;
using PriceCPT.Domain.Models;

namespace PriceCPT.Aplication.Mapping
{
    public class DomainDTOMapping : Profile
    {
        public DomainDTOMapping()
        {
            CreateMap<Produto, ProdutoDTOs>();
            CreateMap<AlteracaoPreco, AlteracaoPrecoDTOs>();
        }
    }
}
