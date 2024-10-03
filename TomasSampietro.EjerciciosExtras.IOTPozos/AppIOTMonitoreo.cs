using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TomasSampietro.EjerciciosExtras.IOTPozos;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    internal class AppIOTMonitoreo
    {
        CtrIOTMonitoreo control = new CtrIOTMonitoreo();
        Validador validador = new Validador();
        List<Equipos> equipos = new List<Equipos>();
        List<Inmuebles> inmuebles = new List<Inmuebles>();
        List<IBienListable> bienesListables = new List<IBienListable>();

        public void iniciar()
        {
            //1. Carga inicial de algunos elementos a la lista.
            CargaInicial(equipos, inmuebles, bienesListables);


            string opcion = "";
            string deseaContinuar = "";
            do
            {
                do
                {
                    opcion = validador.pedirStringNoVacio("Ingrese una opcion: " +
                        "\nA. ----> Listar equipos." +
                        "\nB. ----> Listar Inmuebles." +
                        "\nC. ----> Listar Bienes Listables.");

                    if (opcion == "A") //A.Listar equipos
                    {
                        
                        Console.WriteLine("Lista Equipos: \n");
                        listarEquipos(equipos);
                        Console.WriteLine("\n");

                    }

                    else if (opcion == "B") //B.Listar inMuebles
                    {
                        Console.WriteLine("Lista Inmuebles: \n");
                        listarInmuebles(inmuebles);
                        Console.WriteLine("\n");
                    }

                    else if (opcion == "C") //C.Listar Bienes Listables
                    {
                        Console.WriteLine("Listando Equipos\n");
                        listarbienesListables(bienesListables);
                        Console.WriteLine("\n");
                    }


                    /*
                    else if (opcion == "B")
                    {
                        //3. agregar equipo a la lista.
                        agregarEquipo(equipos);

                    }
                    */

                    else
                    {
                        Console.WriteLine("Opcion no valida");
                    }
                } while (opcion == "");
                deseaContinuar = validador.pedirStringNoVacio("Desea continuar?" +
                    "\n S. ---> Si" +
                    "\n N. ---> No ");

            } while (deseaContinuar == "S");

        }

        private void CargaInicial(List<Equipos> equipos, List<Inmuebles> inmuebles, List<IBienListable> bienListables)
        {
            equipos.Add(new UnidadBombeo(1002, "MORLIF", "40-144", "ML1231", true, 40000));
            equipos[0].SetUbicacionDeclarada(-46.5398654, -67.6254365);
            equipos.Add(new Motor(1003, "WAUKESHA", "L7042GSI S4", "WKSN01232", true, "GAS NATURAL", 1400));
            equipos[1].SetUbicacionDeclarada(-46.5398654, -67.6254365);
            equipos.Add(new UnidadBombeo(1005, "DYNAPUMP", "13", "DP000123", true, 44000));
            equipos[2].SetUbicacionDeclarada(-46.533976, -67.632103);
            equipos.Add(new Motor(1004, "WAUKESHA", "H24GSID", "WKSN04444", true, "GAS NATURAL", 500));
            equipos[3].SetUbicacionDeclarada(-46.533976, -67.632103);

            inmuebles.Add(new Inmuebles(1006, "ADMINISTRACION C. OLIVIA", "J. HERNANDEZ 354"));
            inmuebles.Add(new Inmuebles(1007, "BASE CAÑADON SECO", "VIZCACHERAS 5995"));

        }

        public void listarEquipos(List<Equipos> listaEqipos)
        {
            foreach(Equipos equipo in equipos)
            {
                if(equipo is Motor)
                {
                    Motor equipoAListar = (Motor)equipo;
                    equipoAListar.Detallar();
                    string detalle = equipoAListar.Detallar();
                    Console.WriteLine(detalle);
                }
                if(equipo is UnidadBombeo)
                {
                    UnidadBombeo equipoAListar = (UnidadBombeo)equipo;
                    string detalle = equipoAListar.Detallar();
                    Console.WriteLine(detalle);
                }
            }
        }


        public void listarInmuebles(List<Inmuebles> inmuebles)
        {
            foreach(Inmuebles inmueble in inmuebles)
            {
                Console.WriteLine(inmueble.Detallar()); 
            }

        }

        //TODO: IbienListable es una interfaz. No tiene impletacion del metodo Detallar().
        public void listarbienesListables(List<IBienListable> bienListables)
        {
            foreach (IBienListable bien in bienesListables)
            {
                Console.WriteLine(bien.Detallar()); 
            }
        }

        //TODO: Continuar desarrollo agregarEquipo.
        /*
        public void agregarEquipo(List<Equipos> equipos)
        {

            string equipoAIngresar = validador.pedirStringNoVacio("Que equipo desea agregar?" +
                "\n M ---> Motor" +
                "\n U ---> Unidad de Bombeo");
            
            if(equipoAIngresar =="M") //Ingresar Motor
            {
                int numeroMotorAIngresar = ;
                string marcaAIngresar;
                string modeloAIngresar;
                string numeroAIngresar;
                bool ActivoAIngresar;
                string tipoDeMotorAIngresar;
                int potenciaAIngresar;

                Motor motorAIngresar = new Motor(numeroMotorAIngresar, marcaAIngresar, numeroAIngresar, ActivoAIngresar, tipoDeMotorAIngresar, potenciaAIngresar);
            }

            else if(equipoAIngresar == "U") //Ingresar unidad de bombeo
            {

            }
        */

        }
}

