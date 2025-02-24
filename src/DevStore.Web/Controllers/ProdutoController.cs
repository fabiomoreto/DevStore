using AG.Products.API.Controllers;
using DevStore.Application.Commands;
using DevStore.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Web.Controllers
{
    [Route("api/produtos")]
    [ApiController]
    public class ProdutoController : MainController
    {
        private readonly ISender _mediator;

        public ProdutoController(ISender mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("novo-produto")]
        public async Task<IActionResult> NovoProduto(CriarProdutoCommand request)
        {
            var result = await _mediator.Send(request);
            return CustomResponse(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterProduto(int id)
        {
            var produto = await _mediator.Send(new ObterProdutoQuery(id));
            return produto != null ? Ok(produto) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodos()
        {
            var produtos = await _mediator.Send(new ObterTodosProdutosQuery());
            return Ok(produtos);
        }

        [HttpPut("atualizar")]
        public async Task<IActionResult> AtualizarProduto(AtualizarProdutoCommand request)
        {
            var result = await _mediator.Send(request);
            return CustomResponse(result);
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirProduto(int id)
        {
            var result = await _mediator.Send(new ExcluirProdutoCommand(id));
            return CustomResponse(result);
        }
    }
}
