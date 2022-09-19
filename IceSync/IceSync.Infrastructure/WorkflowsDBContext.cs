using IceSync.DomainModel;
using Microsoft.EntityFrameworkCore;

namespace IceSync.Infrastructure
{
    public class WorkflowsDBContext : DbContext
    {
        public WorkflowsDBContext(DbContextOptions<WorkflowsDBContext> options) : base(options)
        {

        }

        public DbSet<Workflow> Workflows { get; set; }
    }
}
