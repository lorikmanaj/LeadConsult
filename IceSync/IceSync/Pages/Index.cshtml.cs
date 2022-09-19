using IceSync.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;

namespace IceSync.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public List<IceSync.DomainModel.Workflow> Workflows { get; set; }

        private WorkflowsDBContext _dbContext;

        public IndexModel(ILogger<IndexModel> logger, WorkflowsDBContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
            Workflows = _dbContext.Workflows.ToList();
        }

        public void OnGet()
        {

        }
    }
}
