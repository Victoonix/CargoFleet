using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo_Fleet
{
    class Mortes
    {
        public bool Verificar(int oxigenio)
        {
            if (oxigenio <= 0)
            {
                Console.Clear();
                Console.WriteLine("--GAME OVER--");
                Console.WriteLine("Seu oxigênio acabou. Você sufocou até a morte dentro da nave.");
                Console.ReadKey();
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
