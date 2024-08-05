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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Button;


namespace AppFormRestaurante
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
        }
        
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        string Rolx = "";
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Rolx = "Cliente";
            }
            else {
               Rolx = "Administrador";
                Label labelSuperClave = new Label();
                labelSuperClave.Text = "SuperClave:";
                labelSuperClave.Location = new Point(90, 225); // Ajusta la posición según tu diseño
                labelSuperClave.Name = "labelSuperClave";
                this.Controls.Add(labelSuperClave);

                // Crear el TextBox para la "SuperClave"
                TextBox textBoxSuperClave = new TextBox();
                textBoxSuperClave.Location = new Point(90, 250); // Ajusta la posición según tu diseño
                textBoxSuperClave.Name = "textBoxSuperClave";
                this.Controls.Add(textBoxSuperClave);
            };
           
        }

        private async void btnAgregarUsuario_Click(object sender, EventArgs e)
        {
            var url = "https://localhost:44373/api/usuarios/";
            var nuevoUsuario = new Usuarios

            {
                NombreUsuario = txtNombreUsuario.Text,
                Contraseña = txtContraseña.Text,
                Rol = Rolx
                //que el radio button que escoja me diga si es cliente o 
            };
            using (var httpClient = new HttpClient())
            {
                var response = await httpClient.PostAsJsonAsync(url, nuevoUsuario);
                if (response.IsSuccessStatusCode)
                {
                    MessageBox.Show("Usuario agregado exitosamente");
                }
                else
                {
                    MessageBox.Show($"Error: {response.StatusCode}");
                }
            }
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton2.Checked)
            {
                Rolx = "Cliente";
            }
            else
            {
                Rolx = "Administrador";
            };
        }

        private void txtNombreUsuario_TextChanged(object sender, EventArgs e)
        {

        }
    }
    public class Usuarios
    {
        public int ID { get; set; }
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }



}
