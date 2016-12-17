using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCProject2.Models;
using MVCProject2.ViewModel;

namespace MVCProject2.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            using(EntityModel em = new EntityModel())
            {
                var genres = em.Genres.ToList();
                var books = em.Books.ToList();
                BookViewModel bookViewModel = new BookViewModel()
                {
                    Genres = genres,
                    Books = books
                };
                
                return View(bookViewModel);
            }
        }

        public ActionResult New()
        {
            using(EntityModel em = new EntityModel())
            {
                var genres = em.Genres.ToList();
                BookViewModel bookViewModel = new BookViewModel()
                {
                    Genres = genres
                };
                return View(bookViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult New(Book book)
        {
            if (!ModelState.IsValid)
            {
                using (EntityModel em = new EntityModel())
                {
                    var genres = em.Genres.ToList();
                    BookViewModel bookViewModel = new BookViewModel()
                    {
                        Genres = genres
                    };
                    return View(bookViewModel);
                }
            }

            using (EntityModel em = new EntityModel())
            {
                em.Books.Add(book);
                em.SaveChanges();
            }

            return RedirectToAction("Index");
        }

        public ActionResult Edit(int id = 0)
        {
            using(EntityModel em = new EntityModel())
            {
                var genre = em.Genres.ToList();
                Book book = em.Books.Find(id);

                if (book == null)
                {
                    return HttpNotFound();
                }

                BookViewModel bookViewModel = new BookViewModel(book)
                {
                    Genres = genre
                };

                return View(bookViewModel);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Book book)
        {
            if (!ModelState.IsValid)
            {
                using (EntityModel em = new EntityModel())
                {
                    var genres = em.Genres.ToList();

                    BookViewModel bookViewModel = new BookViewModel(book)
                    {
                        Genres = genres
                    };
                    return View(bookViewModel);
                }
            }

            using (EntityModel em = new EntityModel())
            {
                em.Entry(book).State = System.Data.Entity.EntityState.Modified;
                em.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int id = 0)
        {
            using (EntityModel em = new EntityModel())
            {
                Book book = em.Books.Find(id);

                if (book == null)
                {
                    return HttpNotFound();
                }

                em.Books.Remove(book);
                em.SaveChanges();

                return RedirectToAction("Index");
            }
        }
    }
}