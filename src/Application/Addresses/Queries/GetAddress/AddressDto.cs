using SourcefulTask.Application.Common.Mappings;
using SourcefulTask.Domain.Entities;

namespace SourcefulTask.Application.Addresses.Queries.GetAddress
{
    public class AddressDto : IMapFrom<Address>
    {
        public int Id { get; set; }

        public int EmployeeId { get; set; }

        public string City { get; set; }

        public string Street { get; set; }

        public string PostCode { get; set; }
    }
}
