using System;
using System.ComponentModel.Design;

namespace DanielsHunter
{
    internal class DirectionMenager
    {
        internal static (int, int) GetDirection()
        {
            ConsoleKey key;
            (int?, int?) direction;
            do
            {
                key = Console.ReadKey(true).Key;
                direction = key switch
                {
                    ConsoleKey.NumPad1 => (-1, +1),
                    ConsoleKey.NumPad2 => (0, +1),
                    ConsoleKey.NumPad3 => (+1, +1),
                    ConsoleKey.NumPad4 => (-1,0),
                    ConsoleKey.NumPad6 => (+1,0),
                    ConsoleKey.NumPad5 => (0,0),
                    ConsoleKey.NumPad7 => (-1,-1),
                    ConsoleKey.NumPad8 => (0,-1),
                    ConsoleKey.NumPad9 => (+1,-1),
                    _ => (null, null)
                };
            } while (direction == (null, null));
            return (Convert.ToInt32(direction.Item1), Convert.ToInt32(direction.Item2));
        }
    }
}