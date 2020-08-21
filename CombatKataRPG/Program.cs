using System;
using System.Collections.Generic;
using CombatKataRPG.Commons.Models;

namespace CombatKataRPG
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting a Combat");

            var player = new Character("Player1");
            var things = new List<Thing>{
                new Thing(),
                new Thing(),
                new Thing()
            };

            player.DealDamage(things, 200);
        }
    }
}
