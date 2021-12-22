using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clases_de_proyectos
{
    public class Factura
    {
        public int nroFactura;
        public Clientes clientes;
        public Paquetes paquetes;
        public DateTime Fecha ;

        public Factura(int nroFactura, Clientes c , Paquetes p , DateTime F)
        {
            this.nroFactura = nroFactura;
            clientes = c;
            paquetes = p;
            this.Fecha = F;
        }

        public void mostrarDatos()
        {
            Console.WriteLine("********* PEDIDO NRO " + nroFactura + "*********");
            Console.WriteLine("*** DATOS CLIENTE ***");
            Console.WriteLine(clientes.nombre);
            Console.WriteLine("*** PAQUETE SELECCIONADO ***");
            Console.WriteLine(paquetes.Nombre);
            Console.WriteLine("*** FECHA Y HORA DE CREACION ***");
            Console.WriteLine(Fecha);
        }





    }
}
