using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webDemo.Models
{
    public class Client
    {
        [Key]
        public int id { get; set; }
        public string nom { get; set; }
        public string prenom { get; set; }
        public string email { get; set; }
        public string addresse { get; set; }
        public string cp { get; set; }
        public string ville { get; set; }

        public Client()
        {

        }

        public Client(int id, string nom, string prenom, string email, string addresse, string cp, string ville)
        {
            this.id = id;
            this.nom = nom;
            this.prenom = prenom;
            this.email = email;
            this.addresse = addresse;
            this.cp = cp;
            this.ville = ville;

        }
    }
}