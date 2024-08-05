using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http.Json;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;
using System.Net.Http;


namespace AppFormRestaurante
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private async void btnAgregarMenu_Click_1(object sender, EventArgs e)
        {
            var url = "https://localhost:44373/api/menu/";
            if (decimal.TryParse(txtPrecio.Text, out decimal precio))
            {
                var nuevoMenu = new Menus
                {
                    Nombre = txtNombre.Text,
                    Descripcion = txtDescripcion.Text,
                    Precio = precio,
                };

                using (var httpClient = new HttpClient())
                {
                    var response = await httpClient.PostAsJsonAsync(url, nuevoMenu);
                    if (response.IsSuccessStatusCode)
                    {
                        MessageBox.Show("Menú agregado exitosamente.");
                        // enviar de regreso al form4
                        Form4 form4 = new Form4();
                        form4.ShowDialog();
                        
                        this.Hide();

                    }
                    else
                    {
                        MessageBox.Show($"Error: {response.StatusCode}");
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un precio válido.");
            }
        }
        
        public class Menus
        {
            public int Id { get; set; } // Propiedad Id
            public string Nombre { get; set; } // Propiedad Nombre
            public string Descripcion { get; set; } // Propiedad Descripcion
            public decimal Precio { get; set; } // Propiedad Precio
            public string Categoria { get; set; } // Propiedad Categoria
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void solonumero(object sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && e.KeyChar != (char)Keys.Back)
            {
                e.Handled = true;
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //regresar al form4
            Form4 form4 = new Form4();
            form4.Show();
            this.Hide();
        }
    }
}
