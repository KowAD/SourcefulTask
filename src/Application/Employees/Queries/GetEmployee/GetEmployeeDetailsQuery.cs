using AutoMapper.QueryableExtensions;
using SourcefulTask.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

using AutoMapper;

namespace SourcefulTask.Application.Employees.Queries.GetEmployee
{
    public class GetEmployeeDetailsQuery : IRequest<GetEmployeeDetailsDto>
    {
        public int EmployeeId { get; set; }
    }

    public class GetEmployeeDetailsQueryHandler : IRequestHandler<GetEmployeeDetailsQuery, GetEmployeeDetailsDto>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeDetailsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<GetEmployeeDetailsDto> Handle(GetEmployeeDetailsQuery request, CancellationToken cancellationToken)
        {
            var vm = await _context.Employees
                    .Where(e => e.Id == request.EmployeeId)
                    .ProjectTo<GetEmployeeDetailsDto>(_mapper.ConfigurationProvider)
                    .SingleOrDefaultAsync(cancellationToken);

            return vm;
        }
    }
}
