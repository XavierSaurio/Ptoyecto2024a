using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using static AppFormRestaurante.Form7;

namespace AppFormRestaurante
{
    public partial class Form4 : Form
    {
        private List<Menu> menus; // Lista para almacenar los menús
        private List<Ticket> tickets; // Lista para almacenar los tickets

        public Form4()
        {
            InitializeComponent();
            menus = new List<Menu>(); // Inicializa la lista de menús
            tickets = new List<Ticket>(); // Inicializa la lista de tickets
            
        }

        private async void Form4_Load(object sender, EventArgs e)
        {
            await ObtenerMenus();
            MostrarMenusEnListBox();
            await ObtenerTickets();
            //MostrarTicketsEnListBox();
        }

        private async Task ObtenerMenus()
        {
            var url = "https://localhost:44373/api/menu";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    menus = await httpClient.GetFromJsonAsync<List<Menu>>(url); // Obtiene los menús de la API
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los menús: {ex.Message}");
                }
            }
        }

        private async Task ObtenerTickets()
        {
            var url = "https://localhost:44373/api/ticketHistorial";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    tickets = await httpClient.GetFromJsonAsync<List<Ticket>>(url); // Obtiene los tickets de la API
                   
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los tickets: {ex.Message}");
                }
            }
        }

        public new class Menu
        {
            public int Id { get; set; } // Propiedad Id
            public string Nombre { get; set; } // Propiedad Nombre
            public string Descripcion { get; set; } // Propiedad Descripcion
            public decimal Precio { get; set; } // Propiedad Precio

            public string DisplayText => $"{Nombre} - {Precio:C} - {Descripcion}"; // Propiedad para mostrar en el ListBox
        }

        private void MostrarMenusEnListBox()
        {
            listBox1.DataSource = menus;
            listBox1.DisplayMember = nameof(Menu.DisplayText); // Muestra el texto formateado en el ListBox
        }

        //private void MostrarTicketsEnListBox()
        //{
        //    listBox2.DataSource = tickets;
        //    listBox2.DisplayMember = nameof(Ticket.ToString); // Muestra el texto formateado en el ListBox
        //}

        private void button1_Click(object sender, EventArgs e)
        {
            // me envia al form6
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form7 form7 = new Form7();
            form7.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            // enviar al form8
            Form8 form8 = new Form8();
            form8.Show();
            this.Hide();
            

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
    // lista con todos los tickets llamada LisTotal 

    
    
    

}
