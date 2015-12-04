using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MS.LibraryApp.Models;
using MS.LibraryApp.Models.ViewModels;
using System.Data.Entity;

namespace MS.LibraryApp.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult CreateOrEdit(int? id = null)
        {
            var db = new LibraryContainer();
            var book = db.Books.Create();

            if (id.HasValue) {
                book = db.Books.Find(id);
            }

            if (book == null) {
                TempData.Add("StatusFail", string.Format("Book ID {0} could not be found.", id));
                return RedirectToAction("Index");
            }

            var viewModel = AutoMapper.Mapper.Map<BookViewModel>(book);
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult CreateOrEdit(BookViewModel viewModel)
        {
            var db = new LibraryContainer();

            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            var model = AutoMapper.Mapper.Map<Book>(viewModel);

            if (viewModel.Id > 0) {
                db.Books.Attach(model);
                db.Entry(model).State = EntityState.Modified;
            } else {
                db.Books.Add(model);
            }

            db.SaveChanges();

            TempData.Add("StatusOK", string.Format("Book ID {0} saved.", model.Id));

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Remove(int id)
        {
            var db = new LibraryApp.Models.LibraryContainer();
            var book = db.Books.Find(id);

            if (book == null) {
                TempData.Add("StatusFail", string.Format("Book ID {0} could not be found.", id));
            } else {
                TempData.Add("StatusOK", string.Format("Book ID {0} removed.", id));
                db.Books.Remove(book);
                db.SaveChanges();
            }

            return RedirectToAction("Index");
        }
    }
}