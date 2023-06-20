using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MedeixeApi.Application.Common.Exceptions;
using MedeixeApi.Infrastructure.Persistence;
using MediatR;

namespace MedeixeApi.Application.UseCases.TiposViolencia.Actions
{
    public record TiposViolenciaEdit : IRequest<Unit>
    {
        public int Id { get; init; }
        public string? Descricao { get; set; }
    }

    public class TiposViolenciaEditUseCase : IRequestHandler<TiposViolenciaEdit, Unit>
    {
        private readonly ApplicationDbContext _db;

        public TiposViolenciaEditUseCase(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task<Unit> Handle(TiposViolenciaEdit request, CancellationToken cancellationToken)
        {
            var tipoViolencia = await _db.TiposViolencia.FindAsync(request.Id);

            if (tipoViolencia == null)
            {
                throw new NotFoundException(nameof(TiposViolencia), request.Id);
            }

            tipoViolencia.Descricao = request.Descricao ?? tipoViolencia.Descricao;

            await _db.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}