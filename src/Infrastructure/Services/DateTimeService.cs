using SourcefulTask.Application.Common.Interfaces;
using System;

namespace SourcefulTask.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}
