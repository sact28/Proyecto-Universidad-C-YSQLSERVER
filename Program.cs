using EjercicioCompletoArchivos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
/// <summary>
/// Fecha: 06/04/2024
/// Objetivo: Creacion de menu con funcionalidad para empleado
/// Creado por: Santiago Benjamin Canel Escobar 
/// Carnet: 0900-22-1504
/// Seccion : B
/// </summa/>
namespace Clase7EjercicioArchivoEmpleado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleKeyInfo lObjOpcion;
            Program lobjProceso = new Program();

            do
            {
                lobjProceso.SubMenuPrincipal();
                lObjOpcion = Console.ReadKey();

                switch (lObjOpcion.Key)
                {
                    case ConsoleKey.NumPad1:
                        //lobjProceso.SubAgregarPuesto();
                        //lobjProceso.SubAgregarPuestoBinario();
                        lobjProceso.SubAgregarPuestoSQL();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D1:
                        //lobjProceso.SubAgregarPuesto();
                        //lobjProceso.SubAgregarPuestoBinario();
                        lobjProceso.SubAgregarPuestoSQL();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad2:
                        //lobjProceso.SubAgregarEmpleado();
                        //lobjProceso.SubAgregarEmpleadoBinario();
                        lobjProceso.SubAgregarEmpleadoSQL();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D2:
                        //lobjProceso.SubAgregarEmpleado();
                        //lobjProceso.SubAgregarEmpleadoBinario();
                        lobjProceso.SubAgregarEmpleadoSQL();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad3:
                        //lobjProceso.SubListarInformacionEmpleado();
                        lobjProceso.SubListarInformacionEmpleadoBinario();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D3:
                        //lobjProceso.SubListarInformacionEmpleado();
                        lobjProceso.SubListarInformacionEmpleadoBinario();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad4:
                        lobjProceso.subProcesoAumentoSalario();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D4:
                        lobjProceso.subProcesoAumentoSalario();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad5:
                        lobjProceso.SubModificarEmpleado();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D5:
                        lobjProceso.SubModificarEmpleado();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.NumPad6:
                        lobjProceso.SubEliminarEmpleado();
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D6:
                        lobjProceso.SubEliminarEmpleado();
                        Console.ReadKey();
                        break;
                }

            } while (lObjOpcion.Key != ConsoleKey.Escape);

        }
        /// <summary>
        /// este metodo se utiliza para lo que corresponde a las opciones del menu principal
        /// </summary>
        public void SubMenuPrincipal()
        {
            Console.Clear();
            Console.Title = "CLASE NO 7 EJERCICIO DE MENUS Y ARCHIVOS EMPLEADO";
            string StrTitulo = "CLASE NO.7 EJERCICIO DE MENUS Y ARCHIVOS EMPLEADO";
            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop);
            Console.WriteLine(StrTitulo);
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(25, 2); Console.WriteLine("CURSO: PROGRAMACIÓN 1 ");
            Console.SetCursorPosition(25, 3); Console.WriteLine("NOMBRE: SANTIAGO CANEL");
            Console.SetCursorPosition(25, 4); Console.WriteLine("CARNET: 0900-22-1504");
            Console.SetCursorPosition(25, 5); Console.WriteLine("SECCION: B");
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            StrTitulo = "MENU PRINCIPAL";
            Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop);
            Console.WriteLine(StrTitulo);
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.SetCursorPosition(30, 09); Console.WriteLine("1. Alta Puesto");
            Console.SetCursorPosition(30, 10); Console.WriteLine("2. Alta Empleado");
            Console.SetCursorPosition(30, 11); Console.WriteLine("3. Ver Planilla de Salarios");
            Console.SetCursorPosition(30, 12); Console.WriteLine("4. Incremento 5% al Salario");
            Console.SetCursorPosition(30, 13); Console.WriteLine("5. Modificar datos de empleado");
            Console.SetCursorPosition(30, 14); Console.WriteLine("6. Eliminar un empleado");
            Console.SetCursorPosition(30, 15); Console.WriteLine("7. Salida [ESC]");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(30, 17); Console.WriteLine("ELIJA EL NUMERO DE OPCION [     ]");
            Console.WriteLine(string.Concat(Enumerable.Repeat("=", 115)));
            Console.SetCursorPosition(61, 17);
        }
        /// <summary>
        /// Funcion para obtener el ultimo Id de puesto de empleado.
        /// </summary>
        /// <param name="pStrPath">valor tipo String del path donde debe buscar la informacion esto incluyendo el nombre del archivo.</param>
        /// <returns></returns>
        public int fncValidaUltimoID(string pStrPath)
        {
            int lIntResultado = 0;
            try
            {
                if (File.Exists(pStrPath))
                {
                    using (var lObjArchvo = new StreamReader(pStrPath))
                    {
                        string lStrCadena = string.Empty;
                        while ((lStrCadena = lObjArchvo.ReadLine()) != null)
                        {
                            String[] lStrConjuntoDatos = lStrCadena.Split('|');
                            lIntResultado = int.Parse(lStrConjuntoDatos[0]);
                        }
                        lIntResultado += 1;
                    }
                }
                else
                {
                    lIntResultado = 1;
                }

            }
            catch (IOException lStrError)
            {
                Console.WriteLine(lStrError.Message);

            }
            return lIntResultado;
        }
        /// <summary>
        /// Funcion para obtener el ultimo Id de puesto de empleado.
        /// </summary>
        /// <param name="pStrPath">valor tipo String del path donde debe buscar la informacion esto incluyendo el nombre del archivo.</param>
        /// <returns></returns>
        public int fncValidaUltimoIDBinario(string pStrPath)
        {
            int lIntResultado = 0;
            BinaryReader lObjLeer;
            try
            {
                if (File.Exists(pStrPath))
                {
                    FileStream lObjArchivo = new FileStream(pStrPath, FileMode.Open, FileAccess.Read);
                    lObjLeer = new BinaryReader(lObjArchivo);
                    while (lObjArchivo.Position != lObjArchivo.Length)
                    {
                        lIntResultado = lObjLeer.ReadInt32();
                        lObjLeer.ReadString();
                        lObjLeer.ReadDouble();

                    }
                    lIntResultado += 1;
                }
                else
                {
                    lIntResultado = 1;
                }

            }
            catch (IOException lStrError)
            {
                Console.WriteLine(lStrError.Message);

            }
            return lIntResultado;
        }
        /// <summary>
        /// Esta funcion se utiliza para poder validar el Id del puesto que se esta ingresando en el mantenimiento de alta de empleado.
        /// </summary>
        /// <param name="pStrPath">es un valor String donde se traslada el path del archivo que tiene la informacion.</param>
        /// <param name="pIntPuesto">es una valor entero que corresponde al Id del puesto ingreso por el usuario en el mantenimiento alta de empleado.</param>
        /// <returns></returns>
        public Boolean fncValidaID(string pStrPath, int pIntPuesto)
        {
            Boolean lBlnResultado = false;
            try
            {
                if (File.Exists(pStrPath))
                {
                    using (var lObjArchvo = new StreamReader(pStrPath))
                    {
                        string lStrCadena = string.Empty;
                        while ((lStrCadena = lObjArchvo.ReadLine()) != null)
                        {
                            String[] lStrConjuntoDatos = lStrCadena.Split('|');
                            if (pIntPuesto == int.Parse(lStrConjuntoDatos[0]))
                            {
                                lBlnResultado = true;
                            }
                        }
                    }
                }
                else
                {
                    lBlnResultado = false;
                }

            }
            catch (IOException lStrError)
            {
                Console.WriteLine(lStrError.Message);

            }
            return lBlnResultado;
        }
        /// <summary>
        /// Esta funcion se utiliza para poder validar el Id del puesto que se esta ingresando en el mantenimiento de alta de empleado.
        /// </summary>
        /// <param name="pStrPath">es un valor String donde se traslada el path del archivo que tiene la informacion.</param>
        /// <param name="pIntPuesto">es una valor entero que corresponde al Id del puesto ingreso por el usuario en el mantenimiento alta de empleado.</param>
        /// <returns></returns>
        public Boolean fncValidaIDBinario(string pStrPath, int pIntPuesto)
        {
            Boolean lBlnResultado = false;
            BinaryReader lObjLeer;
            int lIntPuestoArchivo = 0;
            try
            {
                if (File.Exists(pStrPath))
                {
                    FileStream lObjArchivo = new FileStream(pStrPath, FileMode.Open, FileAccess.Read);
                    lObjLeer = new BinaryReader(lObjArchivo);
                    while (lObjArchivo.Position != lObjArchivo.Length)
                    {
                        lIntPuestoArchivo = lObjLeer.ReadInt32();
                        lObjLeer.ReadString();
                        lObjLeer.ReadDouble();
                        if (pIntPuesto == lIntPuestoArchivo)
                        {
                            lBlnResultado = true;
                        }
                    }
                }
                else
                {
                    lBlnResultado = false;
                }

            }
            catch (IOException lStrError)
            {
                Console.WriteLine(lStrError.Message);

            }
            return lBlnResultado;
        }
        /// <summary>
        /// Metodo para darle de alta a un puesto.
        /// </summary>
        public void SubAgregarPuesto()
        {
            string lStrInformacion = string.Empty;
            int lIntIdPuesto = 0;
            Boolean lBlnContinuarIngresando = true;
            String lStrDeseaContinuar = String.Empty;
            string lStrNombre = string.Empty;
            double lDblSueldo = 0;
            string lStrSeparador = "|";
            Console.Clear();
            try
            {
                lIntIdPuesto = fncValidaUltimoID("C://UMG//PUESTOSB.TXT");
                while (lBlnContinuarIngresando == true)
                {
                    if (lIntIdPuesto != 0)
                    {
                        Console.SetCursorPosition(0, 3);
                        string lStrTitulo = "INFORMACION A COMPLETAR DE PUESTOS";
                        Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                        Console.WriteLine(lStrTitulo);
                        Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 6); Console.WriteLine("DATOS GENERALES");
                        Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 8); Console.WriteLine("ID PUESTO       :            [                                          ]");
                        Console.SetCursorPosition(35, 9); Console.WriteLine("PUESTO          :            [                                          ]");
                        Console.SetCursorPosition(25, 10); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 11); Console.WriteLine("DATOS ESPECIFICOS");
                        Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 13); Console.WriteLine("SALARIO        :            [                                          ]");
                        Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntIdPuesto).PadLeft(4, '0'));
                        Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                        Console.SetCursorPosition(70, 13); lDblSueldo = double.Parse(Console.ReadLine());
                        Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                        Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();
                        StreamWriter lobjArchivo = new StreamWriter(new FileStream("c:/umg/puestosb.txt", FileMode.Append));
                        lobjArchivo.Write(Convert.ToString(lIntIdPuesto).PadLeft(4, '0')); lobjArchivo.Write(lStrSeparador);
                        lobjArchivo.Write(lStrNombre.PadRight(30, ' ')); lobjArchivo.Write(lStrSeparador);
                        lobjArchivo.WriteLine(Convert.ToString(lDblSueldo).PadLeft(10, '0'));
                        if (lStrDeseaContinuar.ToUpper() == "N")
                        {
                            lBlnContinuarIngresando = false;
                        }
                        lIntIdPuesto += 1;
                        lobjArchivo.Close();
                    }
                    Console.Write("            Presione una tecla para continuar...");
                }

            }
            catch (Exception lStrError)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO DE PUESTO, DETALLE ERROR ->" + lStrError.Message);
            }
        }
        /// <summary>
        /// Este metodo se utiliza para poder dar alta a un puesto en la base de datos SQL llamada EmpleaadosB
        /// </summary>
        public void SubAgregarPuestoSQL()
        {
            clsPuestoEN lObjPuesto = new clsPuestoEN();
            string lStrInformacion = string.Empty;
            Boolean lBlnContinuarIngresando = true;
            String lStrDeseaContinuar = String.Empty;
            Console.Clear();
            try
            {
                clsConexionSQL lObjProceso = new clsConexionSQL();
                lObjPuesto.lIdPuesto = lObjProceso.FncConsultar();
                while (lBlnContinuarIngresando == true)
                {
                    if (lObjPuesto.lIdPuesto != 0)
                    {
                        Console.SetCursorPosition(0, 3);
                        string lStrTitulo = "INFORMACION A COMPLETAR DE PUESTOS";
                        Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                        Console.WriteLine(lStrTitulo);
                        Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 6); Console.WriteLine("DATOS GENERALES");
                        Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 8); Console.WriteLine("ID PUESTO       :            [                                          ]");
                        Console.SetCursorPosition(35, 9); Console.WriteLine("PUESTO          :            [                                          ]");
                        Console.SetCursorPosition(25, 10); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 11); Console.WriteLine("DATOS ESPECIFICOS");
                        Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 13); Console.WriteLine("SALARIO        :            [                                          ]");
                        Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lObjPuesto.lIdPuesto).PadLeft(4, '0'));
                        Console.SetCursorPosition(70, 9); lObjPuesto.lStrNombrePuesto = Console.ReadLine();
                        Console.SetCursorPosition(70, 13); lObjPuesto.lDbSalario= double.Parse(Console.ReadLine());
                        Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                        Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();
                        lObjProceso.FcnlAgregar(lObjPuesto);
                        if (lStrDeseaContinuar.ToUpper() == "N")
                        {
                            lBlnContinuarIngresando = false;
                        }
                        lObjPuesto.lIdPuesto += 1;
                        
                    }
                    Console.Write("            Presione una tecla para continuar...");
                }

            }
            catch (Exception lStrError)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO DE PUESTO, DETALLE ERROR ->" + lStrError.Message);
            }
        }
        /// <summary>
        /// Metodo para darle de alta a un puesto.
        /// </summary>
        public void SubAgregarPuestoBinario()
        {
            string lStrInformacion = string.Empty;
            int lIntIdPuesto = 0;
            Boolean lBlnContinuarIngresando = true;
            String lStrDeseaContinuar = String.Empty;
            string lStrNombre = string.Empty;
            double lDblSueldo = 0;
            BinaryWriter lObjEscribir;
            Console.Clear();
            try
            {
                lIntIdPuesto = fncValidaUltimoIDBinario("C://UMG//PUESTOSBiB.TXT");
                using (FileStream lObjArchivo = new FileStream("C:/umg/puestosBiB.txt", FileMode.Append))
                {
                    while (lBlnContinuarIngresando == true)
                    {
                        if (lIntIdPuesto != 0)
                        {
                            Console.SetCursorPosition(0, 3);
                            string lStrTitulo = "INFORMACION A COMPLETAR DE PUESTOS";
                            Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                            Console.WriteLine(lStrTitulo);
                            Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(50, 6); Console.WriteLine("DATOS GENERALES");
                            Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 8); Console.WriteLine("ID PUESTO       :            [                                          ]");
                            Console.SetCursorPosition(35, 9); Console.WriteLine("PUESTO          :            [                                          ]");
                            Console.SetCursorPosition(25, 10); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(50, 11); Console.WriteLine("DATOS ESPECIFICOS");
                            Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 13); Console.WriteLine("SALARIO        :            [                                          ]");
                            Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntIdPuesto).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 13); lDblSueldo = double.Parse(Console.ReadLine());
                            Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                            Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();

                            lObjEscribir = new BinaryWriter(lObjArchivo);
                            lObjEscribir.Write(lIntIdPuesto);
                            lObjEscribir.Write(lStrNombre);
                            lObjEscribir.Write(lDblSueldo);
                            if (lStrDeseaContinuar.ToUpper() == "N")
                            {
                                lBlnContinuarIngresando = false;
                                lObjEscribir.Close();
                            }
                            lIntIdPuesto += 1;

                        }
                        Console.Write("            Presione una tecla para continuar...");
                    }
                }


            }
            catch (Exception lStrError)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO DE PUESTO, DETALLE ERROR ->" + lStrError.Message);
            }
        }
        public struct PuestoTrabajo
        {
            public int lIntIdPuesto;
            public string lStrNombrePuesto;
            public double lDblSueldo;
        }
        public List<PuestoTrabajo> fncListaPuestos(string pStrPath)
        {
            var lObjResultado = new List<PuestoTrabajo>();
            PuestoTrabajo lObjPuesto;
            try
            {
                if (File.Exists(pStrPath))
                {
                    using (var lObjArchvo = new StreamReader(pStrPath))
                    {
                        string lStrCadena = string.Empty;
                        while ((lStrCadena = lObjArchvo.ReadLine()) != null)
                        {
                            String[] lStrConjuntoDatos = lStrCadena.Split('|');
                            lObjPuesto.lIntIdPuesto = int.Parse(lStrConjuntoDatos[0]);
                            lObjPuesto.lStrNombrePuesto = lStrConjuntoDatos[1];
                            lObjPuesto.lDblSueldo = double.Parse(lStrConjuntoDatos[2]);
                            lObjResultado.Add(lObjPuesto);
                        }
                    }
                }
            }
            catch (IOException lStrError)
            {
                Console.WriteLine(lStrError.Message);

            }
            return lObjResultado;
        }
        public List<PuestoTrabajo> fncListaPuestosBinario(string pStrPath)
        {
            var lObjResultado = new List<PuestoTrabajo>();
            PuestoTrabajo lObjPuesto;
            BinaryReader lObjLeer;
            try
            {
                if (File.Exists(pStrPath))
                {
                    FileStream lObjArchivo = new FileStream(pStrPath, FileMode.Open, FileAccess.Read);
                    lObjLeer = new BinaryReader(lObjArchivo);
                    while (lObjArchivo.Position != lObjArchivo.Length)
                    {
                        lObjPuesto.lIntIdPuesto = lObjLeer.ReadInt32();
                        lObjPuesto.lStrNombrePuesto = lObjLeer.ReadString();
                        lObjPuesto.lDblSueldo = lObjLeer.ReadDouble();
                        lObjResultado.Add(lObjPuesto);
                    }
                }
            }
            catch (IOException lStrError)
            {
                Console.WriteLine(lStrError.Message);

            }
            return lObjResultado;
        }
        /// <summary>
        /// este metodo es utilizado para agregar informacion de empleado.
        /// </summary>
        public void SubAgregarEmpleado()
        {
            string lstrInformacion = String.Empty;
            string lStrCadera = string.Empty;
            int lIntIdEmpleado = 0;
            string lStrNombre = string.Empty;
            string lStrDireccion = string.Empty;
            string lStrTelefono = string.Empty;
            int lintIdPuesto = 0;
            Boolean lBlnContinuaIngresando = true;
            string lStrDeseaContinuar = string.Empty;
            string lStrSeparador = "|";
            Console.Clear();
            try
            {
                lIntIdEmpleado = fncValidaUltimoID("C://UMG//EMPLEADOB.TXT");
                while (lBlnContinuaIngresando == true)
                {
                    if (lIntIdEmpleado != 0)
                    {
                        Console.SetCursorPosition(0, 3);
                        string lStrTitulo = "INFORMACION A COMPLETAR DE EMPLEADO";
                        Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                        Console.WriteLine(lStrTitulo);
                        Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 6); Console.WriteLine("DATOS GENERALES");
                        Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 08); Console.WriteLine("ID EMPLEADO     :            [                                          ]");
                        Console.SetCursorPosition(35, 09); Console.WriteLine("NOMBRE EMPLEADO :            [                                          ]");
                        Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION       :            [                                          ]");
                        Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO        :            [                                          ]");
                        Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 13); Console.WriteLine("DATOS ESPECIFICOS");
                        Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 15); Console.WriteLine("ID PUESTO       :            [                                          ]");
                        Console.SetCursorPosition(25, 16); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntIdEmpleado).PadLeft(4, '0'));
                        Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                        Console.SetCursorPosition(70, 10); lStrDireccion = Console.ReadLine();
                        Console.SetCursorPosition(70, 11); lStrTelefono = Console.ReadLine();
                        Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());
                        bool lBlnValida = false;
                        lBlnValida = fncValidaID("C://UMG//PUESTOSB.TXT", lintIdPuesto);
                        while (lBlnValida == false)
                        {
                            Console.SetCursorPosition(35, 22); Console.WriteLine("EL ID NO EXISTE.");
                            Console.SetCursorPosition(70, 15); Console.WriteLine("         ");
                            Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());
                            lBlnValida = fncValidaID("C://UMG//PUESTOSB.TXT", lintIdPuesto);
                        }

                        StreamWriter lobjArchivo = new StreamWriter(new FileStream("c:/umg/empleadob.txt", FileMode.Append));
                        lobjArchivo.Write(Convert.ToString(lIntIdEmpleado).PadRight(4, ' ')); lobjArchivo.Write(lStrSeparador);
                        lobjArchivo.Write(lStrNombre.PadRight(30, ' ')); lobjArchivo.Write(lStrSeparador);
                        lobjArchivo.Write(lStrDireccion.PadRight(30, ' ')); lobjArchivo.Write(lStrSeparador);
                        lobjArchivo.Write(lStrTelefono.PadRight(30, ' ')); lobjArchivo.Write(lStrSeparador);
                        lobjArchivo.WriteLine(Convert.ToString(lintIdPuesto).PadRight(4, ' '));

                        lIntIdEmpleado += 1;
                        Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                        Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();

                        if (lStrDeseaContinuar.ToUpper() == "N")
                        {
                            lBlnContinuaIngresando = false;
                        }
                        lobjArchivo.Close();
                    }
                }
            }
            catch (Exception lStrError)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO DE EMPLEADOS, DETALLE ERROR ->" + lStrError.Message);
            }
        }
        /// <summary>
        /// este metodo es utilizado para agregar informacion de empleado en la base de datos SQL.
        /// </summary>
        public void SubAgregarEmpleadoSQL()
        {
            clsEmppleadoEN lObjEmppleado = new clsEmppleadoEN();
            string lstrInformacion = String.Empty;
            Boolean lBlnContinuaIngresando = true;
            string lStrDeseaContinuar = string.Empty;
            Console.Clear();
            try
            {
                clsConexionSQL lObjProceso = new clsConexionSQL();
                lObjEmppleado.lIdEmpleado = lObjProceso.FncConsultarEmpleado();
                while (lBlnContinuaIngresando == true)
                {
                    if (lObjEmppleado.lIdEmpleado != 0)
                    {
                        Console.SetCursorPosition(0, 3);
                        string lStrTitulo = "INFORMACION A COMPLETAR DE EMPLEADO";
                        Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                        Console.WriteLine(lStrTitulo);
                        Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 6); Console.WriteLine("DATOS GENERALES");
                        Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 08); Console.WriteLine("ID EMPLEADO     :            [                                          ]");
                        Console.SetCursorPosition(35, 09); Console.WriteLine("NOMBRE EMPLEADO :            [                                          ]");
                        Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION       :            [                                          ]");
                        Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO        :            [                                          ]");
                        Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(50, 13); Console.WriteLine("DATOS ESPECIFICOS");
                        Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(35, 15); Console.WriteLine("ID PUESTO       :            [                                          ]");
                        Console.SetCursorPosition(25, 16); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                        Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lObjEmppleado.lIdEmpleado).PadLeft(4, '0'));
                        Console.SetCursorPosition(70, 9); lObjEmppleado.lStrNombreEmpleado = Console.ReadLine();
                        Console.SetCursorPosition(70, 10); lObjEmppleado.lStrDireccion = Console.ReadLine();
                        Console.SetCursorPosition(70, 11); lObjEmppleado.lStrTelefono = Console.ReadLine();
                        Console.SetCursorPosition(70, 15); lObjEmppleado.lIntIdPuesto = int.Parse(Console.ReadLine());
                        Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                        Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();
                        lObjProceso.FcnlAgregarEmpleado(lObjEmppleado);
                        if (lStrDeseaContinuar.ToUpper() == "N")
                        {
                            lBlnContinuaIngresando = false;
                        }
                        lObjEmppleado.lIdEmpleado += 1;
                    }
                }
            }
            catch (Exception lStrError)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO DE EMPLEADOS, DETALLE ERROR ->" + lStrError.Message);
            }
        }
        /// <summary>
        /// este metodo es utilizado para agregar informacion de empleado.
        /// </summary>
        public void SubAgregarEmpleadoBinario()
        {
            string lstrInformacion = String.Empty;
            string lStrCadera = string.Empty;
            int lIntIdEmpleado = 0;
            string lStrNombre = string.Empty;
            string lStrDireccion = string.Empty;
            string lStrTelefono = string.Empty;
            int lintIdPuesto = 0;
            Boolean lBlnContinuaIngresando = true;
            string lStrDeseaContinuar = string.Empty;
            BinaryWriter lObjEscribir;
            Console.Clear();
            try
            {
                lIntIdEmpleado = fncValidaUltimoIDBinario("C://UMG//EMPLEADOBiB.TXT");
                using (FileStream lObjArchivo = new FileStream("C://UMG//EMPLEADOBiB.TXT", FileMode.Append))
                {
                    while (lBlnContinuaIngresando == true)
                    {
                        if (lIntIdEmpleado != 0)
                        {
                            Console.SetCursorPosition(0, 3);
                            string lStrTitulo = "INFORMACION A COMPLETAR DE EMPLEADO";
                            Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                            Console.WriteLine(lStrTitulo);
                            Console.SetCursorPosition(25, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(50, 6); Console.WriteLine("DATOS GENERALES");
                            Console.SetCursorPosition(25, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 08); Console.WriteLine("ID EMPLEADO     :            [                                          ]");
                            Console.SetCursorPosition(35, 09); Console.WriteLine("NOMBRE EMPLEADO :            [                                          ]");
                            Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION       :            [                                          ]");
                            Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO        :            [                                          ]");
                            Console.SetCursorPosition(25, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(50, 13); Console.WriteLine("DATOS ESPECIFICOS");
                            Console.SetCursorPosition(25, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(35, 15); Console.WriteLine("ID PUESTO       :            [                                          ]");
                            Console.SetCursorPosition(25, 16); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 85)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntIdEmpleado).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 10); lStrDireccion = Console.ReadLine();
                            Console.SetCursorPosition(70, 11); lStrTelefono = Console.ReadLine();
                            Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());
                            bool lBlnValida = false;
                            lBlnValida = fncValidaIDBinario("C://UMG//PUESTOSBiB.TXT", lintIdPuesto);
                            while (lBlnValida == false)
                            {
                                Console.SetCursorPosition(35, 22); Console.WriteLine("EL ID NO EXISTE.");
                                Console.SetCursorPosition(70, 15); Console.WriteLine("         ");
                                Console.SetCursorPosition(70, 15); lintIdPuesto = int.Parse(Console.ReadLine());
                                lBlnValida = fncValidaID("C://UMG//PUESTOSBiB.TXT", lintIdPuesto);
                            }

                            lObjEscribir = new BinaryWriter(lObjArchivo);

                            lObjEscribir.Write(lIntIdEmpleado);
                            lObjEscribir.Write(lStrNombre);
                            lObjEscribir.Write(lStrDireccion);
                            lObjEscribir.Write(lStrTelefono);
                            lObjEscribir.Write(lintIdPuesto);

                            lIntIdEmpleado += 1;
                            Console.SetCursorPosition(40, 18); Console.WriteLine("DESEA CONTINUAR INGRESANDO REGISTROS S/N:        [  ]");
                            Console.SetCursorPosition(90, 18); lStrDeseaContinuar = Console.ReadLine();

                            if (lStrDeseaContinuar.ToUpper() == "N")
                            {
                                lBlnContinuaIngresando = false;
                                lObjEscribir.Close();
                            }
                        }
                    }
                }

            }
            catch (Exception lStrError)
            {
                Console.WriteLine("ERROR EN INTERACCION CON ARCHIVO DE EMPLEADOS, DETALLE ERROR ->" + lStrError.Message);
            }
        }
        /// <summary>
        /// Este metodo se utilizara para desplegar la informacion en pantalla segun los campos, Nombre Empleado, PUesto Empleado, Salario, Cuota Patronal y Sueldo liquiedo.
        /// </summary>
        public void SubListarInformacionEmpleado()
        {
            Console.Clear();
            try
            {
                string lStrCadena;
                int lIntLinea = 9;
                string lStrTitulo = "PLANILLA LABORAL";
                Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                Console.WriteLine(lStrTitulo);
                Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                lStrTitulo = "DETALLE DE INFORMACION";
                Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                Console.WriteLine(lStrTitulo);
                Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 8); Console.WriteLine("NOMBRE EMPLEADO                NOMBRE PUESTO       SUELDO       CUOTA PATRONAL   SUELDO LIQUIDO");
                List<PuestoTrabajo> lObjPuestos = fncListaPuestos("c:/umg/puestosb.txt");
                var lObjArchivo = new StreamReader("c:/umg/empleadob.txt");
                while ((lStrCadena = lObjArchivo.ReadLine()) != null)
                {
                    String[] lStrConjuntoDatos = lStrCadena.Split('|');
                    string lStrPuesto = string.Empty;
                    double lDblCuotaPatronal = 0.00;
                    double lDblSalarioLiquidado = 0.00;
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(lStrConjuntoDatos[1]);
                    foreach (PuestoTrabajo lObjPuesto in lObjPuestos)
                    {
                        if (lObjPuesto.lIntIdPuesto == int.Parse(lStrConjuntoDatos[4]))
                        {
                            Console.SetCursorPosition(37, lIntLinea); Console.Write(lObjPuesto.lStrNombrePuesto);
                            Console.SetCursorPosition(57, lIntLinea); Console.Write(lObjPuesto.lDblSueldo.ToString("N2"));
                            lDblCuotaPatronal = lObjPuesto.lDblSueldo * 0.0483;
                            lDblSalarioLiquidado = lObjPuesto.lDblSueldo - lDblCuotaPatronal;
                            Console.SetCursorPosition(70, lIntLinea); Console.Write(lDblCuotaPatronal.ToString("N2"));
                            Console.SetCursorPosition(90, lIntLinea); Console.Write(lDblSalarioLiquidado.ToString("N2"));
                            lIntLinea += 1;
                            break;
                        }
                    }
                }
                Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");


            }
            catch (IOException lStrError)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + lStrError.Message);
                Console.WriteLine("        ________________________________________________________________");

            }
        }

        /// <summary>
        /// Este metodo se utilizara para desplegar la informacion en pantalla segun los campos, Nombre Empleado, PUesto Empleado, Salario, Cuota Patronal y Sueldo liquiedo.
        /// </summary>
        public void SubListarInformacionEmpleadoBinario()
        {
            Console.Clear();
            BinaryReader lObjLeer;
            int lintIdEmpleado = 0;
            try
            {
                string lStrCadena;
                int lIntLinea = 9;
                string lStrTitulo = "PLANILLA LABORAL";
                Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                Console.WriteLine(lStrTitulo);
                Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                lStrTitulo = "DETALLE DE INFORMACION";
                Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                Console.WriteLine(lStrTitulo);
                Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(5, 8); Console.WriteLine("NOMBRE EMPLEADO                NOMBRE PUESTO       SUELDO       CUOTA PATRONAL   SUELDO LIQUIDO");
                List<PuestoTrabajo> lObjPuestos = fncListaPuestosBinario("c:/umg/puestosbib.txt");

                FileStream lObjArchivo = new FileStream("c:/umg/empleadoBiB.txt", FileMode.Open, FileAccess.Read);
                lObjLeer = new BinaryReader(lObjArchivo);
                while (lObjArchivo.Position != lObjArchivo.Length)
                {
                    string lStrPuesto = string.Empty;
                    double lDblCuotaPatronal = 0.00;
                    double lDblSalarioLiquidado = 0.00;
                    lintIdEmpleado = lObjLeer.ReadInt32();
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(lObjLeer.ReadString());
                    foreach (PuestoTrabajo lObjPuesto in lObjPuestos)
                    {
                        lObjLeer.ReadString();
                        lObjLeer.ReadString();
                        if (lObjPuesto.lIntIdPuesto == lObjLeer.ReadInt32())
                        {
                            Console.SetCursorPosition(37, lIntLinea); Console.Write(lObjPuesto.lStrNombrePuesto);
                            Console.SetCursorPosition(57, lIntLinea); Console.Write(lObjPuesto.lDblSueldo.ToString("N2"));
                            lDblCuotaPatronal = lObjPuesto.lDblSueldo * 0.0483;
                            lDblSalarioLiquidado = lObjPuesto.lDblSueldo - lDblCuotaPatronal;
                            Console.SetCursorPosition(70, lIntLinea); Console.Write(lDblCuotaPatronal.ToString("N2"));
                            Console.SetCursorPosition(90, lIntLinea); Console.Write(lDblSalarioLiquidado.ToString("N2"));
                            lIntLinea += 1;
                            break;
                        }
                    }

                }


                Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");


            }
            catch (IOException lStrError)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + lStrError.Message);
                Console.WriteLine("        ________________________________________________________________");

            }
        }
        public void subProcesoAumentoSalario()
        {
            Console.Clear();
            try
            {
                string lStrSeparador = "|";
                StreamWriter lObjArchivoFinal;
                string lStrCadena;
                int lIntLinea = 9;
                using (var lObjArchivo = new StreamReader("c:/umg/puestosb.txt"))
                {
                    lObjArchivoFinal = File.CreateText("c:/umg/tempb.txt");
                    Console.SetCursorPosition(0, 3);
                    string lStrTitulo = "PLANILLA DE SALARIOS";
                    Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(lStrTitulo);
                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    lStrTitulo = "AUMENTO SALARIO";
                    Console.SetCursorPosition((Console.WindowWidth - lStrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine("DETALLE DE INFORMACION");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(5, 8); Console.WriteLine(" ID        NOMBRE PUESTO       SUELDO ACTUAL    AUMENTO   SALARIO NUEVO");
                    while ((lStrCadena = lObjArchivo.ReadLine()) != null)
                    {
                        String[] lStrConjuntoDatos = lStrCadena.Split('|');
                        double lDblAumento = 0;
                        double lDblSalarioNuevo = 0;
                        Console.SetCursorPosition(5, lIntLinea); Console.Write(lStrConjuntoDatos[0]);
                        Console.SetCursorPosition(15, lIntLinea); Console.Write(lStrConjuntoDatos[1]);
                        lDblAumento = double.Parse(lStrConjuntoDatos[2]) * 0.05;
                        lDblSalarioNuevo = double.Parse(lStrConjuntoDatos[2]) + lDblAumento;
                        Console.SetCursorPosition(38, lIntLinea); Console.Write(double.Parse(lStrConjuntoDatos[2]).ToString("N2"));
                        Console.SetCursorPosition(56, lIntLinea); Console.Write(lDblAumento.ToString("N2"));
                        Console.SetCursorPosition(67, lIntLinea); Console.Write(lDblSalarioNuevo.ToString("N2"));
                        lObjArchivoFinal.Write(Convert.ToString(lStrConjuntoDatos[0]).PadRight(4, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                        lObjArchivoFinal.Write(lStrConjuntoDatos[1].PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                        lObjArchivoFinal.WriteLine(Convert.ToString(lDblSalarioNuevo).PadLeft(10, '0'));
                        lIntLinea += 1;
                    }
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }
                lObjArchivoFinal.Close();
                File.Delete("c:/umg/puestosb.txt");
                File.Move("c:/umg/tempb.txt", "c:/umg/puestosb.txt");
            }
            catch (IOException lStrError)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + lStrError.Message);
                Console.WriteLine("        ________________________________________________________________");

            }
        }

        public void SubModificarEmpleado()
        {
            Console.Clear();
            try
            {
                string lStrSeparador = "|";
                StreamWriter lObjArchivoFinal;
                int lIntCodigoEmpleado = 0;
                using (var lObjArchivo = new StreamReader("c:/umg/empleadob.txt"))
                {
                    lObjArchivoFinal = File.CreateText("c:/umg/tempempb.txt");
                    string lStrCadena;
                    int lIntLinea = 9;
                    Console.SetCursorPosition(0, 3);
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "MANTENIMIENTOS DE DATOS DEL EMPLEADO";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "INGRESAR DATOS A MODIFICAR";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.SetCursorPosition(7, 6); Console.WriteLine("INGRESE EL NUMERO EMPLEADO A MODIFICAR:                        [             ]");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(75, 6); lIntCodigoEmpleado = int.Parse(Console.ReadLine());
                    while ((lStrCadena = lObjArchivo.ReadLine()) != null)
                    {
                        String[] lStrConjuntoDatos = lStrCadena.Split('|');
                        if (int.Parse(lStrConjuntoDatos[0]) == lIntCodigoEmpleado)
                        {
                            string lStrNombre = string.Empty;
                            string lStrDireccion = string.Empty;
                            string lStrTelefono = string.Empty;
                            Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("DATOS GENERALES ");
                            Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 08); Console.WriteLine("ID EMPLEADO    :            [                                          ]");
                            Console.SetCursorPosition(35, 09); Console.WriteLine("NOMBRE EMPLEADO:            [                                          ]");
                            Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION      :            [                                          ]");
                            Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO       :            [                                          ]");
                            Console.SetCursorPosition(5, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntCodigoEmpleado).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); Console.WriteLine(lStrConjuntoDatos[1]);
                            Console.SetCursorPosition(70, 10); Console.WriteLine(lStrConjuntoDatos[2]);
                            Console.SetCursorPosition(70, 11); Console.WriteLine(lStrConjuntoDatos[3]);
                            Console.SetCursorPosition(5, 13); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 14); Console.WriteLine("MODIFICACION DE DATOS");
                            Console.SetCursorPosition(5, 15); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 17); Console.WriteLine("NOMBRE EMPLEADO :           [                                          ]");
                            Console.SetCursorPosition(35, 18); Console.WriteLine("DIRECCION      :            [                                          ]");
                            Console.SetCursorPosition(35, 19); Console.WriteLine("TELEFONO       :            [                                          ]");
                            Console.SetCursorPosition(5, 20); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(70, 17); lStrNombre = Console.ReadLine();
                            Console.SetCursorPosition(70, 18); lStrDireccion = Console.ReadLine();
                            Console.SetCursorPosition(70, 19); lStrTelefono = Console.ReadLine();
                            lObjArchivoFinal.Write(Convert.ToString(lIntCodigoEmpleado).PadRight(4, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.Write(lStrNombre.PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.Write(lStrDireccion.PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.Write(lStrTelefono.PadRight(30, ' ')); lObjArchivoFinal.Write(lStrSeparador);
                            lObjArchivoFinal.WriteLine(Convert.ToString(lStrConjuntoDatos[4]).PadRight(4, ' '));
                        }
                        else
                        {
                            lObjArchivoFinal.WriteLine(lStrCadena);
                        }
                    }
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }
                lObjArchivoFinal.Close();
                File.Delete("c:/umg/empleadob.txt");
                File.Move("c:/umg/tempempb.txt", "c:/umg/empleadob.txt");
                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");
            }
            catch (IOException lStrError)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + lStrError.Message);
                Console.WriteLine("        ________________________________________________________________");
            }
        }

        public void SubEliminarEmpleado()
        {
            Console.Clear();
            try
            {
                StreamWriter lObjArchivoFinal;
                String lStrDeseaEliminar = String.Empty;
                int lIntCodigoEmpleado = 0;
                using (var lObjArchivo = new StreamReader("c:/umg/empleadob.txt"))
                {
                    lObjArchivoFinal = File.CreateText("c:/umg/tempempb.txt");
                    string lStrCadena;
                    int lIntLinea = 9;
                    Console.SetCursorPosition(0, 3);
                    Console.SetCursorPosition(0, 3);
                    string StrTitulo = "MANTENIMIENTOS DE DATOS DEL EMPLEADO";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.WriteLine(StrTitulo);

                    Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    StrTitulo = "INGRESAR DATOS A ELIMINAR";
                    Console.SetCursorPosition((Console.WindowWidth - StrTitulo.Length) / 2, Console.CursorTop); //Centrar cursor para desplegar el titulo.
                    Console.SetCursorPosition(7, 6); Console.WriteLine("INGRESE EL NUMERO EMPLEADO A ELIMINAR:                        [             ]");
                    Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                    Console.SetCursorPosition(75, 6); lIntCodigoEmpleado = int.Parse(Console.ReadLine());
                    while ((lStrCadena = lObjArchivo.ReadLine()) != null)
                    {
                        String[] lStrConjuntoDatos = lStrCadena.Split('|');
                        if (int.Parse(lStrConjuntoDatos[0]) == lIntCodigoEmpleado)
                        {
                            string lStrNombre = string.Empty;
                            string lStrDireccion = string.Empty;
                            string lStrTelefono = string.Empty;
                            Console.SetCursorPosition(5, 5); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 6); Console.WriteLine("DATOS GENERALES ");
                            Console.SetCursorPosition(5, 7); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(35, 08); Console.WriteLine("ID EMPLEADO    :            [                                          ]");
                            Console.SetCursorPosition(35, 09); Console.WriteLine("NOMBRE EMPLEADO:            [                                          ]");
                            Console.SetCursorPosition(35, 10); Console.WriteLine("DIRECCION      :            [                                          ]");
                            Console.SetCursorPosition(35, 11); Console.WriteLine("TELEFONO       :            [                                          ]");
                            Console.SetCursorPosition(5, 12); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(70, 8); Console.WriteLine(Convert.ToString(lIntCodigoEmpleado).PadLeft(4, '0'));
                            Console.SetCursorPosition(70, 9); Console.WriteLine(lStrConjuntoDatos[1]);
                            Console.SetCursorPosition(70, 10); Console.WriteLine(lStrConjuntoDatos[2]);
                            Console.SetCursorPosition(70, 11); Console.WriteLine(lStrConjuntoDatos[3]);
                            Console.SetCursorPosition(5, 14); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                            Console.SetCursorPosition(25, 13); Console.WriteLine("DESEA CONTINUAR CON LA ELIMINACION DEL  REGISTROS S/N:        [  ]");
                            Console.SetCursorPosition(88, 13); lStrDeseaEliminar = Console.ReadLine();
                            if (lStrDeseaEliminar.ToUpper() == "S")
                            {
                                Console.SetCursorPosition(40, 13); Console.WriteLine("                                                                                 ");
                                Console.SetCursorPosition(40, 13); Console.WriteLine("EL REGISTRO FUE ELIMINADO.");
                            }
                            else
                            {
                                lObjArchivoFinal.WriteLine(lStrCadena);
                            }
                        }
                        else
                        {
                            lObjArchivoFinal.WriteLine(lStrCadena);
                        }
                    }
                    Console.SetCursorPosition(5, lIntLinea); Console.WriteLine(string.Concat(Enumerable.Repeat("=", 110)));
                }
                lObjArchivoFinal.Close();
                File.Delete("c:/umg/empleadob.txt");
                File.Move("c:/umg/tempempb.txt", "c:/umg/empleadob.txt");
                Console.SetCursorPosition(30, 30); Console.Write("            Presione una tecla para continuar...");
            }
            catch (IOException lStrError)
            {
                Console.WriteLine("        ________________________________________________________________");
                Console.WriteLine("            OCURRIO UN ERROR AL LEER EL ARCHIVO, FAVOR REVISE");
                Console.WriteLine("   " + lStrError.Message);
                Console.WriteLine("        ________________________________________________________________");
            }
        }
    }
}

