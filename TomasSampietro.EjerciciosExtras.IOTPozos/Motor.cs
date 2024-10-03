using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    internal class Motor: Equipos
    {
        //Propiedades
        public string TipoDeMotor { get; set; }
        public int PotenciaHPMotor { get; set; }

        //Constructor
        public Motor(int parNumeroDeEQuipo, string parMarca, string parModelo, 
            string parNumeroDeSerie, bool parActivo, string parTipoDeMotor, int parPotenciaHPMotor) :base(parNumeroDeEQuipo, "Motor", parMarca, parModelo, parNumeroDeSerie, parActivo)
        {
            TipoDeMotor = parTipoDeMotor;
            PotenciaHPMotor = parPotenciaHPMotor;

        }

        //Metodos
        public override string Detallar()
        {
            return base.Detallar() + $"\tTipo y Potencia de Motor: {TipoDeMotor} de {PotenciaHPMotor} HP";
        }
    }
}
