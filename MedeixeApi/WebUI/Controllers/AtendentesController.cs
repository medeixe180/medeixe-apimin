using MedeixeApi.Application.UseCases.Atendentes.Actions;
using MedeixeApi.Application.UseCases.Atendentes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class AtendentesController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(AtendenteAdd request)
    {
        return await Mediator.Send(request);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> Update(AtendenteEdit request, int id)
    {
        request.Id = id;
        return await Mediator.Send(request);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> Delete(AtendenteDelete request, int id)
    {
        request.Id = id;
        return await Mediator.Send(request);
    }
    
    [HttpGet]
    public async Task<ActionResult<AtendentesVm>> Browse()
    {
        var usuarios = await Mediator.Send(new AtendenteBrowse());
        return Ok(usuarios);
    }
}