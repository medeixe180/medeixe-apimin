using MedeixeApi.Application.UseCases.Movimentacoes.Actions;
using MedeixeApi.Application.UseCases.Ocorrencias.Queries.BrowseOcorrenciasViolenciaDomestica;
using MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;
using MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica;
using MedeixeApi.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class OcorrenciasController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<OcorrenciasVm>> Browse()
    {
        return await Mediator.Send(new OcorrenciasBrowseQuery());
    }

    [HttpPost]
    public async Task<ActionResult> Add(OcorrenciasAdd command)
    {
        int ocorrenciaId = await Mediator.Send(command);
        
        MovimentacoesController movimentacoesController = new MovimentacoesController();
        int movimentacaoId = await movimentacoesController.Add(new MovimentacoesAdd
        {
            Ocorrencia = new Ocorrencia { Id = ocorrenciaId },
            Usuario = null
        });

        if (ocorrenciaId == 0 || movimentacaoId == 0)
            return BadRequest();
        
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