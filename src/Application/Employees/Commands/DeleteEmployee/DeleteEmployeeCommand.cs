using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Employees.Commands.DeleteEmployee
    {
        public class DeleteEmployeeCommand : IRequest
        {
            public int Id { get; set; }
        }
        public class DeleteEmployeeCommandHandler : IRequestHandler<DeleteEmployeeCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteEmployeeCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Employees.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Employee), request.Id);
                }

                _context.Employees.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }

