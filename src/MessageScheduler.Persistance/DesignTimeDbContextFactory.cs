using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace MessageScheduler.Persistence
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<MessageSchedulerContext>
    {
        public const string ConnectionString = @"Data Source = localhost\SQLEXPRESS; Initial Catalog = MessageSchedulerDb; Integrated Security = SSPI; Connect Timeout = 30; Application Name = MessageScheduler;";

        public MessageSchedulerContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<MessageSchedulerContext>();
            Console.WriteLine($"ConnectionString: {ConnectionString}");
            builder.UseSqlServer(ConnectionString);
            return new MessageSchedulerContext(builder.Options);
        }
    }
}
