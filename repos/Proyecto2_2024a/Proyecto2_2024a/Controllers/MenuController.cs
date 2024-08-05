using Proyecto2_2024a.DAL;
using Proyecto2_2024a.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Proyecto2_2024a.Controllers
{
    public class MenuController : ApiController
    {
        private Proyecto2_2024aContext db = new Proyecto2_2024aContext();

        [HttpGet]
        public IEnumerable<Menu> ObtenerMenus()
        {
            return db.Menus.ToList();
        }

        [HttpGet]
        public Menu ObtenerMenu(int id)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return menu;
        }

        [HttpPost]
        public HttpResponseMessage CrearMenu(Menu menu)
        {
            if (ModelState.IsValid)
            {
                db.Menus.Add(menu);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, menu);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = menu.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        public HttpResponseMessage ActualizarMenu(int id, Menu menu)
        {
            if (ModelState.IsValid && id == menu.ID)
            {
                db.Entry(menu).State = EntityState.Modified;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Request.CreateResponse(HttpStatusCode.NotFound);
                }
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpDelete]
        public HttpResponseMessage BorrarMenu(int id)
        {
            Menu menu = db.Menus.Find(id);
            if (menu == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Menus.Remove(menu);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, menu);
        }
    }
}
