using MedeixeApi.Application.UseCases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class UsuariosController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(UsuarioAdd request)
    {
        return await Mediator.Send(request);
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult<Unit>> Update(UsuarioEdit request, int id)
    {
        request.Id = id;
        return await Mediator.Send(request);
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult<Unit>> Delete(UsuarioDelete request, int id)
    {
        request.Id = id;
        return await Mediator.Send(request);
    }
    
    [HttpGet]
    public async Task<ActionResult<UsuariosVm>> Browse()
    {
        var usuarios = await Mediator.Send(new UsuarioBrowse());
        return Ok(usuarios);
    }
}