using MedeixeApi.Application.Dto.StatusDto;
using MedeixeApi.Application.UseCases.Statuses.Actions;
using MedeixeApi.Application.UseCases.Statuses.Queries;
using Microsoft.AspNetCore.Mvc;

namespace MedeixeApi.Application.Controllers;

public class StatusController : ApiControllerBase
{
    // BREAD

    [HttpGet]
    public async Task<List<StatusDto>> Browse()
    {
        return await Mediator.Send(new StatusBrowse());
    }

    [HttpGet("{id}")]
    public async Task<StatusDto> Read(int id)
    {
        var reponse = await Mediator.Send(new StatusRead { Id = id });
        return reponse;
    }
    
    [HttpPost]
    public async Task<int> Add(StatusAdd request)
    {
        var response = await Mediator.Send(request);
        return response;
    }
    
    [HttpPut("{id}")]
    public async Task Update(int id, StatusEdit request)
    {
        request.Id = id;
        await Mediator.Send(request);
    }
    
    [HttpDelete("{id}")]
    public async Task Delete(int id)
    {
        await Mediator.Send(new StatusDelete { Id = id });
    }
}