using SourcefulTask.Application.Common.Exceptions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Addresses.Commands.UpdateAddress
{
    public class UpdateAddressCommand : IRequest
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }
    }

    public class UpdateAddressCommandHandler : IRequestHandler<UpdateAddressCommand>
    {
        private readonly IApplicationDbContext _context;

        public UpdateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Unit> Handle(UpdateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = await _context.Addresses.FindAsync(request.Id);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Address), request.Id);
            }

            entity.City = request.City;
            entity.Street = request.Street;
            entity.PostCode = request.PostCode;

            await _context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}

