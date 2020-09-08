
using System.Collections.Generic;
using MyProject.Data;
using MyProject.GenericRepository;
using MyProject.Models;
using MyProject.ViewModel;

namespace MyProject.Repository
{
    public interface ITaskRepository : IGenericRepository<Task>
    {
        List<TaskIndexView> getUnAssignedTask();
    }
}