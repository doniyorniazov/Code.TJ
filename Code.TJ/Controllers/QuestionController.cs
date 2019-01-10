using Code.TJ.Models;
using Code.TJ.SQL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Code.TJ.Controllers
{
    public class QuestionController : Controller
    {
        public EntityContext Context;
        // GET: Question
        public ActionResult Index()
        {
            Context = new EntityContext();
            return View(new TaskItem(Context));
        }
    }
}