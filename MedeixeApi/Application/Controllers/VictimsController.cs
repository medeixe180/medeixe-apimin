using MedeixeApi.Domain.Entities;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace MedeixeApi.Application.Controllers;

public class VictimsController : ApiControllerBase
{
    public VictimsController(ApplicationDbContext db) : base(db)
    {
    }
    
    [HttpGet]
    public async Task<List<Victim>> Browse()
    {
        return await db.Victims.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Victim>> Read(int id)
    {
        var victim = await db.Victims.FindAsync(id);
        if (victim != null) return victim;
        return NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<Victim>> Add(Victim victim)
    {
        await db.Victims.AddAsync(victim);
        await db.SaveChangesAsync();
        return CreatedAtAction(nameof(Browse),victim);
    }

    [HttpPut]
    public async Task<ActionResult<Victim>> Edit(Victim victimUpdated)
    {
        var victim = await db.Victims.FindAsync(victimUpdated.Id);
        if (victim is null) return NotFound();
        victim.PhoneNumber = victimUpdated.PhoneNumber;
        victim.Name = victimUpdated.Name;
        victim.ProtectiveMeasure = victimUpdated.ProtectiveMeasure;
        victim.Email = victimUpdated.Email;
        victim.Address = victimUpdated.Address;
        victim.LastModified = DateTime.Now;
        victim.LastModifiedBy = "Admin";
        await db.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var victim = await db.Victims.FindAsync(id);
        if (victim is null) return NotFound();
        db.Victims.Remove(victim);
        await db.SaveChangesAsync();
        return NoContent();
    }
}