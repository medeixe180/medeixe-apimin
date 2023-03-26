using MedeixeApi.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

[ApiController]
[Route("api/[controller]")]
public abstract class ApiControllerBase : ControllerBase
{
    public ApplicationDbContext db;

    protected ApiControllerBase(ApplicationDbContext db)
    {
        this.db = db;
    }
}