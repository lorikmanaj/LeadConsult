using IceSync.DomainModel;
using System.Collections.Generic;

namespace IceSync.Infrastructure.Repo
{
    public interface IWorkflowRepository
    {
        IEnumerable<Workflow> FindAll();
        Workflow FindById(int id);
        bool Insert(Workflow entity);
        void Insert(IEnumerable<Workflow> entities);
        void Update(IEnumerable<Workflow> entities);
        bool Delete(int id);
        void Delete(IEnumerable<int> entities);
    }
}
