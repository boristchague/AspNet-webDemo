using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace webDemo.Models
{
    public class CustContext : DbContext
    {

        public CustContext():base("name=machaine")
        {

        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Produit> Produits { get; set; }
    }
}