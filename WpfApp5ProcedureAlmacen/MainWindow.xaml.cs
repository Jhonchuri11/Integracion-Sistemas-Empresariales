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

namespace WpfApp5ProcedureAlmacen
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Server=DEV\\SQLEXPRESS; Database=Lab03DB; Integrated Security=True; TrustServerCertificate=True;";


            string valueSearch = Busqueda.Text;


           /// string query = "SELECT * FROM Students WHERE FirstName like '%" + valueSearch + "%'";

            string storedProcedure = "P_ListarCats";


            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))



                {

                    // Para usar procedimientos almacendos con WPF, primero unsamos el comand

                    SqlCommand command = new SqlCommand(storedProcedure, connection);

                    command.CommandType = CommandType.StoredProcedure;

                    // Para la busqueda utilizamos el valor definido en el procedimiento alamacenado
                    SqlParameter sqlParameter1 = new SqlParameter("@Name", SqlDbType.VarChar, 50);
                    sqlParameter1.Value = valueSearch;

                    command.Parameters.Add(sqlParameter1);


                    // Usamos un adaptador
                    SqlDataAdapter adapter = new SqlDataAdapter(command);

                    DataTable dataTable = new DataTable();

                    connection.Open();

                    adapter.Fill(dataTable);

                    ListCat.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo conectar");

                throw;
            }
        }

        /*
         * CREACION DE PROCEDIMIENTOS ALMACENADOS
         * 
         * CREATE PROC P_ListarCats 
         * AS
         * BEGIN
         * SELECT * FROM CATS
         * END
         * 
         * 
         * 
         
         */
    }
}