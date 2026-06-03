using MVC_CodeFirstApproach.Models;
using MVC_CodeFirstApproach.Repository;
using System.Web.Mvc;

namespace MVC_CodeFirstApproach.Controllers
{
    public class MovieController : Controller
    {
        IMovieRepository repo = new MovieRepository();

        public ActionResult Index()
        {
            return View(repo.GetAll());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movie movie)
        {
            repo.Insert(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost]
        public ActionResult Edit(Movie movie)
        {
            repo.Update(movie);
            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            return View(repo.GetById(id));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            repo.Delete(id);
            return RedirectToAction("Index");
        }

        public ActionResult MoviesByYear()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoviesByYear(int year)
        {
            var data = repo.GetByYear(year);
            return View(data);
        }

        public ActionResult MoviesByDirector()
        {
            return View();
        }

        [HttpPost]
        public ActionResult MoviesByDirector(string director)
        {
            var data = repo.GetByDirector(director);
            return View(data);
        }
    }
}