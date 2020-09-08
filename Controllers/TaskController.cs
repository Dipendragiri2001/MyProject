using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyProject.Data;
using MyProject.GenericRepository;
using MyProject.Models;
using MyProject.Repository;
using MyProject.ViewModel;

namespace TaskProject.Controllers
{
    [Authorize]
    public class TaskController : Controller
    {
       
        private readonly ITaskRepository _task;
        private readonly UserManager<IdentityUser> _userManager;

        public TaskController(ITaskRepository task,UserManager<IdentityUser>  userManager)
        {
           
            _task = task;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            
            var currentUser = _userManager.GetUserId(HttpContext.User);
            var tasks = _task.getUnAssignedTask().Where(x=>x.UserId== currentUser).ToList();;
            return View(tasks);
        }
        public IActionResult Create()
        {
            ViewBag.Message = "New";
            return View();
        }
        [HttpPost]
        public IActionResult Create(Task t,string message)
        {
            var currentUser = _userManager.GetUserId(HttpContext.User);
            t.UserId = currentUser;
            if(message.Equals("Update"))
            {
                _task.Update(t);
                
            }
            else if(message.Equals("New")){
            _task.Insert(t);
            }
            _task.Commit();
            return RedirectToAction("Index");
        }
        public IActionResult Assigned()
        {
            
           var data = _task.GetBy(x=>x.isAssigned==true).ToList();
            return View(data);
        }
      
        public IActionResult Assign(int id)
        {
            
            var assignTask = _task.GetSingle(x=>x.Id== id);
            assignTask.isAssigned = true;
            _task.Update(assignTask);
            _task.Commit(); 
            return RedirectToAction("Assigned");
            
        }

        public IActionResult Completed(int id)
        {
            var completeTask = _task.GetSingle(x=>x.Id== id);
            completeTask.isCompleted = true;
            completeTask.CompletedAt = DateTime.Now;
            _task.Update(completeTask);
            _task.Commit();

            return RedirectToAction("Assigned");
        }

        public IActionResult Update(int id)
        {
            ViewBag.Message= "Update";
            var data = _task.GetSingle(x=>x.Id == id);
            return View(nameof(Create),data);

        }

        public IActionResult Delete(int id)
        {
            _task.Delete(x=>x.Id== id);
            _task.Commit();
          
            return RedirectToAction("Index");
           
        }
    }
}
