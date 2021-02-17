using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Employees.Commands.UpdateEmployee
{
    public class UpdateEmployeeCommand : IRequest
    {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Email { get; set; }

        public string Pesel { get; set; }
    }

    public class UpdateEmployeeCommandHandler : IRequestHandler<UpdateEmployeeCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateEmployeeCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateEmployeeCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Employees.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Employee), request.Id);
            }

            entity.FirstName = request.FirstName;
            entity.LastName = request.LastName;
            entity.Email = request.Email;
            entity.Pesel = request.Pesel;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

