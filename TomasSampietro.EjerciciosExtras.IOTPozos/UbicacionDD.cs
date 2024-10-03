using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    public class UbicacionDD
    {
        public double Latitud { get; set; }
        public double Longitud { get; set; }


        //Constructor+
        public UbicacionDD()
        {
            Latitud = 0;
            Longitud = 0;

        }

        public UbicacionDD(double parLatitud, double parLongitud)
        {
            Latitud = parLatitud;
            Longitud = parLongitud;
        }

        //Metodos
        public void SetUbicacionDeclarada(double parLatitud, double parLongitud)
        {
            Latitud = parLatitud;
            Longitud = parLongitud;
            
        }

        public string resumir()
        {
            return $"Latitud: {Latitud} - Longitud: {Longitud}";
        }
    }
}
