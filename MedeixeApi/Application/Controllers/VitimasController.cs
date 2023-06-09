using medeixeApi.Application.DTO.VitimaDtos;
using MedeixeApi.Application.UseCases.Vitimas.Actions;
using MedeixeApi.Application.UseCases.Vitimas.Queries.BrowseVitimas;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class VitimasController : ApiControllerBase
{
    public VitimasController(ApplicationDbContext db) : base(db)
    {
    }
    
    [HttpGet]
    public async Task<List<VitimaQueryDto>> Browse()
    {
        return await Mediator.Send(new BrowseVitimasQuery());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> Read(int id)
    {
        return NotFound();
    }
    
    [HttpPost]
    public async Task<ActionResult<int>> Add(VitimaAdd vitimaAdd)
    {
        return await Mediator.Send(vitimaAdd);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Edit(int id, VitimaEdit vitimaEdit)
    {
        if (id != vitimaEdit.Id)
            return BadRequest();
        await Mediator.Send(vitimaEdit);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(VitimaDelete model, int id)
    {
        if (id != model.Id)
            return BadRequest();
        await Mediator.Send(model);
        return Accepted();
    }
}