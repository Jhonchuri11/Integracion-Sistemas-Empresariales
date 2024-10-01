using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Clientes
    {
        public string idCLiente { get; set; }

        public string nombreCompañia { get; set; }

        public string nombreContacto { get; set; }

        public string CargoContacto { get; set; }

        public string direccion { get; set; }

        public string ciudad { get; set; }

        public string region { get; set; }

        public string codPostal { get; set; }

        public string pais { get; set; }

        public string telefono { get; set; }

        public string fax { get; set; }
        public int activo { get; set; }

        // un ejemplo este campo edad
        public int edad {  get; set; }
    }
}
