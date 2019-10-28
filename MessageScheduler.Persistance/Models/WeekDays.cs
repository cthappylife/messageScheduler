using System;

namespace MessageScheduler.Persistence.Models
{
    [Flags]
    public enum WeekDays
    {
        Sunday = 1,
        Monday = 2,
        Tuesday = 4,
        Wednesday = 8,
        Thursday = 16,
        Friday = 32,
        Saturday = 64,
        WeekDays = 62,
        WeekEnds = 65,
        EveryDay = 127
    }
}
