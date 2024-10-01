using Datos;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public  class DatosCliente
    {

        public  List<Clientes> ListarClientes()
        {
            SqlConnection conection = new SqlConnection(AccesoDatos.SQLcadena);

            conection.Open();

            SqlCommand command = new SqlCommand("PA_listarClientes", conection);

            command.CommandType = CommandType.StoredProcedure;

            // Listar clientes
            List<Clientes> lisClientes = new List<Clientes>();

            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                Clientes clientes = new Clientes();

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

            return lisClientes;

        }
    }
}
