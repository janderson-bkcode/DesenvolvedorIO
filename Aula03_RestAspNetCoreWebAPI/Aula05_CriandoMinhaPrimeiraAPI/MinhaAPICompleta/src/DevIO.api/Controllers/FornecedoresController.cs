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
        private readonly IMapper _mapper;

        public FornecedoresController(IFornecedorRepository fornecedorRepository,
                                      IMapper mapper,
                                      IFornecedorService fornecedorService)
        {
            _fornecedorRepository = fornecedorRepository;
            _mapper = mapper;
            _fornecedorService = fornecedorService;
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
            if (!ModelState.IsValid) return BadRequest();

            //Mapeando o Fornecedor através da FornecedorViewModel Recebida no Post
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            //Chamando a Service que grava no banco. O repository apenas lê **importante isso ein vacilão
            var result = await _fornecedorService.Adicionar(fornecedor);

            if (!result) return BadRequest();

            return Ok(fornecedor);           
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<FornecedorViewModel>> Atualizar(Guid id,FornecedorViewModel fornecedorViewModel)
        {
            if (id != fornecedorViewModel.Id) return BadRequest();

            if (!ModelState.IsValid) return BadRequest();

            //Mapeando o Fornecedor através da FornecedorViewModel Recebida no Post
            var fornecedor = _mapper.Map<Fornecedor>(fornecedorViewModel);
            //Chamando a Service que grava no banco. O repository apenas lê **importante isso ein vacilão
            var result = await _fornecedorService.Atualizar(fornecedor);

            if (!result) return BadRequest();

            return Ok(fornecedor);
        }
    }
}
