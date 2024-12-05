using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class EtudiantController : Controller
    {
        public EtudiantController()
        {
            if (Etudiant.Etudiants.Count() == 0)
            {
                Etudiant.Etudiants.Add(new Etudiant()
                {
                    Matricule = "1000",
                    Adress = "SFAX",
                    FullName = "Hafedh Dhouib",
                    DateNaissance = new DateTime(2000, 1, 1)
                });
            }
        }
        public IActionResult Index()
        {
            return View(Etudiant.Etudiants);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Etudiant etudiant, string FullName)
        {
            if (ModelState.IsValid)
            {
                if (Etudiant.Etudiants.Where(x => x.Matricule == etudiant.Matricule).Any())
                {
                    ModelState.AddModelError("","Matricule Exist!!");
                    //ViewBag.error = "matricule existe !!!!";
                    return View(etudiant);
                }
                else
                {
                    Etudiant.Etudiants.Add(etudiant);
                    return RedirectToAction("index");
                }
            }
            return View(etudiant);
        }
        public IActionResult Edit(string matricule)
        {
            var etud = Etudiant.Etudiants.Where(c => c.Matricule.Equals(matricule)).FirstOrDefault();

            return View(etud);
        }
        [HttpPost]
        public IActionResult Edit(Etudiant etud)
        {
            var etudiant = Etudiant.Etudiants.Where(c => c.Matricule.Equals(etud.Matricule)).FirstOrDefault();
            if (etudiant!=null)
            {
                etudiant.FullName = etud.FullName;
                etudiant.Adress = etud.Adress;
                etudiant.DateNaissance = etud.DateNaissance;
            return RedirectToAction("index");
            }
            return View(etud);
        }

        public IActionResult Delete(string matricule)
        {
            var etud = Etudiant.Etudiants.Where(c => c.Matricule.Equals(matricule)).FirstOrDefault();

            return View(etud);
        }
        [HttpPost]
        public IActionResult Delete(string matricule,Etudiant e)
        {
            var etud = Etudiant.Etudiants.Where(c => c.Matricule.Equals(matricule)).FirstOrDefault();
            if (etud!=null)
            {
                Etudiant.Etudiants.Remove(etud);
                return RedirectToAction("index");
            }
            return View(etud);
        }
    }
}
