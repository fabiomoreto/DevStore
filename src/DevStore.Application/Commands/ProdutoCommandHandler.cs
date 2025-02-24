using DevStore.Domain.Models;
using DevStore.SharedKernel.Data;
using DevStore.SharedKernel.Domain;
using MediatR;

namespace DevStore.Application.Commands
{
    public record CriarProdutoCommand(string Nome, decimal Valor) : IRequest<Result>;
    public record AtualizarProdutoCommand(int Id, string Nome, decimal Valor) : IRequest<Result>;
    public record ExcluirProdutoCommand(int Id) : IRequest<Result>;

    public class ProdutoCommandHandler : 
        IRequestHandler<CriarProdutoCommand, Result>,
        IRequestHandler<AtualizarProdutoCommand, Result>,
        IRequestHandler<ExcluirProdutoCommand, Result>
    {
        private readonly IRepository<Produto> _produtoRepository;

        public ProdutoCommandHandler(IRepository<Produto> produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task<Result> Handle(CriarProdutoCommand request, CancellationToken cancellationToken)
        {
            var result = Produto.CriarProduto(request.Nome, request.Valor);

            if (!result.IsSuccessful) return result.Error;

            _produtoRepository.Add(result.Value);
            await _produtoRepository.UnitOfWork.Commit();

            return Result.Success();
        }

        public async Task<Result> Handle(AtualizarProdutoCommand request, CancellationToken cancellationToken)
        {
            Result result;

            var produto = await _produtoRepository.GetById(request.Id);

            if (produto == null) return Result.Failure(Error.NotFound);

            result = produto.SetarNome(request.Nome);
            if (!result.IsSuccessful) return result.Error;

            result = produto.SetarValor(request.Valor);
            if (!result.IsSuccessful) return result.Error;

            _produtoRepository.Update(produto);
            await _produtoRepository.UnitOfWork.Commit();

            return Result.Success();
        }

        public async Task<Result> Handle(ExcluirProdutoCommand request, CancellationToken cancellationToken)
        {
            var produto = await _produtoRepository.GetById(request.Id);

            if (produto is null) return Result.Failure(Error.NotFound);

            _produtoRepository.Delete(produto);
            await _produtoRepository.UnitOfWork.Commit();

            return Result.Success();
        }
    }
}
