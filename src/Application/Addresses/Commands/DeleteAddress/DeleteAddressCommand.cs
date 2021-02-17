using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Addresses.Commands.DeleteAddress
    {
        public class DeleteAddressCommand : IRequest
        {
            public int Id { get; set; }
        }

        public class DeleteAddressCommandHandler : IRequestHandler<DeleteAddressCommand>
        {
            private readonly IApplicationDbContext _context;

            public DeleteAddressCommandHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(DeleteAddressCommand request, CancellationToken cancellationToken)
            {
                var entity = await _context.Addresses.FindAsync(request.Id);

                if (entity == null)
                {
                    throw new NotFoundException(nameof(Address), request.Id);
                }

                _context.Addresses.Remove(entity);

                await _context.SaveChangesAsync(cancellationToken);

                return Unit.Value;
            }
        }
    }

