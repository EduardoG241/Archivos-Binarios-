using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Archivos_Binarios
{
    class Program
    {
        class ArchivosBinariosEmpleados
        {
            BinaryWriter bw = null;
            BinaryReader br = null;

            string nombre, direccion;
            long telefono;
            int numEmp, diasTrabajados;
            float salarioDiario;

            public void CrearArchivo(String Archivo)
            {
                char resp;

                try
                {
                    bw = new BinaryWriter(new FileStream(Archivo, FileMode.Create, FileAccess.Write));

                    do
                    {
                        Console.Clear();
                        Console.Write("Numero del empleado: ");
                        numEmp = Int32.Parse(Console.ReadLine());
                        Console.Write("Nombre del empleado: ");
                        nombre = Console.ReadLine();
                        Console.Write("Direccion del empleado: ");
                        direccion = Console.ReadLine();
                        Console.Write("Telefono del empleado: ");
                        telefono = Int64.Parse(Console.ReadLine());
                        Console.Write("Dias Trabajados del empleado: ");
                        diasTrabajados = Int32.Parse(Console.ReadLine());
                        Console.Write("Salario diario del empleado: ");
                        salarioDiario = Single.Parse(Console.ReadLine());

                        bw.Write(numEmp);
                        bw.Write(nombre);
                        bw.Write(direccion);
                        bw.Write(telefono);
                        bw.Write(diasTrabajados);
                        bw.Write(salarioDiario);

                        Console.Write("\n\nDeseas almacenar otro registro (s/n)?");
                        resp = char.Parse(Console.ReadLine());
                    } while ((resp == 's') || (resp == 'S'));
                }

                catch (IOException e)
                {
                    Console.WriteLine("\nError : " + e.Message);
                    Console.WriteLine("\nRuta : " + e.StackTrace);
                }

                finally
                {
                    if (bw != null) bw.Close();
                    Console.Write("\nPresione <enter> para terminar la escritura de datos y regresar al menu.");
                    Console.ReadKey();
                }
            }

            public void MostrarArchivo(String Archivo)
            {
                try
                {
                    if (File.Exists(Archivo))
                    {
                        br = new BinaryReader(new FileStream(Archivo, FileMode.Open, FileAccess.Read));

                        Console.Clear();

                        do
                        {
                            numEmp = br.ReadInt32();
                            nombre = br.ReadString();
                            direccion = br.ReadString();
                            telefono = br.ReadInt64();
                            diasTrabajados = br.ReadInt32();
                            salarioDiario = br.ReadSingle();

                            Console.WriteLine("Numero del empleado : " + numEmp);
                            Console.WriteLine("Nombre del empleado : " + nombre);
                            Console.WriteLine("Direccion del empleado : " + direccion);
                            Console.WriteLine("Telefono del empleado : " + telefono);
                            Console.WriteLine("Dias trabajados por el empleado : " + diasTrabajados);
                            Console.WriteLine("Salario diario del empleado : {0:C}" + salarioDiario);
                            Console.WriteLine("SUELDO TOTAL del empleado : {0:C}" + (diasTrabajados * salarioDiario));
                            Console.WriteLine("\n");
                        } while (true);
                    }

                    else
                    {
                        Console.Clear();
                        Console.WriteLine("\n\nEl archivo " + Archivo + " No existe en el disco!!");
                        Console.WriteLine("\nPresione <enter> para continuar...");
                        Console.ReadKey();
                    }
                }
                catch
                {
                    Console.WriteLine("\n\nFin del listado de empleados");
                    Console.Write("\nPresione <enter> para continuar...");
                    Console.ReadKey();
                }

                finally
                {
                    if (br != null )br.Close();
                    Console.Write("\nPresione <enter> para terminar la Escritura de datos y regresar al menu");
                    Console.ReadKey();
                }
            }
        }
        static void Main(string[] args)
        {
            string Arch = null;
            int opcion;

            ArchivosBinariosEmpleados ABE = new ArchivosBinariosEmpleados();

            do
            {
                Console.Clear();

                Console.WriteLine("\nARCHIVO BINARIO EMPLEADOS");
                Console.WriteLine("1.- Creacion de un archivo.");
                Console.WriteLine("2.- Lectura de un archivo.");
                Console.WriteLine("3.- Salida del programa.");
                Console.Write("\nQue opcion deseas: ");
                opcion = Int16.Parse(Console.ReadLine());

                switch (opcion)
                {
                    case 1:
                        try
                        {
                            Console.Write("\nAlimenta el Nombre del Archivo a Crear: "); Arch = Console.ReadLine();

                            char resp = 's';
                            if (File.Exists(Arch))
                            {
                                Console.Write("\nEl Archivo Existe!!, Deseas Sobreescribirlo(s / n) ? ");
                                resp = Char.Parse(Console.ReadLine());
                            }
                            if ((resp == 's') || (resp == 'S'))
                                ABE.CrearArchivo(Arch);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError : " + e.Message);
                            Console.WriteLine("\nRuta : " + e.StackTrace);
                        }
                        break;
                    case 2:

                        try
                        {

                            Console.Write("\nAlimenta el Nombre del Archivo que deseas Leer: ");
                            Arch = Console.ReadLine();
                            ABE.MostrarArchivo(Arch);
                        }
                        catch (IOException e)
                        {
                            Console.WriteLine("\nError : " + e.Message);
                            Console.WriteLine("\nRuta : " + e.StackTrace);
                        }
                        break;
                    case 3:
                        Console.Write("\nPresione <enter> para Salir del Programa.");


                        Console.ReadKey();
                        break;
                    default:
                        Console.Write("\nEsa Opción No Existe!!, Presione < enter > para Continuar...");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != 3);
        }
    }
}
    

