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

namespace Lab04
{
    /// <summary>
    /// Lógica de interacción para Productos.xaml
    /// </summary>
    public partial class Productos : Window
    {
        public Productos()
        {
            InitializeComponent();

            string connectionString = "Data Source=LAB1504-14\\SQLEXPRESS; Initial Catalog=Neptuno; User Id=admin; " +
                "Password=123456";

            
        List<Producto> productos = new List<Producto>();
            try
            {
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                SqlCommand command = new SqlCommand("ListarProductos", connection);

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    int idproducto = reader.GetInt32("idproducto");
                    string nombreProducto = reader.GetString("nombreProducto");
                    string cantidadPorUnidad = reader.GetString("cantidadPorUnidad");
                    decimal precioUnidad = reader.GetDecimal("precioUnidad");
                    int unidadesEnExistencia = reader.GetInt16("unidadesEnExistencia");


                    productos.Add(new Producto { idproducto = idproducto, nombreProducto = nombreProducto, cantidadPorUnidad = cantidadPorUnidad, precioUnidad = precioUnidad, unidadesEnExistencia = unidadesEnExistencia});
                }
                dataGridProductos.ItemsSource = productos;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public class Producto
        {
            public int idproducto { get; set; }
            public string nombreProducto { get; set; }
            public string cantidadPorUnidad { get; set; }
            public decimal precioUnidad { get; set; }
            public int unidadesEnExistencia { get; set; }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window ventanaActual = Window.GetWindow(this);
            ventanaActual.Close();
        }
    }
}
