using System;
using MessageScheduler.Persistence.Models;

namespace MessageScheduler.Service
{
    public interface IExecutionTimeResolver
    {
        DateTime Get(Schedule schedule);
    }
}
