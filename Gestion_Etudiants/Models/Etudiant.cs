using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Etudiants.Models
{
    public class Etudiant
    {
        public string CNE { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public string Sexe { get; set; }
        public string DateNaissance { get; set; }
        public string Addresse { get; set; }
        public string Phone { get; set; }
        public int Filiere { get; set; }
        public string FiliereName { get; set; }


    }
}
