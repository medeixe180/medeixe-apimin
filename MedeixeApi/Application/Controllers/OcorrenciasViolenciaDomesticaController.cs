using MedeixeApi.Domain.Entities;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class OcorrenciasViolenciaDomesticaController : ApiControllerBase
{
    public OcorrenciasViolenciaDomesticaController(ApplicationDbContext db) : base(db) { }
    
    // [HttpGet]
    // public async Task<List<T>> Browse()
    // {
    //     return await _dbSet.ToListAsync();
    // }
    //
    // [HttpGet("{id}")]
    // public async Task<ActionResult<T>> Read(int id)
    // {
    //     var entity = await _dbSet.FindAsync(id);
    //     if (entity != null) return entity;
    //     return NotFound();
    // }
    //
    // [HttpPost]
    // public async Task<ActionResult<T>> Add(T entity)
    // {
    //     await _dbSet.AddAsync(entity);
    //     await Db.SaveChangesAsync();
    //     return CreatedAtAction(nameof(Browse),entity);
    // }
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