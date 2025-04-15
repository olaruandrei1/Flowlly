using Microsoft.EntityFrameworkCore;
using Ollyware.Flowlly.Core.API.Domain.Entities;

namespace Ollyware.Flowlly.Core.API.Persistence.DatabaseContexts;

public class TasksContext(DbContextOptions<TasksContext> options) : DbContext(options)
{
    public DbSet<TaskEntity> Tasks { get; set; } = null!;
}
