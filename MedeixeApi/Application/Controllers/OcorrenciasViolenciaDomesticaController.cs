using MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Actions;
using MedeixeApi.Application.UseCases.OcorrenciasViolenciaDomestica.Queries.BrowseOcorrenciasViolenciaDomestica;
using MedeixeApi.Domain.Entities;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class OcorrenciasViolenciaDomesticaController : ApiControllerBase
{
    public OcorrenciasViolenciaDomesticaController(ApplicationDbContext db) : base(db)
    {
    }

    [HttpGet]
    public async Task<ActionResult<List<OcorrenciaViolenciaDomestica>>> Browse()
    {
        return await Mediator.Send(new BrowseOcorrenciasQuery());
    }
    //
    // [HttpGet("{id}")]
    // public async Task<ActionResult<T>> Read(int id)
    // {
    //     var entity = await _dbSet.FindAsync(id);
    //     if (entity != null) return entity;
    //     return NotFound();
    // }
    //
    [HttpPost]
    public async Task<ActionResult<int>> Add(OcorrenciaViolenciaDomesticaAdd command)
    {
        return await Mediator.Send(command);
    }
    //
    // [HttpPut]
    // public async Task<ActionResult<T>> Edit(T entityUpdated)
    // {
    //     _dbSet.Update(entityUpdated);
    //     await Db.SaveChangesAsync();
    //     return NoContent();
    // }
    //
    // [HttpDelete("{id}")]
    // public async Task<IActionResult> Delete(int id)
    // {
    //     var entity = await _dbSet.FindAsync(id);
    //     if (entity is null) return NotFound();
    //     _dbSet.Remove(entity);
    //     await Db.SaveChangesAsync();
    //     return NoContent();
    // }
}