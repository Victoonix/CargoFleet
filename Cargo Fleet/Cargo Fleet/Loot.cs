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
            Console.ForegroundColor = ConsoleColor.Yellow;
            if (random < 0.25)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou uma pilha de dinheiro!");
                adicional = game.dinheiro;
                game.dinheiro += Convert.ToInt32(adicional * 0.1);
                Console.WriteLine($"]]+E${Convert.ToInt32(adicional * 0.1)}[[");
            }
            else if (random < 0.5)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou tanques de oxigênio!");
                if (game.titanio > 5)
                {
                    adicional = game.oxigenio;
                    game.oxigenio += Convert.ToInt32(adicional * 0.1);
                    Console.WriteLine($"]]+{Convert.ToInt32(adicional * 0.1)} Oxigênio[[");
                }
                else
                {
                    game.oxigenio += 5;
                    Console.WriteLine("]]+5 Oxigênio[[");
                }
            }
            else if (random < 0.75)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou barris de titânio!");
                if (game.titanio > 5)
                {
                    adicional = game.titanio;
                    game.titanio += Convert.ToInt32(adicional * 0.1);
                    Console.WriteLine($"]]+{Convert.ToInt32(adicional * 0.1)} Titânio[[");
                }
                else
                {
                    game.titanio += 5;
                    Console.WriteLine("]]+5 Titânio[[");
                }
            }
            else if (random < 1)
            {
                Console.WriteLine("> Dentro da nave deles, você encontrou um motor de dobra!");
                game.motor++;
                Console.WriteLine("]]+1 Motor de Dobra[[");
            }
        }
    }
}
