using MedeixeApi.Application.Dto.TiposViolenciaDtos;
using MedeixeApi.Application.UseCases.TiposViolencia.Actions;
using MedeixeApi.Application.UseCases.TiposViolencia.Queries;
using MedeixeApi.Application.UseCases.TiposViolencia.Queries.TiposViolenciaBrowse;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class TiposViolenciaController : ApiControllerBase
{
    [HttpGet]
    public async Task<List<TiposViolenciaDto>> Browse()
    {
        return await Mediator.Send(new TiposViolenciaBrowseQuery());
    }

    [HttpPost]
    public async Task<ActionResult> Add(TiposViolenciaAdd command)
    {
        await Mediator.Send(command);
        return CreatedAtAction(nameof(Add), command);
    }

    [HttpPut]
    public async Task<ActionResult> Edit(TiposViolenciaEdit command)
    {
        await Mediator.Send(command);
        return NoContent();
    }

    [HttpDelete]
    public async Task<ActionResult> Delete(TiposViolenciaDelete command)
    {
        await Mediator.Send(command);
        return NoContent();
    }
}