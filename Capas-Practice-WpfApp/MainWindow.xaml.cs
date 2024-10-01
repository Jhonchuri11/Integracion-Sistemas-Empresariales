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
using Negocio;
namespace Capas_Practice_WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // creando un objeto global de Datoscliente
        NegocioCliente negocioClient = new NegocioCliente();

        public MainWindow()
        {
            InitializeComponent();
        }

        // Listar clientes
        private void Button_ListarClient(object sender, RoutedEventArgs e)
        {
            try
            {
                listClient.ItemsSource = negocioClient.ListarClientes();
            }
            catch (Exception ex)

            {
                MessageBox.Show("Erroe en consulta y listado de cliente");
                throw;
            }
        }

        private void registerClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void actualizarClient_Click(object sender, RoutedEventArgs e)
        {

        }

        private void eliminarClient_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}