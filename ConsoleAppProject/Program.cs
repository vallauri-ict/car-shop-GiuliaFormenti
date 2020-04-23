using System;
using VenditaVeicoliDLLProject;

namespace ConsoleAppProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("*** SALONE VENDITA VEICOLI NUOVI E USATI ***");
            Moto m = new Moto();
            Console.WriteLine(m);

            Auto a = new Auto();
            Console.WriteLine(a);
        }
    }
}
