using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Infrastructure.Persistence;
using MediatR;

namespace MedeixeApi.Application.UseCases.TiposViolencia.Actions
{
    public record TiposViolenciaDelete : IRequest<Unit>
    {
        public int Id { get; init; }
    }

    public class TiposViolenciaDeleteUseCase : IRequestHandler<TiposViolenciaDelete, Unit>
    {
        private readonly ApplicationDbContext _db;

        public TiposViolenciaDeleteUseCase(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(TiposViolenciaDelete request, CancellationToken cancellationToken)
        {
            var tipoViolencia = await _db.TiposViolencia.FindAsync(request.Id);

            if (tipoViolencia == null)
            {
                throw new NotFoundException(nameof(TiposViolencia), request.Id);
            }

            _db.TiposViolencia.Remove(tipoViolencia);

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}