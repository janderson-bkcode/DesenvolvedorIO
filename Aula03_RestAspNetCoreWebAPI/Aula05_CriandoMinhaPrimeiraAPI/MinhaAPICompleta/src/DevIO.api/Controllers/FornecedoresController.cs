using AutoMapper;
using DevIO.api.ViewModels;
using DevIO.Business.Intefaces;
using DevIO.Business.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevIO.api.Controllers
{
    [Route("api/fornecedores")]
    public class FornecedoresController : MainController
    {
        private readonly IFornecedorRepository _fornecedorRepository;
        private readonly IFornecedorService _fornecedorService;
        private readonly IEnderecoRepository _enderecoRepository;
        private readonly IMapper _mapper;


        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IMapper mapper,
                                      IFornecedorService fornecedorService, INotificador notificador, IEnderecoRepository enderecoRepository) : base(notificador)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
            _enderecoRepository = enderecoRepository;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<FornecedorViewModel>>> ObterTodos()
        {
            //Mapeando para os dados virem de Fornecedores e serem mapeados para a  ViewModel
            var fornecedor = _mapper.Map<IEnumerable<FornecedorViewModel>>(await _fornecedorRepository.ObterTodos());
            return Ok(fornecedor);
        }
        [HttpGet("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> ObterPorId(Guid id)
        {
            //Mapeando para os dados virem de Fornecedores e serem mapeados para a  ViewModel
            // var fornecedor = _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterPorId(id));
            var fornecedor = await ObterFornecedorProdutosEndereco(id);//Chamando método abaixo de forma Encapsulada
            if (fornecedor == null) return NotFound();
            return fornecedor;
        }
        //Encapsulando lógida de obter dados Fornecedor através de um Id tipo Guid
        public async Task<FornecedorViewModel> ObterFornecedorProdutosEndereco(Guid id)
        {
           return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorProdutosEndereco(id));
        }

        [HttpPost]
        public async Task<ActionResult<FornecedorViewModel>> Adicionar(FornecedorViewModel fornecedorViewModel)
        {
          

            if (!ModelState.IsValid) return CustomResponse(ModelState); /*return BadRequest();*/

            //Mapeando o Fornecedor através da FornecedorViewModel Recebida no Post
            //var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            //Chamando a Service que grava no banco. O repository apenas lê **importante isso ein vacilão
            // var result = await _fornecedorService.Adicionar(fornecedor);

            await _fornecedorService.Adicionar(_mapper.Map<Fornecedor>(fornecedorViewModel));


            //if (!result) return BadRequest();
           //   return Ok(fornecedor);    
            return CustomResponse(fornecedorViewModel);

                 
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id,FornecedorViewModel fornecedorViewModel)
        {
            // if (id != fornecedorViewModel.Id) return BadRequest();
            if (id != fornecedorViewModel.Id)
            {
                NotificarErro("O id informado não é o mesmo que foi passado na query");
                return CustomResponse(fornecedorViewModel);
            }
       
            if (!ModelState.IsValid) return CustomResponse(ModelState);//return BadRequest();

            //Mapeando o Fornecedor através da FornecedorViewModel Recebida no Post
           // var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            //Chamando a Service que grava no banco. O repository apenas lê **importante isso ein vacilão
           // var result = await _fornecedorService.Atualizar(fornecedor);

           await _fornecedorService.Atualizar(_mapper.Map<Fornecedor>(fornecedorViewModel));
            // if (!result) return BadRequest();

            //return Ok(fornecedor);

            return CustomResponse(fornecedorViewModel);
        }

        [HttpDelete("{id:guid}")]
        
        public async Task<ActionResult<FornecedorViewModel>> Excluir(Guid id)
        {
            var fornecedorViewModel = await ObterFornecedorEndereco(id);

            if (fornecedorViewModel == null) return NotFound();
            //  var result = await _fornecedorService.Remover(id);
            await _fornecedorService.Remover(id);

            //if (!result) return BadRequest();

            //  return Ok(fornecedor);

            return CustomResponse(fornecedorViewModel);
        }

        public async Task<FornecedorViewModel> ObterFornecedorEndereco(Guid id)
        {
            return _mapper.Map<FornecedorViewModel>(await _fornecedorRepository.ObterFornecedorEndereco(id));
        }
    }
}
