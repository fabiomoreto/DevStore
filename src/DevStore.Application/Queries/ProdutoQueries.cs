using DevStore.Application.Commands;
using DevStore.Application.ModelMappings;
using DevStore.Application.Models;
using DevStore.Domain.Models;
using DevStore.SharedKernel.Data;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevStore.Application.Queries
{
    public record ObterProdutoQuery(int id) : IRequest<ProdutoDto>;
    public record ObterTodosProdutosQuery() : IRequest<IEnumerable<ProdutoDto>>;

    public class ProdutoQueriesHandler : 
        IRequestHandler<ObterProdutoQuery, ProdutoDto>,
        IRequestHandler<ObterTodosProdutosQuery, IEnumerable<ProdutoDto>>
    {
        private readonly IRepository<Produto> _produtoRepository;

        public ProdutoQueriesHandler(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<ProdutoDto> Handle(ObterProdutoQuery request, CancellationToken cancellationToken)
            => (await _produtoRepository.GetById(request.id))?.ToProdutoDto();

        public async Task<IEnumerable<ProdutoDto>> Handle(ObterTodosProdutosQuery request, CancellationToken cancellationToken)
            => (await _produtoRepository.GetAllAsync()).Select(x => x.ToProdutoDto());
    }
}
