using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace webDemo.Models
{
    public class Produit
    {
        [Key]
        public int id { get; set; }
        public string references { get; set; }
        public string description { get; set; }
        public double prix { get; set; }

        public Produit()
        {

        }

        public Produit(string references, string description, double prix)
        {
            this.references = references;
            this.description = description;
            this.prix = prix;

        }

    }
}