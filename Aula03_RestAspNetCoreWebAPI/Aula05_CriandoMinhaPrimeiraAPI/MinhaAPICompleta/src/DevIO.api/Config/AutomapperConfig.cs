using AutoMapper;
using DevIO.api.ViewModels;
using DevIO.Business.Models;

namespace DevIO.api.Config
    {/// <summary>
    /// Classe de configuração para a conversão e mapeamento dos dados das Entitades para as ViewModels e vice-versa para
    /// trazer no Result da controller
    /// </summary>
    public class AutomapperConfig : Profile
    {

        public AutomapperConfig()
        {
            CreateMap<Fornecedor, FornecedorViewModel>().ReverseMap();
            CreateMap<Endereco, EnderecoViewModel>().ReverseMap();
            CreateMap<Produto, ProdutoViewModel>().ReverseMap();

        }
    }
}
