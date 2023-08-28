using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo_Fleet
{
    public class Precos
    {
        Random rand = new Random();
        public double Titanio(double titanio)
        {
            int randomizar = rand.Next(1, 100);
            if (randomizar >= 95)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                titanio -= (titanio / 100 * 30);
                Console.WriteLine(" ==) -30% (== ENORME QUEDA no titânio!");
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                titanio += (titanio / 100 * 3);
                Console.WriteLine(" ==) +3% (== pequeno AUMENTO no titânio!");
            }
            return titanio;
        }
        public double Ouro(double ouro)
        {
            int randomizar = rand.Next(1, 100);
            if (randomizar < 54)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                ouro += (ouro / 100 * 16);
                Console.WriteLine(" ==) +16% (== AUMENTO no ouro!");
            }
            if (randomizar >= 54)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                ouro -= (ouro / 100 * 8);
                Console.WriteLine(" ==) -8% (== QUEDA no ouro!");
            }
            return ouro;
        }
        public double Oxigenio(double oxigenio)
        {
            int randomizar = rand.Next(1, 100);
            if (randomizar <= 50)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                oxigenio += (oxigenio / 100 * 2);
                Console.WriteLine(" ==) +2% (== AUMENTO no oxigênio!");
            }
            if (randomizar > 50)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                oxigenio -= (oxigenio / 100 * 2);
                Console.WriteLine(" ==) +2% (== AUMENTO no oxigênio!");
            }
            return oxigenio;
        }
        public double Motor(double motor)
        {
            int randomizar = rand.Next(1, 100);
            if (motor >= 500)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("!!! ==) -60% (== O motor de dobra estava muito alto! A Federação Espacial interviu e os preços foram subsidiados !!!");
                motor = 300;
            }
            else {
                if (randomizar < 95)
                {
                    if (motor >= 400)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        motor += (motor / 100 * 3);
                        Console.WriteLine(" ==) +3% (== AUMENTO no motor de dobra! Nunca para de subir!");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        motor += (motor / 100 * 1);
                        Console.WriteLine(" ==) +1% (== AUMENTO no motor de dobra! Nunca para de subir!");
                    }
                }
                if (randomizar >= 95)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    motor -= (motor / 100 * 5);
                    Console.WriteLine(" ==) -5% (== QUEDA no motor de dobra! Raro!");
                }
            }
            return motor;
        }
    }
}
