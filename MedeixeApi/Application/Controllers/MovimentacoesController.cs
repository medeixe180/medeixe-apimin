using MedeixeApi.Application.UseCases.Movimentacoes.Actions;
using MedeixeApi.Application.UseCases.Movimentacoes.Queries;
using MedeixeApi.Application.UseCases.Statuses.Queries;
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
    
    [HttpGet("ocorrencia/{id}/movimentacoes")]
    public async Task<ActionResult<List<MovimentacaoDto>>> MovimentacoesByOcorrenciaBrowse(int id)
    {
        var movimentacoes = await Mediator.Send(new MovimentacoesByOcorrenciaBrowse { OcorrenciaId = id });
        return Ok(movimentacoes);
    }
    
    [HttpGet ("ocorrencia/{id}/status")]
    public async Task<ActionResult<StatusDto>> StatusMaisRecenteRead(int id)
    {
        var status = await Mediator.Send(new StatusMaisRecenteRead { OcorrenciaId = id });
        return Ok(status);
    }
}