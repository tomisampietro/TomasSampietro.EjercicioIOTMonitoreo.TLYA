using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TomasSampietro.EjerciciosExtras.IOTPozos
{
    public class Validador
    {

        public string pedirStringNoVacio(string mensaje)
        {
            string retorno = "";
            do
            {
                Console.WriteLine(mensaje);
                retorno = Console.ReadLine().ToUpper();
                
                if(retorno =="")
                {
                    Console.WriteLine("Debe ingresar algo.");
                }
            }
            while (retorno =="");
            return retorno;
        }
       

    }
}
