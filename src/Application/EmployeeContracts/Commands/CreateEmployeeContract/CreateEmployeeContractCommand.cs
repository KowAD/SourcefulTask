using System;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Domain.Entities;


namespace SourcefulTask.Application.EmployeeContracts.Commands.CreateEmployeeContract
{
    public class CreateEmployeeContractCommand : IRequest<int>
    {

        public int EmployeeId { get; set; }

        public string Number { get; set; }

        public DateTime ContractDate { get; set; }

        public DateTime ValidFrom { get; set; }

        public DateTime ValidTo { get; set; }
    }

    public class CreateEmployeeContractCommandHandler : IRequestHandler<CreateEmployeeContractCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public CreateEmployeeContractCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateEmployeeContractCommand request, CancellationToken cancellationToken)
        {
            var entity = new EmployeeContract
            {
                EmployeeId = request.EmployeeId,
                Number = request.Number,
                ContractDate = request.ContractDate,
                ValidFrom = request.ValidFrom,
                ValidTo = request.ValidTo
            };

            _context.EmployeeContracts.Add(entity);

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
