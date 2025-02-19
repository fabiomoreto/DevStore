﻿using DevStore.Produtos.Domain.Entities;
using DevStore.Produtos.Domain.Interfaces;
using DevStore.Produtos.Infrastructure.Data.Context;
using DevStore.Produtos.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Web.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoController(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        [HttpPost("novo-produto")]
        public async Task<IActionResult> NovoProduto(string nome, decimal valor)
        {
            var produto = new Produto(nome, valor);
            _produtoRepository.Add(produto);
            await _produtoRepository.UnitOfWork.Commit();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProduto(int id)
        {
            var produto = await _produtoRepository.GetById(id);
            return produto != null ? Ok(produto) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _produtoRepository.GetAll();
            return Ok(produtos);
        }

        [HttpPut("atualizar/{id}")]
        public async Task<IActionResult> AtualizarProduto(int id, string nome, decimal valor)
        {
            var produto = await _produtoRepository.GetById(id);
            
            if (produto == null) return NotFound();

            produto.Nome = nome;
            produto.Valor = valor;

            _produtoRepository.Update(produto);
            await _produtoRepository.UnitOfWork.Commit();

            return Ok();
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            var produto = await _produtoRepository.GetById(id);

            if (produto == null) return NotFound();

            _produtoRepository.Delete(produto);
            await _produtoRepository.UnitOfWork.Commit();

            return Ok();
        }
    }
}
