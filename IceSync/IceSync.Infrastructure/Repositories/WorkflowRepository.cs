using IceSync.DomainModel;
using IceSync.Infrastructure.Repo;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace IceSync.Infrastructure
{
    public class WorkflowRepository : IWorkflowRepository
    {
        private WorkflowsDBContext _dbContext;

        public WorkflowRepository(WorkflowsDBContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Workflow FindById(int id)
        {
            return _dbContext.Workflows.Where(_ => _.WorkflowId == id).FirstOrDefault();
        }

        public bool Insert(Workflow entity)
        {
            if (entity != null)
            {
                _dbContext.Add(entity);
                _dbContext.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Delete(int id)
        {
            if (id < 1)
                return false;

            var workflow = _dbContext.Workflows
                .FirstOrDefault(e => e.WorkflowId == id);

            if (workflow == null)
                return false;

            _dbContext.Workflows.Remove(workflow);
            _dbContext.SaveChanges();

            return true;
        }

        public void Delete(IEnumerable<int> ids)
        {
            if (!ids.Any())
            {
                return;
            }

            var itemsToDelete = _dbContext.Workflows
                .Find(ids);

            _dbContext.Workflows
                .RemoveRange(itemsToDelete);

            _dbContext.SaveChanges();
        }

        public IEnumerable<Workflow> FindAll()
        {
            return _dbContext.Workflows.ToList();
        }

        public void Insert(IEnumerable<Workflow> entities)
        {
            var existingEntities = _dbContext
                .Workflows.Where(x => entities.Contains(x));

            var itemsToInsert = entities.Where(x => !existingEntities.Contains(x));

            if (!itemsToInsert.Any())
            {
                return;
            }

            _dbContext.Workflows.AddRange(entities);
            _dbContext.SaveChanges();
        }

        public void Update(IEnumerable<Workflow> entities)
        {
            var itemsFromDb = _dbContext.Workflows.Where(x => entities.Contains(x));

            foreach (var item in entities)
            {
                var record = itemsFromDb.FirstOrDefault(x => x.WorkflowId == item.WorkflowId);

                record.WorkflowId = item.WorkflowId;
                record.WorkflowName = item.WorkflowName;
                record.IsRunning = item.IsRunning;
                record.IsActive = item.IsActive;
                record.MultiExecBehaviour = item.MultiExecBehaviour;

                _dbContext.Workflows.Update(record);
            }

            _dbContext.SaveChanges();
        }
    }
}
