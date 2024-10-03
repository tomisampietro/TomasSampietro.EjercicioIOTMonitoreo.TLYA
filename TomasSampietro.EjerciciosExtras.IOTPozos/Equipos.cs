using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    //Hereda de la interfaz Ubicacion Declarada.
    public abstract class Equipos: IBienListable
    {
        //Propiedades
        public int NumeroDeEquipo { get; set; }
        public string Clase { get; set; }
        public string Marca { get; set; }
        public string Modelo { get; set; }
        public string NumeroDeSerie { get; set; }
        public bool Activo { get; set; }

        public UbicacionDD UbicacionDeclarada { get; set; }

        //Constructor
        public Equipos(int parNumeroDeEquipo, string parClase, string parMarca, string parModelo, string parNumeroDeSerie, bool parActivo)
        {
            NumeroDeEquipo = parNumeroDeEquipo;
            Clase = parClase;
            Marca = parMarca;
            Modelo = parModelo;
            NumeroDeSerie = parNumeroDeSerie;
            Activo = parActivo;
            UbicacionDeclarada = new UbicacionDD();
        }

        //Metodos
        public string SetUbicacionDeclarada(double parLatitud, double parLongitud)
        {
            UbicacionDD nuevaUbicacion = new UbicacionDD(parLatitud, parLongitud);
            UbicacionDeclarada = nuevaUbicacion;

            return ""; //Se modifico la ubicacion del Equipo.
        }

        public virtual string Detallar()
        {
            string retorno = $"\tEquipo nro:  {NumeroDeEquipo} Clase: {Clase}\r\n                Marca: {Marca} Modelo: {Modelo}\r\n                Nro. serie: {NumeroDeSerie} Activo: {Activo}\r\n                Ubicación Declarada: {UbicacionDeclarada.resumir()}\r\n";
            return retorno;
        }

        public int getNumero()
        {
            return this.NumeroDeEquipo;
        }
    }
}
