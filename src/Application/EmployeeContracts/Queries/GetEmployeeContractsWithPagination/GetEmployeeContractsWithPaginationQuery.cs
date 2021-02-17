using AutoMapper;
using AutoMapper.QueryableExtensions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Application.Common.Models;
using SourcefulTask.Application.EmployeeContracts.Queries.GetEmployeeContract;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.EmployeeContracts.Queries.GetEmployeeContractsWithPagination
{
    public class GetEmployeeContractsWithPaginationQuery : IRequest<PaginatedList<EmployeeContractDto>>
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetEmployeeContractsWithPaginationQueryHandler : IRequestHandler<GetEmployeeContractsWithPaginationQuery, PaginatedList<EmployeeContractDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetEmployeeContractsWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<EmployeeContractDto>> Handle(GetEmployeeContractsWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.EmployeeContracts
                .OrderBy(x => x.Number)
                .ProjectTo<EmployeeContractDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
