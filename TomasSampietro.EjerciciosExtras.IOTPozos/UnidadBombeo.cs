using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    internal class UnidadBombeo: Equipos
    {
        //Propiedades
        public int CargaMaximaEnLibras { get; set; }

        //Constructor
        public UnidadBombeo(int parNumeroDeEquipo, string parMarca, string parModelo, string parNumeroDeSerie, 
            bool parActivo,int parCargaMax): base(parNumeroDeEquipo, "Unidad de Bombeo", parMarca, parModelo, parNumeroDeSerie, parActivo)
        {
            CargaMaximaEnLibras = parCargaMax;
        }

        //Propiedades
        public override string Detallar()
        {
            return base.Detallar() + $"\tCarga Máxima en Lbs: {CargaMaximaEnLibras}"; 
        }
    }
}
