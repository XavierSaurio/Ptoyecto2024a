using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppFormRestaurante
{
    public partial class Form3 : Form
    {
        private List<Usuario> usuarios; // Cambia Usuarios a Usuario y usa List

        public Form3()
        {
            InitializeComponent();
            usuarios = new List<Usuario>(); // Inicializa usuarios como una lista vacía
        }

        private async void Form3_Load(object sender, EventArgs e)
        {
            await ObtenerUsuarios();
        }

        private async Task ObtenerUsuarios()
        {
            var url = "https://localhost:44373/api/usuarios";
            using (var httpClient = new HttpClient())
            {
                try
                {
                    usuarios = await httpClient.GetFromJsonAsync<List<Usuario>>(url); // Cambia Usuarios a Usuario y usa List
                                                                                      // Aquí puedes usar la lista de usuarios como necesites
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al obtener los usuarios: {ex.Message}");
                }
            }
        }

        private void Comparar()
        {
            // Comparar si el usuario y contraseña son correctos
            foreach (var usuario in usuarios)
            {
                if (usuario.NombreUsuario == txtNombreUsuario.Text && usuario.Contraseña == txtContraseña.Text)
                {
                    // Si el usuario es administrador, me envía al Form4; si no, me envía al Form5
                    if (usuario.Rol == "Administrador")
                    {
                       
                        Form4 form4 = new Form4();
                        form4.Show();
                        this.Hide();
                        

                    }
                    else
                    {
                        
                        Form5 form5 = new Form5(usuario); // Pasa el usuario al constructor de Form5
                        form5.Show();
                        this.Hide();
                        
                    }
                    return;
                }
            }
            MessageBox.Show("Usuario o contraseña incorrectos");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Código para manejar el evento del botón si es necesario
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void butIniciar_Click(object sender, EventArgs e)
        {
            // Comparar si el usuario y contraseña son correctos y mostrar un MessageBox
            Comparar();
        }
    }

    public class Usuario
    {
        public int Id { get; set; } // Añade esta propiedad
        public string NombreUsuario { get; set; }
        public string Contraseña { get; set; }
        public string Rol { get; set; }
    }
}
