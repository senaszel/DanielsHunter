using System;

namespace DanielsHunter.App.Common
{
    internal class DirectionMenager
    {
        internal static (int, int) PassDirection(ConsoleKey key)
        {
            (int?, int?) direction;
            do
            {
                direction = key switch
                {
                    ConsoleKey.NumPad1 => (-1, +1),
                    ConsoleKey.NumPad2 => (0, +1),
                    ConsoleKey.NumPad3 => (+1, +1),
                    ConsoleKey.NumPad4 => (-1, 0),
                    ConsoleKey.NumPad6 => (+1, 0),
                    ConsoleKey.NumPad5 => (0, 0),
                    ConsoleKey.NumPad7 => (-1, -1),
                    ConsoleKey.NumPad8 => (0, -1),
                    ConsoleKey.NumPad9 => (+1, -1),
                    _ => (null, null)
                };
            } while (direction == (null, null));
            return (Convert.ToInt32(direction.Item1), Convert.ToInt32(direction.Item2));
        }

        internal static (int, int) GetDirection()
        {
            ConsoleKey key;
            (int?, int?) direction;
            do
            {
                key = Console.ReadKey(true).Key;
                direction = PassDirection(key);
            } while (direction == (null, null));
            return (Convert.ToInt32(direction.Item1), Convert.ToInt32(direction.Item2));
        }

        public static ConsoleKey ConvertIntToConsoleKey(int source)
        {
            ConsoleKey result = source switch
            {
                1 => ConsoleKey.NumPad1,
                2 => ConsoleKey.NumPad2,
                3 => ConsoleKey.NumPad3,
                4 => ConsoleKey.NumPad4,
                5 => ConsoleKey.NumPad5,
                6 => ConsoleKey.NumPad6,
                7 => ConsoleKey.NumPad7,
                8 => ConsoleKey.NumPad8,
                9 => ConsoleKey.NumPad9,
            };
            return result;
        }
    }
}