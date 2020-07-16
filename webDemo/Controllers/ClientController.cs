using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;
using webDemo.Models;

namespace webDemo.Controllers
{
    public class ClientController : Controller
    {

        CustContext db = new CustContext();

        // GET: Client
        public ActionResult Index()
        {                            
            return View(db.Clients.ToList());
        }



       [HttpGet]
        public ActionResult AddClient()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClient([Bind(Include = "id,nom,prenom,email,address,cp,ville")] Client client)
        {
            if (ModelState.IsValid)
            {
                String prenom = Request.Form["prenom"];
                String nom = Request.Form["nom"];
                String email = Request.Form["email"];
                String address = Request.Form["address"];
                String cp = Request.Form["cp"];
                String ville = Request.Form["ville"];

                using (var ctx = new CustContext() ) {

                    var cl = new Client();
                    cl.prenom = prenom;
                    cl.nom = nom;
                    cl.email = email;
                    cl.addresse = address;
                    cl.cp = cp;
                    cl.ville = ville;

                    ctx.Clients.Add(cl);
                    ctx.SaveChanges();

                }
                return RedirectToAction("index");
            }
            return View();
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Client client = db.Clients.Find(id);

            if(id == null)
            {
                return HttpNotFound();
            }

            return View(client);
        }



        //Get : Edit client
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }


        //Post : Edit Client
        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nom,prenom,email,address,cp,ville")] Client client)
        {
            if (ModelState.IsValid)
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("index");
            }
            return View(client);
        }



        //Get : Delete Get
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Client client = db.Clients.Find(id);
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }


        //Post : Delete Client
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmation(int id)
        {
            if (ModelState.IsValid)
            {

                Client cli = db.Clients.Find(id);
                db.Clients.Remove(cli);
                db.SaveChanges();
                return RedirectToAction("index");
            }

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
