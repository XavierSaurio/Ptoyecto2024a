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
    public class UsuariosController : ApiController
    {
        private Proyecto2_2024aContext db = new Proyecto2_2024aContext();

        [HttpGet]
        public IEnumerable<Usuario> ObtenerUsuarios()
        {
            return db.Usuarios.ToList();
        }

        [HttpGet]
        public Usuario ObtenerUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                throw new HttpResponseException(Request.CreateResponse(HttpStatusCode.NotFound));
            }
            return usuario;
        }

        [HttpPost]
        public HttpResponseMessage CrearUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, usuario);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = usuario.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        [HttpPut]
        public HttpResponseMessage ActualizarUsuario(int id, Usuario usuario)
        {
            if (ModelState.IsValid && id == usuario.ID)
            {
                db.Entry(usuario).State = EntityState.Modified;
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
        public HttpResponseMessage BorrarUsuario(int id)
        {
            Usuario usuario = db.Usuarios.Find(id);
            if (usuario == null)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            db.Usuarios.Remove(usuario);
            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                return Request.CreateResponse(HttpStatusCode.NotFound);
            }
            return Request.CreateResponse(HttpStatusCode.OK, usuario);
        }
    }
}
