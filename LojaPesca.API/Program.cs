using LojaPesca.Application.Features.Pecas;
using LojaPesca.API.DTOs;
using MediatR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Configuração do MediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CadastrarPecaCommand).Assembly));

// Configuração do AutoMapper
builder.Services.AddAutoMapper(typeof(CadastrarPecaCommand).Assembly);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

// Minimal API Endpoint para cadastrar peças
app.MapPost("/pecas", async (CadastrarPecaDto dto, IMediator mediator) =>
{
    var command = new CadastrarPecaCommand
    {
        Nome = dto.Nome,
        Descricao = dto.Descricao,
        Preco = dto.Preco,
        QuantidadeEstoque = dto.QuantidadeEstoque
    };

    var pecaId = await mediator.Send(command);
    return Results.Created($"/pecas/{pecaId}", new { id = pecaId });
})
.WithName("CadastrarPeca");

app.Run();
