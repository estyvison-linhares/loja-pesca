using MediatR;

namespace LojaPesca.Application.Features.Pecas;

public class CadastrarPecaCommand : IRequest<int>
{
    public string Nome { get; set; } = string.Empty;
    public string Descricao { get; set; } = string.Empty;
    public decimal Preco { get; set; }
    public int QuantidadeEstoque { get; set; }
}
