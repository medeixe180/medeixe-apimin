using AutoMapper;
using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Application.Common.Interfaces;
using MedeixeApi.Domain.Entities;
using MediatR;

namespace MedeixeApi.Application.UseCases.Statuses.Queries;

public record StatusRead : IRequest<StatusDto>
{
    public int Id { get; set; }
}

public class StatusReadUseCase : IRequestHandler<StatusRead, StatusDto>
{
    private readonly IApplicationDbContext _context;
    private readonly IMapper _mapper;
    
    public StatusReadUseCase(IApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public async Task<StatusDto> Handle(StatusRead request, CancellationToken cancellationToken)
    {
        var entity = await _context.Status
            .FindAsync(new object[] { request.Id }, cancellationToken);
        if (entity == null)
        {
            throw new NotFoundException(nameof(Status), request.Id);
        }
        return _mapper.Map<StatusDto>(entity);
    }
}
