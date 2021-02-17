using AutoMapper;
using AutoMapper.QueryableExtensions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Application.Common.Models;
using SourcefulTask.Application.Employees.Queries.GetEmployee;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Employees.Queries.GetEmployeesWithPagination
{
    public class GetEmployeesWithPaginationQuery : IRequest<PaginatedList<EmployeeDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetEmployeesWithPaginationQueryHandler : IRequestHandler<GetEmployeesWithPaginationQuery, PaginatedList<EmployeeDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EmployeeDto>> Handle(GetEmployeesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Employees
                .OrderBy(x => x.LastName)
                .ProjectTo<EmployeeDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize);
        }
    }
}
