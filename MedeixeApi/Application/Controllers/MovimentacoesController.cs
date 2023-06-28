using MedeixeApi.Application.UseCases.Movimentacoes.Actions;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class MovimentacoesController : ApiControllerBase
{
    // BREAD
        
    // A - Add
    [ApiExplorerSettings(IgnoreApi = true)]
    public async Task<int> Add(MovimentacoesAdd command)
    {
        return await Mediator.Send(command);
    }

    [HttpPut]
    public async Task<ActionResult<int>> Edit(MovimentacoesEdit command)
    {
        return await Mediator.Send(command);
    }
}