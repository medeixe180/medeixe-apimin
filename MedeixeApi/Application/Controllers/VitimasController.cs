using MedeixeApi.Application.Common.Models;
using MedeixeApi.Domain.Entities;
using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class VitimasController : ApiControllerBase<Vitima>
{
    public VitimasController(ApplicationDbContext db) : base(db)
    {
    }
    
    [HttpPost("adicionar")]
    public async Task<ActionResult<Vitima>> AddFromBody([FromBody] VitimaModel vitimaModel)
    {
        var vitima = new Vitima
        {
            Nome = vitimaModel.Nome,
            Idade = vitimaModel.Idade,
            Genero = vitimaModel.Genero,
            Endereco = vitimaModel.Endereco,
            NumeroTelefone = vitimaModel.NumeroTelefone,
            Email = vitimaModel.Email,
            ContatoEmergencia = vitimaModel.ContatoEmergencia,
            MedidaProtetiva = vitimaModel.MedidaProtetiva,
            Ocorrencias = null,
            Created = DateTime.Now,
            CreatedBy = null,
            LastModified = DateTime.Now,
            LastModifiedBy = null
            
        };
        await _dbSet.AddAsync(vitima);
        await Db.SaveChangesAsync();
        return CreatedAtAction(nameof(Browse),vitima);
    }
}