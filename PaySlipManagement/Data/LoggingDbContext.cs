using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace PaySlipManagement.API.Data
{
    public class LoggingDbContext : DbContext
    {
        public LoggingDbContext(DbContextOptions<LoggingDbContext> options) : base(options) { }

        public DbSet<ExceptionLog> ExceptionLogs { get; set; }
    }
}
