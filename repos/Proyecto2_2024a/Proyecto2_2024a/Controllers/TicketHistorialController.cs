using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using System.Data.Entity.Infrastructure; // Agrega esta línea
using Proyecto2_2024a.Models;
using Proyecto2_2024a.DAL;

namespace Proyecto2_2024a.Controllers
{
    public class TicketHistorialController : ApiController
    {
        private Proyecto2_2024aContext db = new Proyecto2_2024aContext();

        // Método para agregar un ticket al historial
        [HttpPost]
        public HttpResponseMessage AgregarTicket(TicketHistorial ticketHistorial)
        {
            if (ModelState.IsValid)
            {
                ticketHistorial.Fecha = DateTime.Now; // Asegurarse de que la fecha sea la actual
                db.TicketHistorial.Add(ticketHistorial);
                db.SaveChanges();
                HttpResponseMessage response = Request.CreateResponse(HttpStatusCode.Created, ticketHistorial);
                response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = ticketHistorial.ID }));
                return response;
            }
            else
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
            }
        }

        // Método para ver todos los tickets del historial
        [HttpGet]
        public IEnumerable<TicketHistorial> VerTickets()
        {
            return db.TicketHistorial.ToList();
        }
        // metodo para editar solo sesion a true
        [HttpPut]
        public HttpResponseMessage EditarSesion(int id)
        {
            TicketHistorial ticketHistorial = db.TicketHistorial.Find(id);
            if (ticketHistorial == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Ticket con ID = " + id.ToString() + " no encontrado");
            }
            else
            {
                ticketHistorial.Sesion = true;
                try
                {
                    db.SaveChanges();
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, ex);
                }
                return Request.CreateResponse(HttpStatusCode.OK, ticketHistorial);
            }
        }
        
    }
}
