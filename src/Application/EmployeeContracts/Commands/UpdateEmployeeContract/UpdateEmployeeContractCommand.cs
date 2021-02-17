using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;
using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.EmployeeContracts.Commands.UpdateEmployeeContract
{
    public class UpdateEmployeeContractCommand : IRequest
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string Number { get; set; }

        public DateTime ContractDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }

    public class UpdateEmployeeContractCommandHandler : IRequestHandler<UpdateEmployeeContractCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmployeeContractCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeContractCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.EmployeeContracts.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(EmployeeContract), request.Id);
            }

            entity.EmployeeId = request.EmployeeId;
            entity.Number = request.Number;
            entity.ContractDate = request.ContractDate;
            entity.ValidFrom = request.ValidFrom;
            entity.ValidTo = request.ValidTo;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

