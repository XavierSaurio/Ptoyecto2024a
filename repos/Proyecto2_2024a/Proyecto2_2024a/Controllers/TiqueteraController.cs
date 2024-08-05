using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Proyecto2_2024a.Models;
using Proyecto2_2024a.DAL;
using System.Data.Entity.Infrastructure;

namespace Proyecto2_2024a.Controllers
{
    public class TiqueteraController : ApiController
    {
        private Proyecto2_2024aContext db = new Proyecto2_2024aContext();

        [HttpGet]
        public IEnumerable<Tiquetera> ObtenerTiqueteras()
        {
            return db.Tiqueteras.ToList();
        }

        [HttpGet]
        public Tiquetera ObtenerTiquetera(int id)
        {
            Tiquetera tiquetera = db.Tiqueteras.Find(id);
            if (tiquetera == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return tiquetera;
        }

        [HttpPost]
        public HttpResponseMessage CrearTiquetera(Tiquetera tiquetera)
        {
            if (ModelState.IsValid)
            {
                db.Tiqueteras.Add(tiquetera);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, tiquetera);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = tiquetera.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        public HttpResponseMessage ActualizarTiquetera(int id, Tiquetera tiquetera)
        {
            if (ModelState.IsValid && id == tiquetera.ID)
            {
                db.Entry(tiquetera).State = EntityState.Modified;
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
        public HttpResponseMessage BorrarTiquetera(int id)
        {
            Tiquetera tiquetera = db.Tiqueteras.Find(id);
            if (tiquetera == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Tiqueteras.Remove(tiquetera);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, tiquetera);
        }
    }
}

