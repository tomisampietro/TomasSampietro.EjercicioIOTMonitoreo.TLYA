using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    CtrIOTMonitoreo ctrIOT = new CtrIOTMonitoreo();

    public void Iniciar()
    {
        const string OpcLisEq = "E";
        const string OpcLisBi = "B";
        const string OpcMonit = "M";
        const string OpcSalir = "S";
        const string OpcMonNo = "N";

        string opcion = "";
        string continuarMon = "";
        CargaMonitoreo miCarga = new CargaMonitoreo(ctrIOT, "monitoreo_", ".csv");

        CargaInicial();

        do
        {
            opcion = ServValidac.PedirStrNoVac("Menú Principal - Ingrese opción"
              + "\n" + OpcLisEq + "-Listar Equipos"
              + "\n" + OpcLisBi + "-Listar Bienes"
              + "\n" + OpcMonit + "-Monitoreo"
              + "\n" + OpcSalir + "-Salir"
              );

            switch (opcion)
            {
                case OpcLisEq:
                    Console.WriteLine("\n\nListando Equipos");
                    ListarEquipos();
                    break;
                case OpcLisBi:
                    Console.WriteLine("\n\nListando Bienes");
                    ListarBienes();
                    break;
                case OpcMonit:
                    do
                    {
                        Console.WriteLine(miCarga.Ejecutar());
                        Console.WriteLine("\n\nMonitoreando");
                        MonitorearBienes();
                        continuarMon = ServValidac.PedirSoN("¿Desea repetir el monitoreo? S/N");
                    } while (continuarMon != OpcMonNo);
                    break;
                case OpcSalir:
                    break;
                default:
                    Console.WriteLine("\n\nOpción Inválida");
                    break;
            }

        } while (opcion != OpcSalir);
    }

    private void ListarEquipos()
    {
        Console.WriteLine(ctrIOT.ListaEquipos());
    }


    private void ListarBienes()
    {
        Console.WriteLine(ctrIOT.ListaBienes());
    }


    private void MonitorearBienes()
    {
        Console.WriteLine(ctrIOT.MonitoreoBienes());
    }

    private void MostrarNoVacio(string texto)
    {
        if (texto != "")
        {
            Console.WriteLine(texto);
        }
    }

    private void CargaInicial()
    {
        const string probarErrores = "N";

        //equipo 1002
        MostrarNoVacio(
          ctrIOT.CrearEquipo(
            new UnidadBombeo(1002, "MORLIF", "40-144", "ML1231", true, 40000)
            )
          );
        MostrarNoVacio(
          ctrIOT.CrearSensor(
            new SensorCarga(100001, "INTERFACE", "ITL100MT", "IF100SN001", "LBS", 90000)
            )
          );
        MostrarNoVacio(ctrIOT.AsignarSensor(1002, 100001));
        MostrarNoVacio(ctrIOT.SetUbicacionDeclarada(1002, -46.5398654, -67.6254365));

        MostrarNoVacio(
          ctrIOT.CrearSensor(
            new SensorGPSDD(100002, "ORBCOMM", "ST6200", "OCSN301")
            )
          );
        MostrarNoVacio(ctrIOT.AsignarSensor(1002, 100002));

        //equipo 1003
        MostrarNoVacio(
          ctrIOT.CrearEquipo(
            new Motor(1003, "WAUKESHA", "L7042GSI S4", "WKSN01232", true, "GAS NATURAL", 1400)
            )
          );
        MostrarNoVacio(
          ctrIOT.CrearSensor(
            new SensorGPSDD(100003, "ORBCOMM", "ST6200", "OCSN332")
            )
          );
        MostrarNoVacio(ctrIOT.AsignarSensor(1003, 100003));
        MostrarNoVacio(ctrIOT.SetUbicacionDeclarada(1003, -46.5398654, -67.6254365));

        //equipo 1005
        MostrarNoVacio(
          ctrIOT.CrearEquipo(
            new UnidadBombeo(1005, "DYNAPUMP", "13", "DP000123", true, 44000)
            )
          );

        MostrarNoVacio(
          ctrIOT.CrearSensor(
            new SensorCarga(100004, "INTERFACE", "ITL100MT", "IF100SN002", "LBS", 90000)
            )
          );
        MostrarNoVacio(ctrIOT.AsignarSensor(1005, 100004));

        MostrarNoVacio(
          ctrIOT.CrearSensor(
            new SensorGPSDD(100005, "ORBCOMM", "ST6200", "OCSN443")
            )
          );
        MostrarNoVacio(ctrIOT.AsignarSensor(1005, 100005));

        MostrarNoVacio(ctrIOT.SetUbicacionDeclarada(1005, -46.533976, -67.632103));

        //equipo 1004
        MostrarNoVacio(
        ctrIOT.CrearEquipo(
          new Motor(1004, "WAUKESHA", "H24GSID", "WKSN04444", true, "GAS NATURAL", 500)
          )
        );

        MostrarNoVacio(
        ctrIOT.CrearSensor(
          new SensorGPSDD(100006, "ORBCOMM", "ST6200", "OCSN545")
          )
        );
        MostrarNoVacio(ctrIOT.AsignarSensor(1004, 100006));

        MostrarNoVacio(ctrIOT.SetUbicacionDeclarada(1004, -46.533976, -67.632103));

        //inmuebles
        MostrarNoVacio(ctrIOT.CrearInmueble(new Inmueble(1006, "ADMINISTRACION C. OLIVIA", "J. HERNANDEZ 354")));
        MostrarNoVacio(ctrIOT.CrearInmueble(new Inmueble(1007, "BASE CAÑADON SECO", "VIZCACHERAS 5995")));

        //pruebas de control de errores - inicio
        if (probarErrores == "S")
        {
            //agregar bien nro duplicado
            MostrarNoVacio(
              ctrIOT.CrearInmueble(new Inmueble(1004, "ADMINISTRACION C. OLIVIA", "J. HERNANDEZ 354"))
              );

            //crear sensor duplicado
            MostrarNoVacio(
              ctrIOT.CrearSensor(
                new SensorCarga(100004, "INTERFACE", "ITL100MT", "IF100SN002", "LBS", 90000)
                )
              );

            //asignar sensor a no monitoreable
            MostrarNoVacio(ctrIOT.AsignarSensor(1006, 100006));

            //asignar sensor previamente asignado
            MostrarNoVacio(ctrIOT.AsignarSensor(1004, 100004));

            //declarar ubicación de elemento que no es equipo
            MostrarNoVacio(ctrIOT.SetUbicacionDeclarada(1006, -46.533976, -67.632103));
        }
        //pruebas de control de errores - fin
    }

}
