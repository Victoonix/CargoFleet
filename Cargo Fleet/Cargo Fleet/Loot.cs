using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo_Fleet
{
    class Loot
    {
        public void Piratas()
        {
            Program game = new Program();
            Random rand = new Random();
            double random = rand.NextDouble();
            double adicional;
            if (random < 0.25)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou uma pilha de dinheiro!");
            }
            else if (random < 0.5)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou tanques de oxigênio!");
            }
            else if (random < 0.75)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou barris de titânio!");
                if (game.titanio > 5)
                {
                    adicional = game.titanio;
                    game.titanio += Convert.ToInt32(adicional * 0.2);
                }
                else
                {
                    game.titanio += 5;
                }
            }
            else if (random < 1)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou um motor de dobra!");
                game.motor++;
            }
        }
    }
}
