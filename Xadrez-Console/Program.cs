using System;
using tabuleiro;

namespace Xadrez_Console
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Posicao p;
            Console.WriteLine("Hello World!");
            p = new Posicao(3,4);
            Console.WriteLine("Posicao: " + p);
        }
    }
}
