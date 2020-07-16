using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using webDemo.Models;

namespace webDemo.Controllers
{
    public class ProduitController : Controller
    {
        // GET: produit
        
        CustContext db = new CustContext();

        // GET: produit
        public ActionResult index()
        {
            return View(db.Produits.ToList());
        }


        //Get: add new Product
        [HttpGet]
        public ActionResult AddProduit()
        {
            return View();
        }


        //Post : add new Produit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddProduit([Bind(Include = "id,references,description,prix")] Produit pro)
        {
            if (ModelState.IsValid)
            {

                db.Produits.Add(pro);
                db.SaveChanges();
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

                Produit prodt = db.Produits.Find(id);

                if (id == null)
                {
                    return HttpNotFound();
                }

                return View(prodt);
            }



            //Get : Edit Produit
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
            Produit prodt = db.Produits.Find(id);
            if (prodt == null)
                {
                    return HttpNotFound();
                }
                return View(prodt);
            }


            //Post : Edit Produit
            [HttpPut]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "id,references,description,prix")] Produit prod)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(prod).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("index");
                }
                return View(prod);
            }



            //Get : Delete Get
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }

                Produit prodt = db.Produits.Find(id);

                if (prodt == null)
                    {
                        return HttpNotFound();
                    }
                    return View(prodt);
                }


            //Post : Delete Produit
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmation(int id)
            {
                if (ModelState.IsValid)
                {

                    Produit prodt = db.Produits.Find(id);
                    db.Produits.Remove(prodt);
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
