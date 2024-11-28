namespace TP3.Models
{
    public class Etudiant
    {
        public string Matricule { get; set; }
        public string FullName { get; set; }
        public DateTime DateNaissance { get; set; }
        public string Adress { get; set; }
        public static List<Etudiant> Etudiants =
            new List<Etudiant>();
    }
}
