using Datos;

namespace Negocio
{

    // Aqui es donde se crean la logica de negocio,
    // un ejemplo listar los clientes que son mayores de 18 años
    // OTRO: Listar solo clientes masculinos
    public class NegocioCliente
    {

        // creando un objeto de DatosCliente
        DatosCliente datosCliente = new DatosCliente();

        // en esta parte lo que debemos entender es que podemos tener ademas de CRUD, muchas
        // funciones que necesitemos
        public List<Clientes> ListarClientes()
        {
            return datosCliente.ListarClientes();
        }

        // LO QUE PODEMOS OBSERVAR
        public List<Clientes> ListarClientesMayores18()
        {
            // Primero llamamos nuestra dato de lista total
            List<Clientes> clientes = datosCliente.ListarClientes();

            // creamos una nueva lista de mayores de 18
            List<Clientes> clientMayores = new List<Clientes>();

            // implementados la logica para obtener solo mayores de 18 años
            foreach ( var item in clientes )
            {
                if ( item.edad > 18)
                {
                    clientMayores.Add(item);
                }
            }

            return clientMayores;

        }
    }
}
