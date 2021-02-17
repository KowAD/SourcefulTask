using AutoMapper;
using AutoMapper.QueryableExtensions;
using SourcefulTask.Application.Common.Interfaces;
using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Application.Common.Models;
using SourcefulTask.Application.Addresses.Queries.GetAddress;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SourcefulTask.Application.Addresses.Queries.GetAddressesWithPagination
{
    public class GetAddressesWithPaginationQuery : IRequest<PaginatedList<AddressDto>>
    {
        public int EmployeeId { get; set; }
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }

    public class GetAddressesWithPaginationQueryHandler : IRequestHandler<GetAddressesWithPaginationQuery, PaginatedList<AddressDto>>
    {
        private readonly IApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAddressesWithPaginationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<PaginatedList<AddressDto>> Handle(GetAddressesWithPaginationQuery request, CancellationToken cancellationToken)
        {
            return await _context.Addresses
                .Where(x => x.EmployeeId == request.EmployeeId)
                .OrderBy(x => x.City)
                .ProjectTo<AddressDto>(_mapper.ConfigurationProvider)
                .PaginatedListAsync(request.PageNumber, request.PageSize); ;
        }
    }
}
