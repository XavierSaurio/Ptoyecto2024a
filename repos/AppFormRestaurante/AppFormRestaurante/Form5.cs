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
using static AppFormRestaurante.Form6;
using System.Net.Http.Json;
using static AppFormRestaurante.Form5;



namespace AppFormRestaurante
{
    public partial class Form5 : Form
    {
        private Usuario usuario;
        private List<Menu> menus; // Lista para almacenar los menús

        public Form5(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            menus = new List<Menu>(); // Inicializa la lista de menús
            lbNombre.Text = usuario.NombreUsuario;
        }

        private async void Form5_Load(object sender, EventArgs e)
        {
            await ObtenerMenus();
            MostrarMenusEnListBox();
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

        private void MostrarMenusEnListBox()
        {
            checkedListBox1.DataSource = menus;
            checkedListBox1.DisplayMember = nameof(Menu.DisplayText); // Muestra el texto formateado en el ListBox
        }

        private void ActualizarPlatosSeleccionados()
        {
            var platosSeleccionados = new List<string>();
            foreach (var item in checkedListBox1.CheckedItems)
            {
                if (item is Menu menu)
                {
                    platosSeleccionados.Add(menu.Nombre);
                }
            }
            lblPlatosSeleccionados.Text = string.Join(", ", platosSeleccionados);
        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Espera a que el evento de cambio de estado se complete
            this.BeginInvoke((MethodInvoker)delegate
            {
                ActualizarPlatosSeleccionados();
            });
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate
            {
                ActualizarPlatosSeleccionados();
            });
            MostrarSeleccion();
        }

        private async void enviarticket(int preciox)
        {
            var url = "https://localhost:44373/api/ticketHistorial";
            var nuevoTicket = new TicketHistorial
            {
                ID = 0,
                Fecha = "2023-10-05T14:48:00",
                UsuarioID = usuario.Id,
                Valor = preciox,
                Compras = lblPlatosSeleccionados.Text,
                Sesion = false
            };
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(url, nuevoTicket);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Ticket agregado exitosamente");
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}");
                }
            }
        }

        private void MostrarSeleccion()
        {
            var platosSeleccionados = lblPlatosSeleccionados.Text;
            decimal precioTotal = 0;

            foreach (var item in checkedListBox1.CheckedItems)
            {
                if (item is Menu menu)
                {
                    precioTotal += menu.Precio;
                }
            }
            
            string mensaje = $"Platos seleccionados: {platosSeleccionados}\nPrecio total: {precioTotal:C}";
            var result = MessageBox.Show(mensaje, "Selección de Platos", MessageBoxButtons.OKCancel);

            if (result == DialogResult.OK)
            {
                enviarticket(Convert.ToInt32(precioTotal));
                // cerrar y volver a abrir el form
                Form5 form5 = new Form5(usuario);
                form5.Show();
                this.Hide();   
            }
            else
            {
                // Acción cuando se presiona Cancelar
                MessageBox.Show("Has cancelado la selección.", "Confirmación");
            }
        }

        public class Menu
        {
            public int Id { get; set; } // Propiedad Id
            public string Nombre { get; set; } // Propiedad Nombre
            public string Descripcion { get; set; } // Propiedad Descripcion
            public decimal Precio { get; set; } // Propiedad Precio

            public string DisplayText => $"{Nombre} - {Precio:C} - {Descripcion}"; // Propiedad para mostrar en el ListBox
        }
        public class TicketHistorial
        {
            public int ID { get; set; }
            public string Fecha { get; set; }
            public int UsuarioID { get; set; }
            public decimal Valor { get; set; }
            public string Compras { get; set; }
            public bool Sesion { get; set; }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
