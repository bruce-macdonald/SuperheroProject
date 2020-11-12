using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperheroWebpage.Data;
using SuperheroWebpage.Models;

namespace SuperheroWebpage.Controllers
{
    public class SuperheroController : Controller
    {
        private ApplicationDbContext db { get;}
        public SuperheroController(ApplicationDbContext db)
        {
           this.db = db;
        }
        // GET: SuperheroController
        public ActionResult Index()
        {
            var superheroes = db.Superhero.ToList();
            return View(superheroes);
        }

        // GET: SuperheroController/Details/5
        public ActionResult Details(int id)
        {
            Superhero hero = db.Superhero.Where(hero => hero.SupheroId == id).FirstOrDefault();
            return View(hero);
        }

        // GET: SuperheroController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SuperheroController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Superhero superhero)
        {
            try
            {
                db.Superhero.Add(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Edit/5
        public ActionResult Edit(int id)
        {
            Superhero hero = db.Superhero.Where(h => h.SupheroId == id).FirstOrDefault();
            return View(hero);
        }

        // POST: SuperheroController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int SuperheroId, Superhero superhero)
        {
            try
            {
                db.Superhero.Update(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: SuperheroController/Delete/5
        public ActionResult Delete(int id)
        {
            Superhero hero = db.Superhero.Where(h => h.SupheroId == id).FirstOrDefault();
            return View(hero);
        }

        // POST: SuperheroController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int SuperheroId, Superhero superhero)
        {
            try
            {
                db.Superhero.Remove(superhero);
                db.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
