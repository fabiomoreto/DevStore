using DevStore.Application.ModelMappings;
using DevStore.Domain.Models;
using DevStore.SharedKernel.Data;
using Microsoft.AspNetCore.Mvc;

namespace DevStore.Web.Controllers
{
    [Route("api/pedidos")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        private readonly IRepository<Pedido> _pedidoRepository;
        private readonly IRepository<Produto> _produtoRepository;

        public PedidoController(
            IRepository<Pedido> pedidoRepository,
            IRepository<Produto> produtoRepository)
        {
            _pedidoRepository = pedidoRepository;
            _produtoRepository = produtoRepository;
        }

        [HttpPost("novo-pedido")]
        public async Task<IActionResult> NovoPedido(string nomeCliente, string emailCliente, int idProduto)
        {
            var produto = await _produtoRepository.GetById(idProduto);
            
            if (produto is null) return BadRequest("Produto não encontrado.");

            var pedidoItem = new PedidoItem(produto.Id, 1);

            var pedido = new Pedido(nomeCliente, emailCliente);

            pedido.AdicionarItem(pedidoItem);

            _pedidoRepository.Add(pedido);
            
            await _pedidoRepository.UnitOfWork.Commit();

            return Ok();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPedido(int id)
        {
            var pedidoDto = (await _pedidoRepository.GetById(id))?.ToPedidoDto();
            return pedidoDto != null ? Ok(pedidoDto) : NotFound();
        }


        [HttpPut("adicionar-produto/{id}")]
        public async Task<IActionResult> AdicionarItemProduto(int id, int idProduto, int quantidade)
        {
            var pedido = await _pedidoRepository.GetById(id);
            if (pedido == null) return NotFound();

            var produto = await _produtoRepository.GetById(idProduto);
            if (produto is null) return BadRequest("Produto não encontrado.");

            var pedidoItem = new PedidoItem(produto.Id, 1);

            pedido.AdicionarItem(pedidoItem);

            _pedidoRepository.Update(pedido);
            await _pedidoRepository.UnitOfWork.Commit();

            return Ok();
        }

        [HttpPut("remover-produto/{id}")]
        public async Task<IActionResult> RemoverItemProduto(int id, int idProduto)
        {
            var pedido = await _pedidoRepository.GetById(id);
            if (pedido == null) return NotFound();

            var item = pedido.Itens.Where(i => i.Id == idProduto).FirstOrDefault();
            if (item is null) return BadRequest("Produto não encontrado no pedido.");

            pedido.RemoverItem(item);

            _pedidoRepository.Update(pedido);
            await _pedidoRepository.UnitOfWork.Commit();

            return Ok();
        }

        [HttpPut("pagar/{id}")]
        public async Task<IActionResult> PagarPedido(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);

            if (pedido == null) return NotFound();

            pedido.ConfirmarPagamento();

            _pedidoRepository.Update(pedido);
            await _pedidoRepository.UnitOfWork.Commit();

            return Ok();
        }

        [HttpDelete("excluir/{id}")]
        public async Task<IActionResult> ExcluirPedido(int id)
        {
            var pedido = await _pedidoRepository.GetById(id);

            if (pedido == null) return NotFound();

            _pedidoRepository.Delete(pedido);
            await _pedidoRepository.UnitOfWork.Commit();

            return Ok();
        }
    }
}
