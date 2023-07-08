using MedeixeApi.Application.UseCases.Usuarios.Queries;
using MedeixeApi.Application.UseCases.Usuarios.Actions;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class UsuariosController : ApiControllerBase
{
    [HttpGet]
    public async Task<UsuariosVm> Browse()
    {
        return await Mediator.Send(new UsuarioBrowse());
    }

    // [HttpGet("{id}")]
    // public async Task<ActionResult> Read(int id)
    // {
    //     return NotFound();
    // }
    
    [HttpPost]
    public async Task<ActionResult<int>> Add(UsuarioAdd usuarioAdd)
    {
        return await Mediator.Send(usuarioAdd);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Edit(int id, UsuarioEdit usuarioEdit)
    {
        if (id != usuarioEdit.Id)
            return BadRequest();
        await Mediator.Send(usuarioEdit);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(UsuarioDelete model, int id)
    {
        if (id != model.Id)
            return BadRequest();
        await Mediator.Send(model);
        return Accepted();
    }
}