using Microsoft.AspNetCore.Mvc;
using TP3.Models;

namespace TP3.Controllers
{
    public class EtudiantController : Controller
    {
        public EtudiantController()
        {
            if (Etudiant.Etudiants.Count()==0) 
            {
                Etudiant.Etudiants.Add(new Etudiant() {
                    Matricule="1000",
                    Adress="SFAX",
                    FullName="Hafedh Dhouib",
                    DateNaissance=new DateTime(2000,1,1)
                });
            }
        }
        public IActionResult Index()
        {
            return View(Etudiant.Etudiants);
        }
    }
}
