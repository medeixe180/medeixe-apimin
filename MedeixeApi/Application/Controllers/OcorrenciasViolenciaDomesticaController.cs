using MedeixeApi.Domain.Entities;
using MedeixeApi.Infrastructure.Persistence;

namespace MedeixeApi.Application.Controllers;

public class OcorrenciasViolenciaDomesticaController : ApiControllerBase<OcorrenciaViolenciaDomestica>
{
    public OcorrenciasViolenciaDomesticaController(ApplicationDbContext db) : base(db)
    {
        
    }
}