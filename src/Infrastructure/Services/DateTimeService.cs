using DrumSpace.Application.Common.Interfaces;
using System;

namespace DrumSpace.Infrastructure.Services
{
    public class DateTimeService : IDateTime
    {
        public DateTime Now => DateTime.Now;
    }
}