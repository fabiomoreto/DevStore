using DevStore.Domain.Models;
using DevStore.Infra.Data.Repositories;
using DevStore.Infra.Data.Context;
using DevStore.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Reflection;
using DevStore.Application.Commands;
using DevStore.Application.Queries;
using DevStore.Application.Models;
using DevStore.SharedKernel.Domain; // Add this line

namespace DevStore.WebApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Add app context
            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

            // Add repositórios
            builder.Services.AddScoped<IRepository<Produto>, ProdutoRepository>();
            builder.Services.AddScoped<IRepository<Pedido>, PedidoRepository>();

            // Register MediatR services
            builder.Services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
            });

            // Register command handler
            builder.Services.AddTransient<IRequestHandler<CriarProdutoCommand, Result>, ProdutoCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<AtualizarProdutoCommand, Result>, ProdutoCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<ExcluirProdutoCommand, Result>, ProdutoCommandHandler>();
            builder.Services.AddTransient<IRequestHandler<ObterProdutoQuery, ProdutoDto>, ProdutoQueriesHandler>();
            builder.Services.AddTransient<IRequestHandler<ObterTodosProdutosQuery, IEnumerable<ProdutoDto>>, ProdutoQueriesHandler>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
