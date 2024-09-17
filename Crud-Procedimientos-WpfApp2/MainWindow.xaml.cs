using Microsoft.Data.SqlClient;
using System.Data;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Crud_Procedimientos_WpfApp2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        // Registrar un gato
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Server=DEV\\SQLEXPRESS; Database=Lab03DB; Integrated Security=True; TrustServerCertificate=True;";


                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();

                // Se usa para relizar una consulta, siempre tomando en cuenta el uso de procedimientos al
                // macenados
                SqlCommand command = new SqlCommand("LA_insertCat", connection);
                command.CommandType = CommandType.StoredProcedure;

                // Usamos  el sqlparameter para definir los campos a utilizar
                SqlParameter parameter1 = new SqlParameter("@Name", SqlDbType.VarChar, 100);
                parameter1.Value = txtNombre.Text;

                SqlParameter parameter2 = new SqlParameter("@Age", SqlDbType.Int);
                parameter2.Value = txtEdad.Text;

                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Registro existoso");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en el registro");

                throw;

            }

        }

        private void ListCat_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string connectionString = "Server=DEV\\SQLEXPRESS; Database=Lab03DB; Integrated Security=True; TrustServerCertificate=True;";

                // Conection
                SqlConnection connection = new SqlConnection(connectionString);

                connection.Open();


                // Comando
                SqlCommand command = new SqlCommand("LA_listaGatos", connection);

                command.CommandType = CommandType.StoredProcedure;

                // Creamos nuestra clase y lo llamamos

                List<Cat> listCat = new List<Cat>();

                // Usamos el reader : conectado
                SqlDataReader sqlDataReader = command.ExecuteReader();

                while (sqlDataReader.Read())
                {
                    Cat cats = new Cat();

                    cats.CatId = Convert.ToInt32(sqlDataReader["catid"]);
                    cats.Name = sqlDataReader["name"].ToString();
                    cats.Age = Convert.ToInt32(sqlDataReader["age"]);
                    listCat.Add(cats);

                }

                // Cerramos la conexion
                connection.Close();

                // Llamos el nombre de data grid
                listGatos.ItemsSource = listCat;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la consulta");
                throw;
            }
        }
    }
}