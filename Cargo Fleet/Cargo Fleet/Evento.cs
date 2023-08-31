using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cargo_Fleet
{
    class Evento
    {
        Random rand = new Random();
        Program game = new Program();
        public bool Luta(int guardas, string tipo)
        {
            if (tipo == "piratas")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("> Os piratas acoplam a nave na sua doca e te abordam.");
                Console.ReadKey();
                if (guardas == 0) // 0 GUARDAS
                {
                    Console.WriteLine("\n> Eles não encontram nenhuma resistência à bordo.");
                    Console.ReadKey();
                }
                else if (guardas == 1)
                {
                    Console.WriteLine("\n> Eles se deparam com o seu guarda.");
                    if (rand.NextDouble() < 0.4)
                    {
                        Console.WriteLine("\n> O seu único guarda impressionantemente trata de todos os piratas.");
                        Console.ReadKey();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\n> O seu guarda luta muito, mas os piratas levaram a melhor, matando-o.");
                        Console.ReadKey();
                        game.guardas -= 1;
                    }
                    Console.ReadKey();
                }
                else if (guardas == 2)
                {
                    Console.WriteLine("\n> Eles se deparam com os seus guardas.");
                    if (rand.Next(1) == 0)
                    {
                        Console.WriteLine("\n> Os seus guardas tratam dos piratas, sem muito esforço.");
                        Console.ReadKey();
                        return true;
                    }
                    else if (rand.NextDouble() < 0.5)
                    {
                        Console.WriteLine("\n> O seus guardas têm uma luta difícil.");
                        Console.ReadKey();
                        Console.WriteLine("\n> Um dos seus guardas leva um tiro no peito.");
                        Console.ReadKey();
                        Console.WriteLine("\n> Apesar da baixa, o seu guarda restante consegue lidar com o resto dos piratas.");
                        Console.ReadKey();
                        game.guardas -= 1;
                        return true;
                    }
                    else if (rand.NextDouble() < 0.5)
                    {
                        Console.WriteLine("\n> Eles são pegos de surpresa pelos piratas.");
                        Console.ReadKey();
                        Console.WriteLine("\n> Um dos seus guardas leva um tiro no peito.");
                        Console.ReadKey();
                        Console.WriteLine("\n> O guarda restante não conseguiu recuperar o controle da situação, e acaba morrendo também.");
                        Console.ReadKey();
                        game.guardas -= 2;
                    }
                    Console.ReadKey();
                }
                else if (guardas >= 3)
                {
                    Console.WriteLine("\n> Os piratas não esperavam ver tantos guardas à bordo.");
                    Console.ReadKey();
                    if (rand.NextDouble() < 0.90)
                    {
                        Console.WriteLine("\n> Os piratas inevitavelmente perdem a luta contra os seus guardas.");
                        Console.ReadKey();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\n> Você venceu, e apesar de ter uma luta fácil, um dos seus guardas leva um tiro de surpresa e acaba morrendo na batalha.");
                        Console.ReadKey();
                        game.guardas -= 1;
                        return true;
                    }
                }
                if (rand.NextDouble() < 0.5)
                {
                    Console.WriteLine("\n> Você se esconde, arma em mãos, na curva de um corredor.");
                    Console.ReadKey();
                    if (rand.NextDouble() < 0.1)
                    {
                        Console.WriteLine("\n> Eles chegam na curva, e você atira muito rápido e precisamente, milagrosamente conseguindo vencer de todos os piratas");
                        Console.ReadKey();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\n> Você tenta, mas o líder é muito mais rápido no gatilho e te dá um tiro no peito quando ele chega na curva.");
                        return false;
                    }
                }
                else
                {
                    Console.WriteLine("\n> Você tranca a sua porta, ganhando um pouco de tempo.");
                    Console.ReadKey();
                    if (rand.NextDouble() < 0.25)
                    {
                        Console.WriteLine("\n> A porta te dá tempo para preparar. Com uma agilidade milagrosa, você atira em todos os piratas logo depois deles perfurarem a porta.");
                        Console.ReadKey();
                        return true;
                    }
                    else
                    {
                        Console.WriteLine("\n> Apesar do tempo adicional da porta, você não é ágil o suficiente para ganhar de todos os piratas ao mesmo tempo.");
                        return false;
                    }
                }
            }
            return true;
        }
        public string Gerar(int guardas, int titanio, int ouro)
        {
            string S_N = "";
            string acao = "";
            int random = rand.Next(1000);
            if (random < 100)
            {
                Console.ForegroundColor = ConsoleColor.White;
                while (acao != "A")
                {
                    Console.Clear();
                    Console.WriteLine("A nave está recebendo um sinal de transmissão.");
                    Console.WriteLine("Atender: [A]");
                    acao = Console.ReadLine().ToUpper();
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("_________________");
                Console.WriteLine("|               |");
                Console.WriteLine("|     _____     |");
                Console.WriteLine("|-___/_____\\___-|");
                Console.WriteLine("|    |-` ´-|    |");
                Console.WriteLine("|   _\\  _  /_   |");
                Console.WriteLine("| /   |   |   \\ |");
                Console.WriteLine("|/    |   |    \\|");
                Console.WriteLine("|     '   '     |");
                Console.WriteLine("|               |");
                Console.WriteLine("_________________");
                Console.WriteLine("\nMe passa todo o seu ouro, se não abordamos sua nave!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[S] Passar o ouro (Você tem {ouro})");
                Console.WriteLine($"[N] Lutar (Você tem {guardas} guardas)");
                while (S_N != "N" && S_N != "S")
                {
                    S_N = Console.ReadLine().ToUpper();
                    if (S_N == "S")
                    {
                        Console.Clear();
                        return "-all ouro";
                    }
                    else if (S_N == "N")
                    {
                        Console.Clear();
                        return "lutar piratas";
                    }
                }
            }
            else if (random < 200)
            {
                Console.ForegroundColor = ConsoleColor.White;
                while (acao != "A")
                {
                    Console.Clear();
                    Console.WriteLine("A nave está recebendo um sinal de transmissão.");
                    Console.WriteLine("Atender: [A]");
                    acao = Console.ReadLine().ToUpper();
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("_________________");
                Console.WriteLine("|    .     .    |");
                Console.WriteLine("|     |___|     |");
                Console.WriteLine("|    /     \\    |");
                Console.WriteLine("|    |0` ´0|    |");
                Console.WriteLine("|   _ \\v v/ _   |");
                Console.WriteLine("| /   /   \\   \\ |");
                Console.WriteLine("|/    =====    \\|");
                Console.WriteLine("|     '   '     |");
                Console.WriteLine("|               |");
                Console.WriteLine("_________________");
                Console.WriteLine("\nPode passar todo o titânio! Precisamos mais dele do que você!");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine($"[S] Passar o titanio (Você tem {titanio})");
                Console.WriteLine($"[N] Lutar (Você tem {guardas} guardas)");
                while (S_N != "N" && S_N != "S")
                {
                    S_N = Console.ReadLine().ToUpper();
                    if (S_N == "S")
                    {
                        Console.Clear();
                        return "-all titanio";
                    }
                    else if (S_N == "N")
                    {
                        Console.Clear();
                        return "lutar piratas";
                    }
                }
            }
            return "";
        }
    }
}
