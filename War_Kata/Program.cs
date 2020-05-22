using System;

namespace War_Kata
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Let's play a game called war!");
            War_Game Game = new War_Game();
            Game.Play_Game(null);       //Parameter is null because we want a clean randomized deck

        }
    }
}
