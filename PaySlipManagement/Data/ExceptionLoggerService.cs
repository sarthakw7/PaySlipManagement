using Microsoft.EntityFrameworkCore;

namespace PaySlipManagement.API.Data
{
    public interface IExceptionLoggerService
    {
        Task LogExceptionAsync(Exception exception);
    }

    public class ExceptionLoggerService : IExceptionLoggerService
    {
        private readonly IDbContextFactory<LoggingDbContext> _dbContextFactory;

        public ExceptionLoggerService(IDbContextFactory<LoggingDbContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }

        public async Task LogExceptionAsync(Exception exception)
        {
            using (var dbContext = await _dbContextFactory.CreateDbContextAsync())
            {
                var exceptionLog = new ExceptionLog
                {
                    ExceptionType = exception.GetType().Name,
                    ExceptionMessage = exception.Message,
                    StackTrace = exception.StackTrace,
                    LoggedAt = DateTime.UtcNow
                };

                await dbContext.ExceptionLogs.AddAsync(exceptionLog);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
