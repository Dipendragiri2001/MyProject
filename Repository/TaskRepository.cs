using System.Collections.Generic;
using System.Linq;
using MyProject.Data;
using MyProject.GenericRepository;
using MyProject.Models;
using MyProject.ViewModel;

namespace MyProject.Repository
{
    public class TaskRepository : GenericRepository<Task>, ITaskRepository
    {
        private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public List<TaskIndexView> getUnAssignedTask()
        {
            var task = _context.Tasks.Where(x=>!x.isAssigned).ToList();
            List<TaskIndexView> t = new List<TaskIndexView>();

            foreach (var item in task)
            {
                t.Add(new TaskIndexView
                {
                    TaskId = item.Id,
                    TaskName = item.TaskName,
                    Description = item.Description,
                    CreatedAt = item.CreatedAt,
                    UserId = item.UserId
                });

            }
            return t;
        }
    }
}