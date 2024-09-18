using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Crud_Procedimientos_WpfApp2
{
    /// <summary>
    /// Lógica de interacción para Clientes.xaml
    /// </summary>
    public partial class Clientes : Window
    {
        public Clientes()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                    lisClientes.Add(clientes);
                }

                conection.Close();

                //listCLi.ItemsSource = lisClientes;
            }
            catch (Exception ex) 
            
            {
                MessageBox.Show("Erro en consulta");
                throw;
            }

        }
    }
}
