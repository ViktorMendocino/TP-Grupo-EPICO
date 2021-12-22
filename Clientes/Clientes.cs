using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases_de_proyectos
{
    public class Clientes
    {
        public string nombre, apellido,  telefono, nacionalidad, provincia, direccion, razon_social,  cuit;

        public int DNI;

        public int nroCliente;

        public Clientes() //por defecto 
        {
            
        }


        //clientes Consumidor Final
        public Clientes(int nroCliente, string nombre, string apellido, int DNI, string telefono, string nacionalidad, string provincia, string direccion) 
        {
            this.nroCliente = nroCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.DNI  = DNI;
            this.telefono  = telefono;
            this.nacionalidad  =  nacionalidad;
            this.provincia  = provincia;
            this.direccion  = direccion;


        }

        //clientes Corporativos
        public Clientes(int nroCliente, string nombre, string apellido, int DNI, string telefono, string nacionalidad, string provincia, string direccion, string razon_social, string cuit) 
        {
            this.nroCliente = nroCliente;
            this.nombre = nombre;
            this.apellido = apellido;
            this.DNI = DNI;
            this.telefono = telefono;
            this.nacionalidad = nacionalidad;
            this.provincia = provincia;
            this.direccion = direccion;
            this.razon_social = razon_social;
            this.cuit = cuit;
            

        }

        

        public void MostrarClientesConsFinal()
        {
            Console.WriteLine("**********************************************");
            Console.WriteLine("********** CLIENTE CONSUMIDOR FINAL **********");
            Console.WriteLine("**********************************************");
            Console.WriteLine("********** ID CLIENTE: " + nroCliente + " **********");
            Console.WriteLine("nombre: " + nombre);
            Console.WriteLine("apellido: " + apellido);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("telefono: " + telefono);
            Console.WriteLine("nacionalidad: " + nacionalidad);
            Console.WriteLine("provincia: " + provincia);
            Console.WriteLine("direccion: " + direccion);
            Console.WriteLine("**********************************************");
            Console.WriteLine(" ");
        }

        public void MostrarClientesCorp()
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("********** CLIENTE CORPORATIVO **********");
            Console.WriteLine("*****************************************");
            Console.WriteLine("********** ID CLIENTE: " + nroCliente + " **********");
            Console.WriteLine("nombre: " + nombre);
            Console.WriteLine("apellido: " + apellido);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("telefono: " + telefono);
            Console.WriteLine("nacionalidad: " + nacionalidad);
            Console.WriteLine("provincia: " + provincia);
            Console.WriteLine("direccion: " + direccion);
            Console.WriteLine("razon social: " + razon_social);
            Console.WriteLine("cuit: " + cuit);
            Console.WriteLine("**********************************************");
            Console.WriteLine(" ");

        }







    }
}
