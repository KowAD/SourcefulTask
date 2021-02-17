using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Addresses.Commands.CreateAddress
{
    public class CreateAddressCommand : IRequest<int>
    {
        public int EmployeeId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }
    }

    public class CreateAddressCommandHandler : IRequestHandler<CreateAddressCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateAddressCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateAddressCommand request, CancellationToken cancellationToken)
        {
            var entity = new Address
            {
                EmployeeId = request.EmployeeId,
                City = request.City,
                Street = request.Street,
                PostCode = request.PostCode
            };

            _context.Addresses.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
