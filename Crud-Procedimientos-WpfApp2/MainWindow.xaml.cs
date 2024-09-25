using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.SqlClient;
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
using SqlCommand = Microsoft.Data.SqlClient.SqlCommand;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using SqlDataReader = Microsoft.Data.SqlClient.SqlDataReader;
using SqlParameter = Microsoft.Data.SqlClient.SqlParameter;

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

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            Clientes cli = new Clientes();

            cli.Show();

        }

        // Para listar los clientes
        private void Button_Click_1_Listar(object sender, RoutedEventArgs e)
        {
            try
            {
                string SQLconnection = "Server=DEV\\SQLEXPRESS;Database=Neptuno;User ID=userNeptuno;Password=123456;" +
                    "TrustServerCertificate=True;";


                SqlConnection conection = new SqlConnection(SQLconnection);

                conection.Open();

                SqlCommand command = new SqlCommand("PA_listarClientes", conection);

                command.CommandType = CommandType.StoredProcedure;

                // Listar clientes
                List<Client> lisClientes = new List<Client>();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Client clientes = new Client();

                    clientes.idCLiente = reader["idcliente"].ToString();
                    clientes.nombreCompañia = reader["nombrecompañia"].ToString();
                    clientes.nombreContacto = reader["nombrecontacto"].ToString();
                    clientes.CargoContacto = reader["cargocontacto"].ToString();
                    clientes.direccion = reader["direccion"].ToString();
                    clientes.ciudad = reader["ciudad"].ToString();
                    clientes.region = reader["region"].ToString();
                    clientes.codPostal = reader["codpostal"].ToString();
                    clientes.pais = reader["pais"].ToString();
                    clientes.telefono = reader["telefono"].ToString();
                    clientes.fax = reader["fax"].ToString();
                    clientes.activo = Convert.ToInt32(reader["activo"]);
                    lisClientes.Add(clientes);
                }

                conection.Close();

                listClient.ItemsSource = lisClientes;
            }
            catch (Exception ex)

            {
                MessageBox.Show("Erro en consulta");
                throw;
            }
        }

        // Para crear los clientes
        private void registerClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string SQLconnection = "Server=DEV\\SQLEXPRESS;Database=Neptuno;User ID=userNeptuno;Password=123456;" +
                    "TrustServerCertificate=True;";

                SqlConnection connection = new SqlConnection(SQLconnection);

                connection.Open();

                // comando
                SqlCommand command = new SqlCommand("PA_insertClientes", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter("@idCliente", SqlDbType.VarChar, 20);
                parameter1.Value = txtIdClient.Text;

                SqlParameter parameter2 = new SqlParameter("@NombreCompañia", SqlDbType.VarChar, 100);
                parameter2.Value = txtNameCompany.Text;

                SqlParameter parameter3 = new SqlParameter("@NombreContacto", SqlDbType.VarChar, 100);
                parameter3.Value = txtNameContact.Text;

                SqlParameter parameter4 = new SqlParameter("@CargoContacto", SqlDbType.VarChar, 100);
                parameter4.Value = txtCargContact.Text;

                SqlParameter parameter5 = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
                parameter5.Value = txtDirection.Text;

                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                command.Parameters.Add(parameter3);
                command.Parameters.Add(parameter4);
                command.Parameters.Add(parameter5);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Se creo correctamente");
            }
            catch
            (Exception ex)
            {
                MessageBox.Show("Error de consulta en bd");
                throw;
            }
        }

        private void actualizarClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string SQLconnection = "Server=DEV\\SQLEXPRESS;Database=Neptuno;User ID=userNeptuno;Password=123456;" +
                    "TrustServerCertificate=True;";

                SqlConnection connection = new SqlConnection(SQLconnection);

                connection.Open();

                // Procedimiento para actualizar un cliente
                SqlCommand command = new SqlCommand("PA_updateClient", connection);

                command.CommandType = CommandType.StoredProcedure;

                // Actualizar client

                SqlParameter parameter1 = new SqlParameter("@idCliente", SqlDbType.VarChar, 20);
                parameter1.Value = txtIdClient.Text;

                SqlParameter parameter2 = new SqlParameter("@NombreCompañia", SqlDbType.VarChar, 100);
                parameter2.Value = txtNameCompany.Text;

                SqlParameter parameter3 = new SqlParameter("@NombreContacto", SqlDbType.VarChar, 100);
                parameter3.Value = txtNameContact.Text;

                SqlParameter parameter4 = new SqlParameter("@CargoContacto", SqlDbType.VarChar, 100);
                parameter4.Value = txtCargContact.Text;

                SqlParameter parameter5 = new SqlParameter("@Direccion", SqlDbType.VarChar, 100);
                parameter5.Value = txtDirection.Text;


                command.Parameters.Add(parameter1);
                command.Parameters.Add(parameter2);
                command.Parameters.Add(parameter3);
                command.Parameters.Add(parameter4);
                command.Parameters.Add(parameter5);


                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Cliente actualizado");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error en la consulta bd");
                throw;
            }
        }

        private void eliminarClient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string SQLconnection = "Server=DEV\\SQLEXPRESS;Database=Neptuno;User ID=userNeptuno;Password=123456;" +
                    "TrustServerCertificate=True;";

                SqlConnection connection = new SqlConnection(SQLconnection);

                connection.Open();

                // comando
                SqlCommand command = new SqlCommand("LA_deleteClientes", connection);

                command.CommandType = CommandType.StoredProcedure;

                SqlParameter parameter1 = new SqlParameter("@idCliente", SqlDbType.VarChar, 20);
                parameter1.Value = txtIdClient.Text;

                command.Parameters.Add(parameter1);

                command.ExecuteNonQuery();

                connection.Close();

                MessageBox.Show("Cliente eliminado correctamente");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error en la consulta");
                throw;
            }
        }
    }
}