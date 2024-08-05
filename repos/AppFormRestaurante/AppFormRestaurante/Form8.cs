using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;

namespace AppFormRestaurante
{
    public partial class Form8 : Form
    {
        public Form8()
        {
            InitializeComponent();
        }

        private async void Form8_Load(object sender, EventArgs e)
        {
            await CargarTickets();
        }

        public class Ticket
        {
            public int ID { get; set; }
            public DateTime Fecha { get; set; }
            public int UsuarioID { get; set; }
            public decimal Valor { get; set; }
            public string Compras { get; set; }
            public bool Sesion  { get; set; } // Nueva propiedad para el estado del ticket

            public override string ToString()
            {
                return $"ID: {ID}, Fecha: {Fecha}, Valor: {Valor:C}, Compras: {Compras}, Estado: {Sesion}";
            }
        }

        private async Task CargarTickets()
        {
            var url = "https://localhost:44373/api/ticketHistorial";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    var tickets = await httpClient.GetFromJsonAsync<List<Ticket>>(url);
                    var ticketsFiltrados = tickets.Where(t => !t.Sesion).ToList(); // Filtrar los tickets cuyo estado es false
                    checkedListBoxTickets.DataSource = ticketsFiltrados;
                    checkedListBoxTickets.DisplayMember = nameof(Ticket.ToString);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los tickets: {ex.Message}");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }

        private async void button2_Click(object sender, EventArgs e)
        {
            if (checkedListBoxTickets.SelectedItem is Ticket ticket)
            {
                ticket.Sesion = true;

                // Actualizar el ticket en la API
                var url = $"https://localhost:44373/api/ticketHistorial/{ticket.ID}";
                using (var httpClient = new HttpClient())
                {
                    try
                    {
                        var response = await httpClient.PutAsJsonAsync(url, ticket);
                        if (response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Ticket actualizado correctamente.");
                        }
                        else
                        {
                            MessageBox.Show($"Error al actualizar el ticket: {response.ReasonPhrase}");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al actualizar el ticket: {ex.Message}");
                    }
                }

                // Recargar los tickets para reflejar los cambios
                await CargarTickets();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un ticket.");
            }
        }

    }
}
