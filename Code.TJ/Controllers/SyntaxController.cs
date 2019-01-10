using Code.TJ.Models;
using Code.TJ.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code.TJ.Controllers
{
    public class SyntaxController : Controller
    {
        public EntityContext Context { get; set; }
        public SyntaxController()
        {
            Context = new EntityContext();
        }

        // GET: Task
        public ActionResult Index()
        {
            var task = Context.GetEntities<TaskItem>().Where(t => t.Type == TaskType.Syntax).ToList();
            return View(task);
        }

        public ActionResult Edit(Guid id)
        {
            var task = Context.GetEntities<TaskItem>().FirstOrDefault(t => t.Id == id);
            return View(task);
        }
    }
}