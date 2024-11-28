using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using To_Do_List.Data;
using To_Do_List.Models;

namespace To_Do_List.Controllers
{
    public class ListController : Controller
    {
        private AppliactionDbContext _dbContext = new AppliactionDbContext();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult ItemTemp(string name)
        {
            TempData["name"] = name;
           
            return RedirectToAction(nameof(Item));
        }
        public IActionResult Item()
        {
            
            var ToDoLists = _dbContext.ToDoLists.ToList();
            return View(ToDoLists);
        }
        public IActionResult Add()
        {

            return View();
        }
        public IActionResult AddNew(ToDoList newToDoList)
        {
            _dbContext.ToDoLists.Add(newToDoList);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Item));
        }

        public IActionResult Remove(int Id)
        {
            var toDolist = _dbContext.ToDoLists.Find(Id);
            if (toDolist != null)
            {
                _dbContext.ToDoLists.Remove(toDolist);
                _dbContext.SaveChanges();
            }
            return RedirectToAction(nameof(Item));
        }
        public IActionResult Edit(int Id)
        {
            var toDolist = _dbContext.ToDoLists.Find(Id);
            return View(toDolist);
        }
        public IActionResult EditItem(ToDoList toDolist) 
        {
            _dbContext.ToDoLists.Update(toDolist);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Item));
        }
        
        public IActionResult setCookie()
        {
            CookieOptions cookieOptions = new CookieOptions();
            cookieOptions.Expires = DateTimeOffset.Now.AddDays(1); 
            Response.Cookies.Append("name","mohamed", cookieOptions);
            return Content("cookie saved");
        }
        public IActionResult getCookie()
        {
            
            return Content(Request.Cookies["name"]);
        }
    }
}
