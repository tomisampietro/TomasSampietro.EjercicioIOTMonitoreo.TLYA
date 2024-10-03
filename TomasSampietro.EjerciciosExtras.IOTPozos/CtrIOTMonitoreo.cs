using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    public class CtrIOTMonitoreo
    {

        //ATRIBUTOS Y LISTAS
        private List<Inmuebles> inmuebles;
        private List<Equipos> equipos;
        private List<IBienListable> bienesListables;


        //CONSTRUCTOR

        public CtrIOTMonitoreo()
        {
            inmuebles = new List<Inmuebles>();
            equipos = new List<Equipos>();
            bienesListables = new List<IBienListable>();
        }


        //METODOS

        /*
         Mostras todos los equipos de la lista. 
        Para ello, pasa toda la lista a un String, que luego devuelve. 
         */
        public string ListaEquipos() 
        {
            string equiposAMostar = "";
            foreach (Equipos equipo in equipos)
            {
                equiposAMostar = equiposAMostar + equipo.Detallar();
            }
            return equiposAMostar;

        }



        public string ListaBienes()
        {
            string bienesAMostar = "";
            foreach(IBienListable bien in bienesListables)
            {
                bienesAMostar = bienesAMostar + bien.Detallar(); //Metodo detallar() de la interfaz, IBienListable
            }
            return bienesAMostar;
        }


        private IBienListable GetBienXNro(int numeroBien)
        {
            return bienesListables.Find(bien => bien.getNumero() == numeroBien);
        }

        /*
         Para declarar la ubicacion de un equipo,
        1- encontrar el equipo segun el numeroEquipo
        2- 
         */
        public string SetUbicacionDeclarada(int numeroEquipo, double Latitud, double Longitud)
        {
            IBienListable bien;
            string retorno = "";
            Equipos equipo;

            bien = GetBienXNro(numeroEquipo); //Busca el bien, con el numeroEquipo pasado por parametro.
            if(bien == null)
            {
                retorno = $"No existe el bien con numero de equipo {numeroEquipo}";
            }
            else
            {
                equipo = bien as Equipos; //si bien no puede ser convertido a Equipos, asignará null a equipo.
                /*
                 Un caso en el que se asignará null a equipo es cuando el objeto bien no es de tipo Equipos ni de un tipo 
                derivado de Equipos. Esto puede ocurrir si bien es, por ejemplo, un objeto de tipo Inmuebles.
             
                 */

                if(equipo is null)
                {
                    retorno = $"El bien {numeroEquipo} no permite coordenadas"; //El inmueble no tiene coordenadas.
                }
                else
                {
                    retorno = equipo.SetUbicacionDeclarada(Latitud, Longitud);
                    if(retorno == "")
                    {
                        return "";
                    }
                }
            }
            return retorno;

        }

        /*
         Agrega a la lista de Equipos, un MOTOR o una UNIDADBOMBEO. 
         */
        public string CrearEquipo(Equipos equipoAAgregar)
        {
            if(equipoAAgregar.NumeroDeEquipo ==0)
            {
                return "Numero de equipo no valido.";
            }
            else
            {
                if(GetBienXNro(equipoAAgregar.getNumero()) != null) //Ya existe un Equipo con ese numero
                {
                    return $"Ya existe un equipo con el numero {equipoAAgregar.getNumero()}";
                }

                else
                {
                    equipos.Add(equipoAAgregar);
                    bienesListables.Add(equipoAAgregar);
                    return "";
                }
            }
        }

        //Agregar inmueble a la lista:
        public string CrearInmueble(Inmuebles inmueble)
        {
            if(inmueble.getNumero() ==0)
            {
                return "Numero de inmueble no valido.";
            }
            else
            {
                if(GetBienXNro(inmueble.getNumero()) !=null)
                {
                    return $"Ya existe un inmueble con el numero {inmueble.getNumero()}";
                }
                else
                {
                    inmuebles.Add(inmueble);
                    return "";
                }
            }
        }
    }
}

