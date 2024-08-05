using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Net.Http;

using System.Net.Http.Json;

namespace AppFormRestaurante
{
    public partial class Form7 : Form
    {
        public Form7()
        {
            InitializeComponent();
        }

        private async void Form7_Load(object sender, EventArgs e)
        {
            await CargarTickets();
        }

        private async Task CargarTickets()
        {
            var url = "https://localhost:44373/api/ticketHistorial";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var tickets = await httpClient.GetFromJsonAsync<List<Ticket>>(url);
                    checkedListBoxTickets.DataSource = tickets;
                    checkedListBoxTickets.DisplayMember = nameof(Ticket.ToString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los tickets: {ex.Message}");
                }
            }
        }

        public class Ticket
        {
            public int ID { get; set; }
            public DateTime Fecha { get; set; }
            public int UsuarioID { get; set; }
            public decimal Valor { get; set; }
            public string Compras { get; set; }

            public override string ToString()
            {
                return $"ID: {ID}, Fecha: {Fecha}, Valor: {Valor:C}, Compras: {Compras}";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // regresar al formulario 4
            Form4 form4 = new Form4();
            form4.Show();
       
            this.Hide();

        }
    }
}
