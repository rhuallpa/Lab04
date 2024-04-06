using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static Lab04.Productos;

namespace Lab04
{
    /// <summary>
    /// Lógica de interacción para Categorias.xaml
    /// </summary>
    public partial class Categorias : Window
    {
        public Categorias()
        {
            InitializeComponent();

            string connectionString = "Data Source=LAB1504-14\\SQLEXPRESS; Initial Catalog=Neptuno; User Id=admin; " +
                "Password=123456";
            List<Categoria> categorias = new List<Categoria>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand("ListarCategorias", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idcategoria = reader.GetInt32("idcategoria");
                    string nombrecategoria = reader.GetString("nombrecategoria");
                    string descripcion = reader.GetString("descripcion");
                    bool activo = reader.GetBoolean("activo");
                    string CodCategoria = reader.GetString("CodCategoria");

                    categorias.Add(new Categoria { idcategoria = idcategoria, nombrecategoria = nombrecategoria, descripcion = descripcion, activo = activo , CodCategoria = CodCategoria });
                }
                dataGridCategorias.ItemsSource = categorias;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public class Categoria
        {
            public int idcategoria { get; set; }
            public string nombrecategoria { get; set; }
            public string descripcion { get; set; }
            public bool activo { get; set; }
            public string CodCategoria { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
