using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day19
    {
        public static string Part1(string input)
        {
            var rows = input.Split(Environment.NewLine).ToList();
            var letters = new List<char>();
            int maxLength = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                maxLength = Math.Max(rows[i].Length, maxLength);
            }
            char[,] grid = new char[rows.Count, maxLength];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    grid[i, j] = rows[i][j];
                }
            }

            var direction = Direction.Down;
            var position = new Point(rows[0].IndexOf('|'), 0);
            while (true)
            {
                position = GetNextPoint(position, direction);
                var nextChar = grid[position.Y, position.X];
                if (nextChar == '|' || nextChar == '-')
                {
                    continue;
                }
                if (char.IsLetter(nextChar))
                {
                    letters.Add(nextChar);
                    continue;
                }

                if (nextChar == '+')
                {
                    direction = GetNextDirection(position, direction, grid);
                    continue;
                }

                return string.Join("", letters);
            }
        }

        private static Direction GetNextDirection(Point position, Direction direction, char[,] grid)
        {
            if (direction == Direction.Up || direction == Direction.Down)
            {
                if (grid[position.Y, position.X - 1] == '-' || char.IsLetter(grid[position.Y, position.X - 1]))
                {
                    return Direction.Left;
                }

                if (grid[position.Y, position.X + 1] == '-' || char.IsLetter(grid[position.Y, position.X + 1]))
                {
                    return Direction.Right;
                }
            }

            if (direction == Direction.Left || direction == Direction.Right)
            {
                if (grid[position.Y - 1, position.X] == '|' || char.IsLetter(grid[position.Y - 1, position.X]))
                {
                    return Direction.Up;
                }

                if (grid[position.Y + 1, position.X] == '|' || char.IsLetter(grid[position.Y + 1, position.X]))
                {
                    return Direction.Down;
                }
            }
            throw new InvalidOperationException();
        }

        private static Point GetNextPoint(Point pos, Direction direction)
        {
            switch (direction)
            {
                case Direction.Down:
                    return new Point(pos.X, pos.Y + 1);
                case Direction.Up:
                    return new Point(pos.X, pos.Y - 1);
                case Direction.Left:
                    return new Point(pos.X - 1, pos.Y);
                case Direction.Right:
                    return new Point(pos.X + 1, pos.Y);
                default:
                    throw new InvalidOperationException();
            }
        }
        public enum Direction
        {
            Down,
            Up,
            Left,
            Right
        }

        public static int Part2(string input)
        {
            var rows = input.Split(Environment.NewLine).ToList();
            var steps = 0;
            int maxLength = 0;
            for (int i = 0; i < rows.Count; i++)
            {
                maxLength = Math.Max(rows[i].Length, maxLength);
            }
            char[,] grid = new char[rows.Count, maxLength];
            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows[i].Length; j++)
                {
                    grid[i, j] = rows[i][j];
                }
            }

            var direction = Direction.Down;
            var position = new Point(rows[0].IndexOf('|'), 0);
            steps++;
            while (true)
            {
                position = GetNextPoint(position, direction);
                var nextChar = grid[position.Y, position.X];
                if (nextChar == '|' || nextChar == '-')
                {
                    steps++;
                    continue;
                }
                if (char.IsLetter(nextChar))
                {
                    steps++;
                    continue;
                }

                if (nextChar == '+')
                {
                    direction = GetNextDirection(position, direction, grid);
                    steps++;
                    continue;
                }

                return steps;
            }
        }

        public static void Run()
        {
            Console.WriteLine();
            var day = MethodBase.GetCurrentMethod().DeclaringType.Name;
            Console.WriteLine(day);
            try
            {
                var input = File.ReadAllText($"{day}.txt");
                Console.WriteLine($"{nameof(Part1)}: {Part1(input)}");
                Console.WriteLine($"{nameof(Part2)}: {Part2(input)}");
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Could not find input file!");
            }
        }
    }
}
