using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.EmployeeContracts.Commands.DeleteEmployeeContract
    {
        public class DeleteEmployeeContractCommand : IRequest
        {
            public int Id { get; set; }
        }

        public class DeleteEmployeeContractCommandHandler : IRequestHandler<DeleteEmployeeContractCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteEmployeeContractCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteEmployeeContractCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.EmployeeContracts.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(EmployeeContract), request.Id);
                }

                _context.EmployeeContracts.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }

