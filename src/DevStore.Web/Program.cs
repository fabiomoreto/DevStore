using DevStore.Domain.Models;
using DevStore.Infra.Data.Repositories;
using DevStore.Infra.Data.Context;
using DevStore.SharedKernel.Data;
using Microsoft.EntityFrameworkCore;

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
            builder.Services.AddDbContext<AppDbContext>(options => options.UseInMemoryDatabase("TestDb"));

            // Add Produto context
            //builder.Services.AddDbContext<ProdutoContext>(options => options.UseInMemoryDatabase("TestDb"));
            builder.Services.AddScoped<IRepository<Produto>, ProdutoRepository>();
            //builder.Services.AddScoped<ProdutoContext>();

            // Add Pedido context
            //builder.Services.AddDbContext<PedidoContext>(options => options.UseInMemoryDatabase("TestDb"));
            builder.Services.AddScoped<IRepository<Pedido>, PedidoRepository>();
            //builder.Services.AddScoped<PedidoContext>();

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
