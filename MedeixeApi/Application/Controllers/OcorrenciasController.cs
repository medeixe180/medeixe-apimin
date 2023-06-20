using MedeixeApi.Application.UseCases.Ocorrencias.Queries.BrowseOcorrenciasViolenciaDomestica;
using MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;
using MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class OcorrenciasController : ApiControllerBase
{
    public OcorrenciasController(ApplicationDbContext db) : base(db)
    {
    }

    [HttpGet]
    public async Task<ActionResult<OcorrenciasVm>> Browse()
    {
        return await Mediator.Send(new OcorrenciasBrowseQuery());
    }

    [HttpPost]
    public async Task<ActionResult<int>> Add(OcorrenciasAdd command)
    {
        return await Mediator.Send(command);
    }
    
    [HttpPut]
    public async Task<ActionResult> Edit(int id, OcorrenciasEdit command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }
    
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     return NoContent();
    // }
}