using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Clases_de_proyectos;


namespace TP_FINAL___Grupo_8___Neoris_x_UTN
{
   
}
class Program
{


    #region CONSIGNA:
    // -----Empresa de Viajes------
    //Una empresa de viajes quiere registrar las ventas de los paquetes a sus clientes.Dicha empresa suele
    //realizar bonificaciones en función del importe acumulado por las ventas de sus clientes.
    //Dicho software debe administrar:
    //●	Cliente: Debe contener mínimamente nacionalidad, provincia, dirección y teléfono de contacto.Existen clientes particulares que tendrán dni, apellido y nombre, y corporativo que ademas del apellido, nombre y dni del viajante tiene cuit y razón social de la empresa
    //●	Paquetes vendidos: Hay 2 tipos de paquetes: Nacionales, internacionales, Los paquetes internacionales tienen cotización del dolar y una marca indicando si se requiere visa.Ambos tipos de paquetes tienen nombre, precio, lista de lugares (entre 1 y 10), cantidad de días, fecha de viaje, si esta vigente o vencido.Los nacionales tienen impuestos en %, los internacionales en valor fijo.Los nacionales se venden contado y hasta 12 cuotas, los internacionales hasta 6 cuotas.Los paquetes pueden estar activos o inactivos porque ya vencieron.
    //●	Facturación: El sistema tiene registro de las facturas de sus clientes. 
    //Especificaciones de diseño:
    //La empresa conoce todas las facturas realizadas, sus clientes y los paquetes.Cada paquete “conoce” la lista de lugares que se visitan.Cada factura tiene una referencia al cliente al que se le factura.
    //Realizar un sistema que permita:
    // 1.Crear un nuevo cliente validando todos los datos de ingreso.
    // 2.Listar todas las facturas de un cliente y el total de sus ventas
    // 3.Inactivar un paquete.
    // 4.Actualizar el precio de un paquete.
    // 5.Listar los clientes que han tenido al menos dos ventas.  
    // Todo lo que puedan/quieran agregar sobre ésto será bienvenido. 
    #endregion

    static void Main(string[] args)
    {
        #region Variables para controlar el Algoritmo
        ConsoleKeyInfo opcion;
        bool loopBoolean = true;
        int selecccion;
        int orden;
        int LugarInt;

        #endregion

        #region Data-Clientes
        string nombreCliente, apellido, telefono, nacionalidad, provincia, direccion, razon_social, cuit;
        int DNI;

        int nroClienteConsFinal = 0;
        int nroClienteCorp = 0;
        #endregion

        #region Data-Paquetes
        string nombrePaquete;
        string lugares = "vacio";
        bool visa = true;
        double precio, impuestos, Cotizacion_Dolar;
        int Cant_dias;
        DateTime Fecha_Viaje;
        bool vigencia = false;

        string preguntaCuotas;
        int CuotasContadas = 1;

        int nroPaqueteNacional = 0;
        int nroPaqueteInternacional = 0;

        
        #endregion

        Clientes c;
        Paquetes p;

        List<Paquetes> lPaquetesNac = new List<Paquetes>();
        List<Paquetes> lPaquetesInterNac = new List<Paquetes>();

        List<Clientes> lclientes_ConsFinal = new List<Clientes>();
        List<Clientes> lclientes_Corporativos = new List<Clientes>();

        int nroFactura = 0;
        List<Factura> lFactura = new List<Factura>();

        do
        {

            Introduccion();

            do
            {
                opcion = Console.ReadKey(true);
            } while (((int)opcion.KeyChar != 27) && opcion.KeyChar < '1' || opcion.KeyChar > '4');  //Si el usuario Presiona ESC, saldra del programa
            switch (opcion.KeyChar)
            {
                //completado
                //revisar detalles y Bugs detalles
                #region caso_Clientes
                case '1':

                    Console.WriteLine("*** ¡Agregue un cliente nuevo! ***");
                    Console.WriteLine(" ");
                    Console.WriteLine("Indicar tipo de Cliente");
                    Console.WriteLine("[1] --> Cliente de Consumidor Final");
                    Console.WriteLine("[2] --> Cliente Corporativo");
                    Console.WriteLine("[0] --> Regresar al Menu");
                    do
                    {
                        opcion = Console.ReadKey(true);
                    } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                    switch (opcion.KeyChar)
                    {
                        case '0':
                            Console.WriteLine(" ");
                            Console.WriteLine("Regresando al Menu... ");
                            Console.WriteLine(" ");
                            break;

                        case '1':


                            nroClienteConsFinal++;
                            Ingreso_data_clientes();

                            Console.WriteLine(" ");
                            Clientes NewClienteConsFinal = new Clientes(nroClienteConsFinal, nombreCliente, apellido, DNI, telefono, nacionalidad, provincia, direccion);
                            lclientes_ConsFinal.Add(NewClienteConsFinal);
                            Console.WriteLine("------DATOS INGRESADOS------");
                            NewClienteConsFinal.MostrarClientesConsFinal();
                            Console.WriteLine(" ");
                            break;

                        case '2':

                            nroClienteCorp++;
                            Ingreso_data_clientes();
                            #region Datos Clientes Corporativos
                            Console.WriteLine("Ingrese su razon social ");
                            razon_social = Console.ReadLine();
                            Console.WriteLine("Ingrese su CUIT");
                            cuit = Console.ReadLine();
                            #endregion

                            Console.WriteLine(" ");
                            Clientes NewClientecorp = new Clientes(nroClienteCorp, nombreCliente, apellido, DNI, telefono, nacionalidad, provincia, direccion, razon_social, cuit);
                            lclientes_Corporativos.Add(NewClientecorp);
                            Console.WriteLine("------DATOS INGRESADOS------");
                            NewClientecorp.MostrarClientesCorp();
                            Console.WriteLine(" ");
                            break;
                    }


                    break;
                #endregion

                //completado
                //revisar detalles y Bugs
                //hacer que usuarios no puedan agregar opciones distino a lo mostardo
                //ej: si tiene que elegir entre 1 o 2, que no ingrese 8
                #region caso_Paquetes
                case '2':
                    Console.WriteLine("*** ¡Agregue un paquete nuevo! ***");
                    Console.WriteLine(" ");
                    Console.WriteLine("Indicar tipo de paquete");
                    Console.WriteLine("[1] --> Paquete Nacional");
                    Console.WriteLine("[2] --> Paquete Internacional");
                    Console.WriteLine("[0] --> Regresar al Menu");

                    do
                    {
                        opcion = Console.ReadKey(true);
                    } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                    switch (opcion.KeyChar)
                    {
                        case '0':
                            Console.WriteLine(" ");
                            Console.WriteLine("Regresando al Menu... ");
                            Console.WriteLine(" ");
                            break;

                        case '1':

                            nroPaqueteNacional++;

                            Console.WriteLine("Introduzca el nombre del Nuevo Paquete Nacional");
                            nombrePaquete = Console.ReadLine();
                            Console.WriteLine("Introducir el valor del paquete en Pesos $");
                            Double.TryParse(Console.ReadLine(), out precio);
                            Console.WriteLine("Agregar el impuesto del paquete en %");
                            Double.TryParse(Console.ReadLine(), out impuestos);

                            Ingreso_data_restantes_de_paquetes();



                            #region Cuotas Nacionales
                            Console.WriteLine("Ingresar Tipo de Pago Ofrecido");
                            Console.WriteLine("[1] --> Contado efectivo");
                            Console.WriteLine("[2] --> financiado en Cuotas");
                            preguntaCuotas = Console.ReadLine().Trim();
                            if (preguntaCuotas == "1")
                                CuotasContadas = 1;
                            else if (preguntaCuotas == "2")
                            {
                                Console.WriteLine("[1] --> financiado en 3 Cuotas");
                                Console.WriteLine("[2] --> financiado en 6 Cuotas");
                                Console.WriteLine("[3] --> financiado en 12 Cuotas");
                                preguntaCuotas = Console.ReadLine().Trim();
                                if (preguntaCuotas == "1")
                                    CuotasContadas = 3;
                                else if (preguntaCuotas == "2")
                                    CuotasContadas = 6;
                                else if (preguntaCuotas == "3")
                                    CuotasContadas = 12;
                            }
                            #endregion
                            
                            Destinos_Paquetes();

                            Paquetes PaqueteNac = new Paquetes(nroPaqueteNacional, nombrePaquete, precio, impuestos, Cant_dias, Fecha_Viaje, vigencia, CuotasContadas, lugares);
                            Console.WriteLine("------DATOS INGRESADOS------");
                            PaqueteNac.MostrarPaquetesNac();
                            lPaquetesNac.Add(PaqueteNac);
                            Console.WriteLine(" ");
                            break;

                        case '2':

                            nroPaqueteInternacional++;

                            Console.WriteLine("Introduzca el nombre del Nuevo Paquete Internacional");
                            nombrePaquete = Console.ReadLine();
                            Console.WriteLine("Introducir el valor del paquete en Dolares $");
                            Double.TryParse(Console.ReadLine(), out precio);
                            Console.WriteLine("Agregar el impuesto fijo en dolares del paquete");
                            Double.TryParse(Console.ReadLine(), out impuestos);

                            Ingreso_data_restantes_de_paquetes();

                            #region Cuotas InterNacionales
                            Console.WriteLine("Ingresar Tipo de Pago Ofrecido");
                            Console.WriteLine("[1] --> Contado efectivo");
                            Console.WriteLine("[2] --> financiado en Cuotas");
                            preguntaCuotas = Console.ReadLine().Trim();
                            if (preguntaCuotas == "1")
                                CuotasContadas = 1;
                            else if (preguntaCuotas == "2")
                            {
                                Console.WriteLine("[1] --> financiado en 3 Cuotas");
                                Console.WriteLine("[2] --> financiado en 6 Cuotas");
                                preguntaCuotas = Console.ReadLine().Trim();
                                if (preguntaCuotas == "1")
                                    CuotasContadas = 3;
                                else if (preguntaCuotas == "2")
                                    CuotasContadas = 6;

                            }
                            #endregion

                            #region Datos Paquetes Internacionales
                            Console.WriteLine("¿Es necesario VISA?");
                            Console.WriteLine("[1] --> Si es necesario");
                            Console.WriteLine("[2] --> No es necesario");
                            do
                            {
                                opcion = Console.ReadKey(true);
                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                            if (opcion.KeyChar == '1')
                            {
                                visa = true;
                            }
                            else { visa = false; }

                            Console.WriteLine("Ingrese la Cotizacion del dolar");
                            Cotizacion_Dolar = Convert.ToDouble(Console.ReadLine());
                            #endregion

                          

                            Destinos_Paquetes();

                            Paquetes PaqueteInterNac = new Paquetes(nroPaqueteInternacional, nombrePaquete, precio, impuestos, Cant_dias, Fecha_Viaje, vigencia, CuotasContadas, Cotizacion_Dolar, visa, lugares);
                            lPaquetesNac.Add(PaqueteInterNac);
                            Console.WriteLine("------DATOS INGRESADOS------");
                            PaqueteInterNac.MostrarPaquetesInterNac();
                            Console.WriteLine(" ");
                            break;
                    }


                    break;
                #endregion

                //falta completar:
                //seleccion de paquetes internacionales
                //algun valor para definir que tipos de clientes y paquetes tenemos en la factura
                //quitar paquetes a un cliente

                #region caso_Asignacion_de_Paquetes
                case '3':
                    Console.WriteLine("*** ¡Asignasion Paquetes a Clientes! ***");
                    Console.WriteLine("[1] --> Asignar un Paquete a un Cliente");
                    Console.WriteLine("[2] --> Quitar un Paquete a un Cliente");
                    Console.WriteLine("[0] --> Regresar al Menu");
                    do
                    {
                        opcion = Console.ReadKey(true);
                    } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                    switch (opcion.KeyChar)
                    {

                        case '0':
                            Console.WriteLine(" ");
                            Console.WriteLine("Regresando al Menu... ");
                            Console.WriteLine(" ");
                            break;


                        case '1':
                            Console.WriteLine("*** Seleccione un tipo de Cliente ***");
                            Console.WriteLine("[1] --> Cliente Consumidor Final");
                            Console.WriteLine("[2] --> Cliente Corporativo");
                            do
                            {
                                opcion = Console.ReadKey(true);
                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                            if (opcion.KeyChar == '1')
                            {
                                selecccion = 1;
                                Buscando_Clientes(selecccion);
                            }
                            else
                            {
                                selecccion = 0;
                                Buscando_Clientes(selecccion);
                            }
                            if (c != null)
                            {
                                Console.WriteLine(" Usted Ingreso el Cliente: " + "\n ID: " + c.nroCliente + "\n Nombre:" + c.nombre + " " + c.apellido);
                                Console.WriteLine("Seleccione un Tipo de Paquete: ");
                                Console.WriteLine("[1] --> Paquete Nacional: ");
                                Console.WriteLine("[2] --> Paquete Internacional: ");
                                Console.WriteLine(" ");
                                do
                                {
                                    opcion = Console.ReadKey(true);
                                } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                                if (opcion.KeyChar == '1')
                                {
                                    orden = 0;
                                    while (orden <= nroPaqueteNacional)
                                    {
                                        orden++;
                                        try
                                        {
                                            selecccion = orden - 1;
                                            p = lPaquetesNac[selecccion];
                                            if (p.Vigencia == true)
                                            {
                                                Console.WriteLine("[" + orden + "] --> " + p.Nombre );
                                            }
                                            else 
                                            {
                                                Console.WriteLine("[" + orden + "] --> " + p.Nombre + "  NO VIGENTE ");
                                            }
                                            
                                        }
                                        catch (Exception) { }
                                    }
                                    
                                                                         
                                    
                                    Console.WriteLine("Seleccione un Paquete!");
                                    p = lPaquetesNac[ Convert.ToInt32(Console.ReadLine()) - 1];
                                    if (p.Vigencia==true) {
                                        nroFactura++;
                                        Factura NewFactura = new Factura(nroFactura, c, p, DateTime.Now);
                                        lFactura.Add(NewFactura);
                                        Console.WriteLine("------DATOS INGRESADOS------");
                                        NewFactura.mostrarDatos();
                                        Console.WriteLine(" ");
                                    }
                                    else 
                                    {
                                        Console.WriteLine("Lo sentimos, el paquete no se encuentra vigente ");
                                        Console.WriteLine("Si quiere que este paquete vuelva a encontrarse vigente dirigase a ajustes");
                                    }

                                }

                                else
                                {
                                    selecccion = 0;
                                    Buscando_Paquetes(selecccion);
                                }







                            }
                            else
                            {
                                Console.WriteLine("¡El Cliente que usted ingreso no existe! :(");
                            }










                            break;

                        case '2':


                            break;

                    }

                    break;
                #endregion

                //completado
                //revisar detalles y Bugs
                //IMPORTANTE:asignacion de lugares no funciona bien
                #region caso_Ajustes
                case '4':


                    Console.WriteLine("*** ¿Que desea Modificar? ***");
                    Console.WriteLine("[1] --> Clientes");
                    Console.WriteLine("[2] --> Paquetes");
                    Console.WriteLine("[0] --> Regresar al Menu");
                    Console.WriteLine(" ");
                    do
                    {
                        opcion = Console.ReadKey(true);
                    } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                    switch (opcion.KeyChar)
                    {
                        case '0':
                            Console.WriteLine(" ");
                            Console.WriteLine("Regresando al Menu... ");
                            Console.WriteLine(" ");
                            break;
                        #region Editando Clientes
                        case '1':
                            Console.WriteLine("***¡Editando un Cliente!*** ");
                            Console.WriteLine(" ");
                            Console.WriteLine("[1] --> Cliente Consumidor Final");
                            Console.WriteLine("[2] --> Cliente Corporativo");
                            Console.WriteLine("[0] --> Regresar al Menu PrincipaL");
                            do
                            {
                                opcion = Console.ReadKey(true);
                            } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                            switch (opcion.KeyChar)
                            {
                                case '0':
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Regresando al Menu... ");
                                    Console.WriteLine(" ");
                                    break;



                                case '1':

                                    selecccion = 1;
                                    Buscando_Clientes(selecccion);


                                    if (c != null)
                                    {
                                        loopBoolean = true;
                                        while (loopBoolean == true)
                                        {
                                            Console.WriteLine("EDITANDO CLIENTE: " + c.nombre + " " + c.apellido);
                                            Console.WriteLine("*******************");
                                            c.MostrarClientesConsFinal();
                                            Console.WriteLine("*******************");
                                            Console.WriteLine(" ");

                                            Ajustes_Seleccion_Clientes();
                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '7');

                                            Ajustes_Edicion_Clientes();

                                            c.MostrarClientesConsFinal();
                                            Console.WriteLine("¿Desea Contiunar Editando?");
                                            Console.WriteLine("[1] --> SI");
                                            Console.WriteLine("[2] --> NO");
                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                                            if (opcion.KeyChar == '2')
                                            {
                                                loopBoolean = false;
                                            }
                                            else { loopBoolean = true; }
                                        }
                                    }
                                    else { Console.WriteLine("el ID que ingreso no pertenece a un Cliente de Consumidor Final existente :("); }
                                    break;

                                case '2':

                                    selecccion = 0;
                                    Buscando_Clientes(selecccion);
                                    if (c != null)
                                    {
                                        loopBoolean = true;
                                        while (loopBoolean == true)
                                        {
                                            Console.WriteLine("EDITANDO CLIENTE: " + c.nombre + " " + c.apellido);
                                            Console.WriteLine("*******************");
                                            c.MostrarClientesConsFinal();
                                            Console.WriteLine("*******************");
                                            Console.WriteLine(" ");

                                            Ajustes_Seleccion_Clientes();
                                            #region Seleccion datos Corp
                                            Console.WriteLine("[8] --> razon social: " + c.razon_social);
                                            Console.WriteLine("[9] --> cuit: " + c.cuit);
                                            #endregion

                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '9');

                                            Ajustes_Edicion_Clientes();

                                            c.MostrarClientesCorp();

                                            Console.WriteLine("¿Desea Contiunar Editando?");
                                            Console.WriteLine("[1] --> SI");
                                            Console.WriteLine("[2] --> NO");
                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                                            if (opcion.KeyChar == '2')
                                            {
                                                loopBoolean = false;
                                            }
                                            else { loopBoolean = true; }
                                        }
                                    }
                                    else { Console.WriteLine("el ID que ingreso no pertenece a un Cliente Corporativo existente :("); }
                                    break;



                            }

                            break;
                        #endregion

                        #region Editando Paquetes
                        case '2':
                            Console.WriteLine("***¡Editando un Paquete!*** ");
                            Console.WriteLine(" ");
                            Console.WriteLine("[1] --> Paquete Nacional");
                            Console.WriteLine("[2] --> Paquete Internacional");
                            Console.WriteLine("[0] --> Regresar al Menu PrincipaL");
                            do
                            {
                                opcion = Console.ReadKey(true);
                            } while (opcion.KeyChar < '0' || opcion.KeyChar > '2');
                            switch (opcion.KeyChar)
                            {
                                case '0':
                                    Console.WriteLine(" ");
                                    Console.WriteLine("Regresando al Menu... ");
                                    Console.WriteLine(" ");
                                    break;



                                case '1':

                                    selecccion = 1;
                                    Buscando_Paquetes(selecccion);


                                    if (p != null)
                                    {
                                        loopBoolean = true;
                                        while (loopBoolean == true)
                                        {
                                            Console.WriteLine("EDITANDO PAQUETE NACIONAL: " + p.Nombre);
                                            Console.WriteLine("*******************");
                                            p.MostrarPaquetesNac();
                                            Console.WriteLine("*******************");
                                            Console.WriteLine(" ");

                                            Ajustes_Seleccion_Paquetes();
                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '8');

                                            Ajustes_Edicion_Paquetes();

                                            p.MostrarPaquetesNac();
                                            Console.WriteLine("¿Desea Contiunar Editando?");
                                            Console.WriteLine("[1] --> SI");
                                            Console.WriteLine("[2] --> NO");
                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                                            if (opcion.KeyChar == '2')
                                            {
                                                loopBoolean = false;
                                            }
                                            else { loopBoolean = true; }
                                        }
                                    }
                                    else { Console.WriteLine("el ID que ingreso no pertenece a un Paquete Nacional existente :("); }
                                    break;

                                case '2':

                                    selecccion = 0;
                                    Buscando_Paquetes(selecccion);
                                    if (p != null)
                                    {
                                        loopBoolean = true;
                                        while (loopBoolean == true)
                                        {
                                            selecccion = Convert.ToInt32("PAQUETE INTERNACIONAL");
                                            Console.WriteLine("EDITANDO PAQUETE INTERNACIONAL: " + p.Nombre);
                                            Console.WriteLine("*******************");
                                            p.MostrarPaquetesInterNac();
                                            Console.WriteLine("*******************");
                                            Console.WriteLine(" ");

                                            Ajustes_Seleccion_Paquetes();
                                            #region Seleccion datos Corp
                                            Console.WriteLine("[9] --> Cotizacion del DOLAR: " + p.Cotizacion_Dolar);
                                            Console.WriteLine("[0] --> VISA VIGENTE: " + p.visa);
                                            #endregion

                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '0' || opcion.KeyChar > '9');

                                            Ajustes_Edicion_Paquetes();

                                            p.MostrarPaquetesInterNac();

                                            Console.WriteLine("¿Desea Contiunar Editando?");
                                            Console.WriteLine("[1] --> SI");
                                            Console.WriteLine("[2] --> NO");
                                            do
                                            {
                                                opcion = Console.ReadKey(true);
                                            } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                                            if (opcion.KeyChar == '2')
                                            {
                                                loopBoolean = false;
                                            }
                                            else { loopBoolean = true; }
                                        }
                                    }
                                    else { Console.WriteLine("el ID que ingreso no pertenece a un Paquete Internacional existente :("); }
                                    break;



                            }

                            break;
                    }

                    #endregion
                    break;


                #endregion

                //falta completar asignacion de paquetes antes de hacer
                #region caso_Factura
                case '5':
                    Console.WriteLine("*** ¡Ver Facturas de Clientes! ***");
                    break;
                    #endregion

            }

        } while ((int)opcion.KeyChar != 27);

        void Introduccion()
        {
            Console.WriteLine(" ");
            Console.WriteLine("*****¡Bienvenidos a Epico-Aerolineas! ******");
            Console.WriteLine(" ");
            Console.WriteLine("1 - Agregar Clientes");
            Console.WriteLine("2 - Agregar Paquetes");
            Console.WriteLine("3 - Asignar/Quitar Paquetes a un Cliente");
            Console.WriteLine("4 - Ajustes");
            Console.WriteLine("5 - Ver Factura");
            Console.WriteLine("ESC - Salir");
            Console.WriteLine(" ");
        }

        void Ingreso_data_clientes()
        {
            Console.WriteLine("Indique su Nombre ");
            nombreCliente = Console.ReadLine();
            Console.WriteLine("Indique su Apellido ");
            apellido = Console.ReadLine();

            Console.WriteLine(" Ingrese el DNI de su Cliente ");
            int.TryParse(Console.ReadLine(), out DNI);
            c = lclientes_ConsFinal.Find(x => x.DNI == DNI);


            Console.WriteLine("Indique su Telefono ");
            telefono = Console.ReadLine();
            Console.WriteLine("Indique su Nacionalidad");
            nacionalidad = Console.ReadLine();
            Console.WriteLine("Indique su Provincia ");
            provincia = Console.ReadLine();
            Console.WriteLine("Indique su direccion");
            direccion = Console.ReadLine();
        }

        void Ingreso_data_restantes_de_paquetes()
        {

            Console.WriteLine("Ingrese la duracion del paquete en cantidad de dias");
            Int32.TryParse(Console.ReadLine(), out Cant_dias);
            //agregar un excepcion loop averiguar que no ponga fechas antes de hoy
            Console.WriteLine("Indique la fecha del viaje");
            Console.WriteLine("En formato DD/MM/AA");
            DateTime.TryParse(Console.ReadLine(), out Fecha_Viaje);
            Console.WriteLine("Indique la Vigencia de Paquete");
            Console.WriteLine("[1] --> Paquete Vigente");
            Console.WriteLine("[2] --> Paquete No Vigente");
            string pregunta = Console.ReadLine().Trim();
            if (pregunta == "1")
                vigencia = true;
            if (pregunta == "2")
                vigencia = false;



        }

        void Ajustes_Seleccion_Clientes()
        {
            Console.WriteLine("**¿Que desea Editar?**");
            Console.WriteLine("[1] --> nombre: " + c.nombre);
            Console.WriteLine("[2] --> apellido: " + c.apellido);
            Console.WriteLine("[3] --> DNI: " + c.DNI);
            Console.WriteLine("[4] --> telefono: " + c.telefono);
            Console.WriteLine("[5] --> nacionalidad: " + c.nacionalidad);
            Console.WriteLine("[6] --> provincia: " + c.provincia);
            Console.WriteLine("[7] --> direccion: " + c.direccion);
        }

        void Ajustes_Seleccion_Paquetes()
        {
            Console.WriteLine("**¿Que desea Editar?**");
            Console.WriteLine("[1] --> nombre: " + p.Nombre);
            Console.WriteLine("[2] --> precio: " + p.precio);
            Console.WriteLine("[3] --> impuesto: " + p.impuestos);
            Console.WriteLine("[4] --> cantidad de dias de viaje: " + p.Cant_dias);
            Console.WriteLine("[5] --> Fecha de Viaje: " + p.Cant_dias);
            Console.WriteLine("[6] --> cuotas Contadas: " + p.CuotasContadas);
            Console.WriteLine("[7] --> Destino: " + p.Lugares);
            Console.WriteLine("++++++++++++++++++++++++++++++++");
            Console.WriteLine("[8] --> VIGENCIA: " + p.Vigencia);
            Console.WriteLine("++++++++++++++++++++++++++++++++");
        }

        void Ajustes_Edicion_Clientes()
        {

            switch (opcion.KeyChar)
            {
                case '1':
                    Console.WriteLine("Indique su Nombre ");
                    c.nombre = Console.ReadLine();
                    break;

                case '2':
                    Console.WriteLine("Indique su Apellido ");
                    c.apellido = Console.ReadLine();
                    break;

                case '3':
                    Console.WriteLine("Indique su DNI");
                    int.TryParse(Console.ReadLine(), out c.DNI);
                    break;

                case '4':
                    Console.WriteLine("Indique su Telefono ");
                    c.telefono = Console.ReadLine();
                    break;

                case '5':
                    Console.WriteLine("Indique su Nacionalidad");
                    c.nacionalidad = Console.ReadLine();
                    break;

                case '6':
                    Console.WriteLine("Indique su Provincia ");
                    c.provincia = Console.ReadLine();
                    break;

                case '7':
                    Console.WriteLine("Indique su direccion");
                    c.direccion = Console.ReadLine();
                    break;

                case '8':
                    Console.WriteLine("Ingrese su razon social ");
                    c.razon_social = Console.ReadLine();
                    break;

                case '9':
                    Console.WriteLine("Ingrese su CUIT");
                    c.cuit = Console.ReadLine();
                    break;
            }
        }

        void Ajustes_Edicion_Paquetes()
        {

            switch (opcion.KeyChar)
            {
                case '1':
                    Console.WriteLine("Indique el nombre del Paquete ");
                    p.Nombre = Console.ReadLine();
                    break;

                case '2':
                    if (selecccion == Convert.ToInt32("PAQUETE INTERNACIONAL"))
                    { Console.WriteLine("Introducir el valor del paquete en Dolares $"); }

                    else { Console.WriteLine("Introducir el valor del paquete en Pesos $"); }

                    Double.TryParse(Console.ReadLine(), out p.precio);
                    break;

                case '3':
                    if (selecccion == Convert.ToInt32("PAQUETE INTERNACIONAL"))
                    { Console.WriteLine("Agregar el impuesto fijo en dolares del paquete"); }

                    else { Console.WriteLine("Agregar el impuesto del paquete en %"); }

                    Double.TryParse(Console.ReadLine(), out p.impuestos);
                    break;

                case '4':
                    Console.WriteLine("Ingrese la duracion del paquete en cantidad de dias");
                    Int32.TryParse(Console.ReadLine(), out p.Cant_dias);
                    break;

                case '5':
                    Console.WriteLine("Indique la fecha del viaje");
                    Console.WriteLine("En formato DD/MM/AA");
                    DateTime.TryParse(Console.ReadLine(), out p.Fecha_Viaje);
                    break;

                case '6':
                    if (selecccion == Convert.ToInt32("PAQUETE INTERNACIONAL"))
                    {
                        #region Cuotas InterNacionales
                        Console.WriteLine("Ingresar Tipo de Pago Ofrecido");
                        Console.WriteLine("[1] --> Contado efectivo");
                        Console.WriteLine("[2] --> financiado en Cuotas");
                        preguntaCuotas = Console.ReadLine().Trim();
                        if (preguntaCuotas == "1")
                            CuotasContadas = 1;
                        else if (preguntaCuotas == "2")
                        {
                            Console.WriteLine("[1] --> financiado en 3 Cuotas");
                            Console.WriteLine("[2] --> financiado en 6 Cuotas");
                            preguntaCuotas = Console.ReadLine().Trim();
                            if (preguntaCuotas == "1")
                                CuotasContadas = 3;
                            else if (preguntaCuotas == "2")
                                CuotasContadas = 6;

                        }
                        #endregion
                    }
                    else
                    {
                        #region Cuotas Nacionales
                        Console.WriteLine("Ingresar Tipo de Pago Ofrecido");
                        Console.WriteLine("[1] --> Contado efectivo");
                        Console.WriteLine("[2] --> financiado en Cuotas");
                        preguntaCuotas = Console.ReadLine().Trim();
                        if (preguntaCuotas == "1")
                            p.CuotasContadas = 1;
                        else if (preguntaCuotas == "2")
                        {
                            Console.WriteLine("[1] --> financiado en 3 Cuotas");
                            Console.WriteLine("[2] --> financiado en 6 Cuotas");
                            Console.WriteLine("[3] --> financiado en 12 Cuotas");
                            preguntaCuotas = Console.ReadLine().Trim();
                            if (preguntaCuotas == "1")
                                p.CuotasContadas = 3;
                            else if (preguntaCuotas == "2")
                                p.CuotasContadas = 6;
                            else if (preguntaCuotas == "3")
                                p.CuotasContadas = 12;
                        }
                        #endregion
                    }
                    break;

                case '7':
                    
                    Destinos_Paquetes();
                    break;

                case '8':
                    Console.WriteLine("Indique la Vigencia de Paquete");
                    Console.WriteLine("[1] --> Paquete Vigente");
                    Console.WriteLine("[2] --> Paquete No Vigente");
                    string pregunta = Console.ReadLine().Trim();
                    if (pregunta == "1")
                        vigencia = true;
                    if (pregunta == "2")
                        vigencia = false;
                    break;

                case '9':
                    Console.WriteLine("Ingrese la Cotizacion del dolar");
                    Cotizacion_Dolar = Convert.ToDouble(Console.ReadLine());
                    break;

                case '0':
                    Console.WriteLine("¿Es necesario VISA?");
                    Console.WriteLine("[1] --> Si es necesario");
                    Console.WriteLine("[2] --> No es necesario");
                    do
                    {
                        opcion = Console.ReadKey(true);
                    } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                    if (opcion.KeyChar == '1')
                    {
                        p.visa = true;
                    }
                    else { p.visa = false; }

                    break;


            }
        }

        void Buscando_Clientes(int seleccion)
        {

            if (selecccion == 1)
            {

                Console.WriteLine(" Ingrese el ID de su Cliente Consumidor Final ");
                int.TryParse(Console.ReadLine(), out nroClienteConsFinal);
                c = lclientes_ConsFinal.Find(x => x.nroCliente == nroClienteConsFinal);
            }
            else
            {
                Console.WriteLine(" Ingrese el ID de su Cliente Corporativo ");
                int.TryParse(Console.ReadLine(), out nroClienteCorp);
                c = lclientes_Corporativos.Find(x => x.nroCliente == nroClienteCorp);

            }

        }

        void Buscando_Paquetes(int seleccion)
        {
            if (seleccion == 1)
            {
                Console.WriteLine(" Ingrese el ID de su Paquete Nacional");
                int.TryParse(Console.ReadLine(), out nroPaqueteNacional);
                p = lPaquetesNac.Find(x => x.nroPaquete == nroPaqueteNacional);
            }
            else
            {
                Console.WriteLine(" Ingrese el ID de su Paquete internacional");
                int.TryParse(Console.ReadLine(), out nroPaqueteInternacional);
                p = lPaquetesInterNac.Find(x => x.nroPaquete == nroPaqueteInternacional);
            }

        }

        void Destinos_Paquetes()
        {
            List<string> Destinos = new List<string>();
            int i = 10;
            loopBoolean = true;

            #region Destinos por defecto
            Destinos.Add("Argentina");
            Destinos.Add("Brasil");
            Destinos.Add("USA");
            Destinos.Add("Peru");
            Destinos.Add("Portugal");
            Destinos.Add("Chile");
            Destinos.Add("Japon");
            Destinos.Add("Uruguay");
            Destinos.Add("Australia");
            Destinos.Add("China");
            #endregion

            while (loopBoolean == true)
            {
                LugarInt = 0;
                orden = 0;

                Console.WriteLine("¡Ingrese su Destino!");
                foreach (string Pais in Destinos)
                {
                    if (orden < i)
                    {
                        orden++;
                    }

                    Console.WriteLine(" [" + orden + "]" + " --> " + Pais);
                }

                Console.WriteLine("¿Que desea Hacer?");
                Console.WriteLine("[1] --> Seleccionar un Destino");
                Console.WriteLine("[2] --> Agregar un destino nuevo");
                Console.WriteLine(" ");

                do
                {
                    opcion = Console.ReadKey(true);
                } while (opcion.KeyChar < '1' || opcion.KeyChar > '2');
                switch (opcion.KeyChar)
                {
                    case '1':
                        loopBoolean = false;
                        Console.WriteLine("Seleccione su Destino ingresando el numero a su izquierda");
                        LugarInt = Convert.ToInt32(Console.ReadLine()) - 1;
                      
                            lugares = Destinos[LugarInt];
                        
                        
                        


                        Console.WriteLine("usted ingreso el destino:" + lugares);
                        break;

                    case '2':
                        Console.WriteLine("Ingrese el nombre de su destino nuevo");
                        string PaisNuevo = Console.ReadLine();
                        string D = Destinos.Find(x => x == PaisNuevo);
                        if (D == null)
                        {
                            Destinos.Add(PaisNuevo);
                            i++;
                        }
                        else { Console.WriteLine("Ese Pais ya esta incluida en la lista de opciones!"); }
                        break;


                }

            }

        }
    }
}

