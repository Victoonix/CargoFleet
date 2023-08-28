using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Cargo_Fleet
{
    class Program
    {

            [DllImport("user32.dll")]
            public static extern bool ShowWindow(System.IntPtr hWnd, int cmdShow);

            private static void Maximize()
            {
                Process p = Process.GetCurrentProcess();
                ShowWindow(p.MainWindowHandle, 3); //SW_MAXIMIZE = 3
            }

        public int guardas = 0;
        static void Main(string[] args)
        {
            Maximize();
            double preco_ouro = 70;
            double preco_motor = 300;
            double preco_titanio = 20;
            double preco_oxigenio = 10;
            double dinheiro = 400;
            string tipo = "E";

            string hist_ouro = "";
            string hist_motor = "";
            string hist_titanio = "";
            string hist_oxigenio = "";

            bool vivo = true;

            string S_N = "";
            int titanio = 0;
            int ouro = 0;
            int oxigenio = 20;
            int motor = 0;
            int quantidade = 0;

            string event_result;

            Mortes mortes = new Mortes();
            Random rand = new Random();
            Precos preco = new Precos();
            Evento evento = new Evento();
            Program game = new Program();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" _______ _______  ______  ______  _____       _______        _______ _______ _______");
            Console.WriteLine(" |       |_____| |_____/ |  ____ |     |      |______ |      |______ |______    |   ");
            Console.WriteLine(" |_____  |     | |    \\_ |_____| |_____|      |       |_____ |______ |______    |   ");
            Console.WriteLine("                                                                                    ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("   ____________________________");
            Console.WriteLine("      ||       ||     | \\\\ \\\\ \\\\________|_______________");
            Console.WriteLine("     //       =====  _ _     -----       ----------  o\\_________________________");
            Console.WriteLine(" < ))||    |´´´´´| | | | ================== |       o          /_______--------/");
            Console.WriteLine(" < ))\\\\_____________________________________________________________/");
            Console.WriteLine("      ||/\n");
            Console.WriteLine("\n[Enter]");
            Console.ReadKey();
            Console.Clear();
            while (vivo)
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("\nPreço do titânio:        E$" + Math.Round(preco_titanio, 2) + hist_titanio);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Preço do ouro:           E$" + Math.Round(preco_ouro, 2) + hist_ouro);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Preço do oxigenio:       E$" + Math.Round(preco_oxigenio, 2) + hist_oxigenio);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Preço do motor de dobra: E$" + Math.Round(preco_motor, 2) + hist_motor);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n_________________________________\n");
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("Seu titânio:           " + titanio);
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("Seu ouro:              " + ouro);
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Seu oxigênio:          " + oxigenio);
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("Seus motores de dobra: " + motor);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSeus guardas: " + game.guardas);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("___________________________________");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|                                 |_");
                Console.WriteLine("|          C - Comprar            | \\");
                Console.WriteLine("|          V - Vender             |] |");
                Console.WriteLine("|          E - Esperar            |_/");
                Console.WriteLine("|                                 |");
                Console.WriteLine("|_________________________________|");
                Console.WriteLine("|Seu dinheiro: E$" + Math.Round(dinheiro, 2));
                Console.WriteLine("|_____________________/\n");
                tipo = Console.ReadLine().ToUpper();
                Console.Clear();
                if (tipo == "E")
                {
                    hist_titanio = " ( Antes: E$" + Math.Round(preco_titanio, 2).ToString() + " )";
                    hist_ouro = " ( Antes: E$" + Math.Round(preco_ouro, 2).ToString() + " )";
                    hist_oxigenio = " ( Antes: E$" + Math.Round(preco_oxigenio, 2).ToString() + " )";
                    hist_motor = " ( Antes: E$" + Math.Round(preco_motor, 2).ToString() + " )";


                    Console.WriteLine("\n");
                    preco_titanio = preco.Titanio(preco_titanio);
                    preco_ouro = preco.Ouro(preco_ouro);
                    preco_oxigenio = preco.Oxigenio(preco_oxigenio);
                    preco_motor = preco.Motor(preco_motor);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n|||-- Custo de vida: -E$6 --|||");
                    dinheiro -= 6;
                    Console.WriteLine("|||-- Oxigênio: -1 --|||");
                    oxigenio -= 1;
                    if (game.guardas > 0)
                    {
                        Console.WriteLine("|||-- Salário do guarda: -E$2 --|||");
                        dinheiro -= 2;
                        Console.WriteLine($"|||-- Oxigênio do guarda: -{1 * game.guardas} --||");
                        oxigenio -= 1;
                    }
                    Console.ForegroundColor = ConsoleColor.White;
                    event_result = "";
                    if (rand.Next(1) == 0) // CHANCE DE EVENTO
                    {
                        event_result = evento.Gerar(game.guardas, titanio, ouro);
                        if (event_result == "-all ouro")
                        {
                            if (ouro <= 0)
                            {
                                Console.WriteLine("Você não tem nenhum ouro. Os piratas se enfurecem com a sua mentira e te dão um tiro.");
                                vivo = false;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n--GAME OVER--");
                                Console.WriteLine("Os piratas te mataram.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Você deu todo o seu ouro para os piratas, e eles te deixaram em paz.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine($"]] +E$0 [[ (-{ouro} ouro");
                                ouro = 0;
                            }
                        }
                        else if (event_result == "-all titanio")
                        {
                            if (titanio <= 0)
                            {
                                Console.WriteLine("Você não tem nenhum titânio. Os piratas se enfurecem com a sua mentira e te dão um tiro.");
                                vivo = false;
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n--GAME OVER--");
                                Console.WriteLine("Os piratas te mataram.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.WriteLine("Você deu todo o seu titânio para os piratas, e eles te deixaram em paz.");
                                Console.ReadKey();
                                Console.Clear();
                                Console.WriteLine($"]] +E$0 [[ (-{titanio} titanio");
                                titanio = 0;
                            }                       
                        }
                        else if (event_result == "lutar piratas")
                        {
                            vivo = evento.Luta(game.guardas, "piratas");
                            if (vivo == false)
                            {
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.WriteLine("\n--GAME OVER--");
                                Console.WriteLine("Os piratas te mataram.");
                                Console.ReadKey();
                            }
                            else
                            {
                                Console.Clear();
                            }
                        }
                    }
                }
                else if (tipo == "C")
                {
                    Console.WriteLine("=== COMPRAR ===\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Titânio [T]        (Possui: " + titanio + ") Preço: E$" + Math.Round(preco_titanio, 2));
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ouro [Au]          (Possui: " + ouro + ") Preço: E$" + Math.Round(preco_ouro, 2));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Oxigênio [O]       (Possui: " + oxigenio + ") Preço: E$" + Math.Round(preco_oxigenio, 2));
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Motor de dobra [M] (Possui: " + motor + ") Preço: E$" + Math.Round(preco_motor, 2));
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n=== CONTRATAR ===\n");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Guarda [G] (Possui: " + game.guardas + ") Salário: E$2/h");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Voltar: V");
                    Console.WriteLine("\n[Saldo: E$" + Math.Round(dinheiro, 2) + "]");
                    Console.WriteLine("Insira o tipo de recurso: (consulte acima)");
                    tipo = Console.ReadLine().ToUpper();
                    if (tipo == "T" || tipo == "AU" || tipo == "O" || tipo == "M" || tipo == "G")
                    {
                        Console.WriteLine("Insira a quantidade: ");
                        quantidade = int.Parse(Console.ReadLine());
                        switch (tipo)
                        {
                            case "T": Console.WriteLine("Isso vai custar E$" + Math.Round(preco_titanio * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); break;
                            case "AU": Console.WriteLine("Isso vai custar E$" + Math.Round(preco_ouro * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); break;
                            case "O": Console.WriteLine("Isso vai custar E$" + Math.Round(preco_oxigenio * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); break;
                            case "M": Console.WriteLine("Isso vai custar E$" + Math.Round(preco_motor * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); break;
                            case "G": Console.WriteLine("Isso vai custar E$" + 2 * quantidade + " por hora. Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); break;
                        }
                        S_N = Console.ReadLine().ToUpper();
                        Console.Clear();
                        if (S_N == "S")
                        {
                            switch (tipo)
                            {
                                case "T":
                                    titanio += quantidade; dinheiro -= preco_titanio * quantidade;
                                    Console.WriteLine("]] -E$" + Math.Round(preco_titanio * quantidade, 2) + " [[  (+" + quantidade + " Titânio)"); break;
                                case "AU":
                                    ouro += quantidade; dinheiro -= preco_ouro * quantidade;
                                    Console.WriteLine("]] -E$" + Math.Round(preco_ouro * quantidade, 2) + " [[  (+" + quantidade + " Ouro)"); break;
                                case "O":
                                    oxigenio += quantidade; dinheiro -= preco_oxigenio * quantidade;
                                    Console.WriteLine("]] -E$" + Math.Round(preco_oxigenio * quantidade, 2) + " [[  (+" + quantidade + " Oxigênio)"); break;
                                case "M":
                                    motor += quantidade; dinheiro -= preco_motor * quantidade;
                                    Console.WriteLine("]] -E$" + Math.Round(preco_motor * quantidade, 2) + " [[  (+" + quantidade + " Motor de dobra)"); break;
                                case "G":
                                    game.guardas += quantidade;
                                    Console.WriteLine("]] +1 guarda [["); break;
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                else if (tipo == "V")
                {
                    Console.WriteLine("=== VENDER ===\n");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("Titânio [T]        (Possui: " + titanio + ") Preço: E$" + Math.Round(preco_titanio, 2));
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("Ouro [Au]          (Possui: " + ouro + ") Preço: E$" + Math.Round(preco_ouro, 2));
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("Oxigênio [O]       (Possui: " + oxigenio + ") Preço: E$" + Math.Round(preco_oxigenio, 2));
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("Motor de dobra [M] (Possui: " + motor + ") Preço: E$" + Math.Round(preco_motor, 2));
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("Voltar: V");
                    Console.WriteLine("\n[Saldo: E$" + Math.Round(dinheiro, 2) + "]");
                    Console.WriteLine("Insira o tipo de recurso: (consulte acima)");
                    tipo = Console.ReadLine().ToUpper();
                    if (tipo == "T" || tipo == "AU" || tipo == "O" || tipo == "M")
                    {
                        Console.WriteLine("Insira a quantidade: ");
                        quantidade = int.Parse(Console.ReadLine());
                        switch (tipo)
                        {
                            case "T": if (titanio <= 0) { Console.WriteLine("Você não tem titânio (Enter)"); } else { if (quantidade > titanio) { quantidade = titanio; } Console.WriteLine("Você vai vender " + quantidade + " de titânio e receber " + Math.Round(preco_titanio * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); } break;
                            case "AU": if (ouro <= 0) { Console.WriteLine("Você não tem ouro (Enter)"); } else { if (quantidade > ouro) { quantidade = ouro; } Console.WriteLine("Você vai vender " + quantidade + " de ouro e receber " + Math.Round(preco_ouro * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); } break;
                            case "O": if (oxigenio <= 0) { Console.WriteLine("Você não tem oxigênio (Enter)"); } else { if (quantidade > oxigenio) { quantidade = oxigenio; } Console.WriteLine("Você vai vender " + quantidade + " de oxigênio e receber " + Math.Round(preco_oxigenio * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); } break;
                            case "M": if (motor <= 0) { Console.WriteLine("Você não tem motores de dobra (Enter)"); } else { if (quantidade > motor) { quantidade = motor; } Console.WriteLine("Você vai vender " + quantidade + " motor(es) de dobra e receber " + Math.Round(preco_motor * quantidade, 2) + ". Tem certeza? (S/N) [Saldo: E$" + Math.Round(dinheiro, 2) + "]"); } break;
                        }
                        S_N = Console.ReadLine().ToUpper();
                        Console.Clear();
                        if (S_N == "S")
                        {
                            switch (tipo)
                            {
                                case "T":
                                    titanio -= quantidade; dinheiro += preco_titanio * quantidade;
                                    Console.WriteLine("]] +E$" + Math.Round(preco_titanio * quantidade, 2) + " [[  (-" + quantidade + " Titânio)"); break;
                                case "AU":
                                    ouro -= quantidade; dinheiro += preco_ouro * quantidade;
                                    Console.WriteLine("]] +E$" + Math.Round(preco_ouro * quantidade, 2) + " [[  (-" + quantidade + " Ouro)"); break;
                                case "O":
                                    oxigenio -= quantidade; dinheiro += preco_oxigenio * quantidade;
                                    Console.WriteLine("]] +E$" + Math.Round(preco_oxigenio * quantidade, 2) + " [[  (-" + quantidade + " Oxigênio)"); break;
                                case "M":
                                    motor -= quantidade; dinheiro += preco_motor * quantidade;
                                    Console.WriteLine("]] +E$" + Math.Round(preco_motor * quantidade, 2) + " [[  (-" + quantidade + " Motor de dobra)"); break;
                            }
                        }
                    }
                    else
                    {
                        Console.Clear();
                    }
                }
                if (vivo == true)
                {
                    vivo = mortes.Verificar(oxigenio);
                }
            }
        }
    }
}
