using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Proyecto2_2024a.Models
{
    public class TicketHistorial
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [Required]
        public int UsuarioID { get; set; }

        [Required]
        public int Valor { get; set; }

        [Required]
        public string Compras { get; set; }
        [Required]
        public bool Sesion { get; set; }

    }
}