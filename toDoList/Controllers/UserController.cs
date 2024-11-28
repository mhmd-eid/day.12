using Microsoft.AspNetCore.Mvc;
using toDoList.Data;
using toDoList.Models;

namespace toDoList.Controllers
{
    public class UserController : Controller
    {
        private readonly ApplictionDbContext _dbcontext = new ApplictionDbContext();


        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Models.Task task)
        {
            _dbcontext.Add(new Models.Task
            {
                Name = task.Name,
                Description = task.Description,
                Time = task.Time

            });
            _dbcontext.SaveChanges();

            return RedirectToAction("Show", "HOME");
        }



        public IActionResult Edit(int taskId)
        {
            var TA = _dbcontext.tasks.Find(taskId);
            if (TA != null)
            {
                return View(TA);
            }
            return View();
        }


        public IActionResult EditNew(Models.Task task)
        {
            _dbcontext.tasks.Update(new Models.Task
            {
                Name = task.Name,
                Description = task.Description,
                Time = task.Time,
                Id = task.Id

            });
            _dbcontext.SaveChanges();

            return RedirectToAction("show", "home");
        }

        public IActionResult Delete(int taskId)
        {
            var T = _dbcontext.tasks.Find(taskId);

            if (T != null)
            {
                _dbcontext.Remove(T);
            }

            _dbcontext.SaveChanges();

            return RedirectToAction("Show","Home");
        }

    }


}