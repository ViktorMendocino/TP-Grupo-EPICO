using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Clases_de_proyectos
{
    public class Clientes
    {
        public string nombre, apellido, DNI, telefono, nacionalidad, provincia, direccion, razon_social,  cuit;

        public static int Id_Cliente = 0;

        public Clientes() //por defecto 
        {
            
        }


        //clientes Consumidor Final
        public Clientes(string nombre, string apellido, string DNI, string telefono, string nacionalidad, string provincia, string direccion) 
        {
            this.nombre = nombre;
            this.apellido = apellido;
            this.DNI  = DNI;
            this.telefono  = telefono;
            this.nacionalidad  =  nacionalidad;
            this.provincia  = provincia;
            this.direccion  = direccion;


        }

        //clientes Corporativos
        public Clientes(string nombre, string apellido, string DNI, string telefono, string nacionalidad, string provincia, string direccion, string razon_social, string cuit) 
        {
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
            Console.WriteLine("ID: " + Id_Cliente);
            Console.WriteLine("nombre: " + nombre);
            Console.WriteLine("apellido: " + apellido);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("telefono: " + telefono);
            Console.WriteLine("nacionalidad: " + nacionalidad);
            Console.WriteLine("provincia: " + provincia);
            Console.WriteLine("direccion: " + direccion);
            
        }

        public void MostrarClientesCorp()
        {
            Console.WriteLine("nombre: " + nombre);
            Console.WriteLine("apellido: " + apellido);
            Console.WriteLine("DNI: " + DNI);
            Console.WriteLine("telefono: " + telefono);
            Console.WriteLine("nacionalidad: " + nacionalidad);
            Console.WriteLine("provincia: " + provincia);
            Console.WriteLine("direccion: " + direccion);
            Console.WriteLine("razon social: " + direccion);
            Console.WriteLine("cuit: " + cuit);

        }







    }
}
