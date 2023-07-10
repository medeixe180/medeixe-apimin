using MedeixeApi.Application.UseCases.Movimentacoes.Actions;
using MedeixeApi.Application.UseCases.Ocorrencias.Actions;
using MedeixeApi.Application.UseCases.Ocorrencias.Queries;
using MedeixeApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class OcorrenciasController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<List<OcorrenciaDto>>> Browse()
    {
        var ocorrencias = await Mediator.Send(new OcorrenciasBrowse());
        return Ok(ocorrencias);
    }

    [HttpPost]
    public async Task<ActionResult> Add(OcorrenciasAdd command)
    {
        int ocorrenciaId = await Mediator.Send(command);
        return Created("", ocorrenciaId);
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
}