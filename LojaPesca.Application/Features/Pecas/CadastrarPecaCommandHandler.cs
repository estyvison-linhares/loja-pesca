using MediatR;

namespace LojaPesca.Application.Features.Pecas;

public class CadastrarPecaCommandHandler : IRequestHandler<CadastrarPecaCommand, int>
{
    // TODO: Injetar dependências (Repository, Mapper, etc.)
    
    public async Task<int> Handle(CadastrarPecaCommand request, CancellationToken cancellationToken)
    {
        // TODO: Implementar lógica de cadastro de peça
        // 1. Validar dados
        // 2. Mapear Command para Entidade
        // 3. Persistir no repositório
        // 4. Retornar ID da peça cadastrada
        
        await Task.CompletedTask; // Placeholder para compilar
        return 0; // Placeholder
    }
}
