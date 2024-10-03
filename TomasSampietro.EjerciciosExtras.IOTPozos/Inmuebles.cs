using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    public class Inmuebles: IBienListable
    {
        /*
         o	Número: entero entre 1001 y 999.999 como los equipos
        o	Nombre: que describa al inmueble
        o	Dirección: no son las coordenadas de GPS sino la dirección común
         */
        public int NumeroInmueble { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }

        //Constructor
        public Inmuebles(int parNumeroInmueble, string parNombreInmueble, string parDireccion)
        {
            NumeroInmueble = parNumeroInmueble;
            Nombre = parNombreInmueble;
            Direccion = parDireccion;
        }

        //Metodo

        public string Detallar()
        {
            string retorno = $"Numero de Inmueble: {NumeroInmueble}" +
                $"\nNombre: {Nombre}" +
                $"\nDireccion: {Direccion}";

                return retorno;
        }

        public int getNumero()
        {
            int retorno = NumeroInmueble;
            return retorno;
        }
    }
}
