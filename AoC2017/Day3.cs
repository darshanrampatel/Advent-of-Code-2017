using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace AoC2017
{
    public static class Day3
    {
        public static int Part1(int input)
        {
            var currentPosition = new Point(0, 0);
            var currentValue = 1;
            var currentDirection = Directions.Down;//since the next direction is Right
            var currentCount = 0;

            var positions = new Dictionary<Point, int>
            {
                { currentPosition, currentValue }
            };
            currentValue++;
            while (currentValue < input)
            {
                var (nextDirection, nextCount) = GetNextStep(currentDirection, currentCount);
                currentDirection = nextDirection;
                currentCount = nextCount;

                while (nextCount > 0)
                {
                    currentPosition = GetNextPosition(currentPosition, nextDirection);
                    positions.Add(currentPosition, currentValue);
                    currentValue++;
                    nextCount--;
                }
            }

            var targetPosition = positions.FirstOrDefault(p => p.Value == input).Key;
            return Math.Abs(targetPosition.X) + Math.Abs(targetPosition.Y);
        }

        enum Directions
        {
            Right = 0,
            Up = 1,
            Left = 2,
            Down = 3
        }

        private static (Directions nextDirection, int nextCount) GetNextStep(Directions currentDirection, int currentCount)
        {
            switch (currentDirection)
            {
                case Directions.Right:
                    return (Directions.Up, currentCount);
                case Directions.Up:
                    return (Directions.Left, currentCount + 1);
                case Directions.Left:
                    return (Directions.Down, currentCount);
                case Directions.Down:
                    return (Directions.Right, currentCount + 1);
                default:
                    throw new InvalidOperationException();
            }
        }

        private static Point GetNextPosition(Point position, Directions direction)
        {
            switch (direction)
            {
                case Directions.Right:
                    position.X++;
                    return position;
                case Directions.Up:
                    position.Y++;
                    return position;
                case Directions.Left:
                    position.X--;
                    return position;
                case Directions.Down:
                    position.Y--;
                    return position;
                default:
                    throw new InvalidOperationException();
            }
        }


        public static int Part2(int input)
        {
            var currentPosition = new Point(0, 0);
            var currentValue = 1;
            var currentDirection = Directions.Down;//since the next direction is Right
            var currentCount = 0;

            var positions = new Dictionary<Point, int>
            {
                { currentPosition, currentValue }
            };
            currentValue++;
            while (currentValue < input)
            {
                var (nextDirection, nextCount) = GetNextStep(currentDirection, currentCount);
                currentDirection = nextDirection;
                currentCount = nextCount;

                while (nextCount > 0 && currentValue < input)
                {
                    currentPosition = GetNextPosition(currentPosition, nextDirection);
                    currentValue = GetAdjacentSum(currentPosition, positions);
                    positions.Add(currentPosition, currentValue);
                    nextCount--;
                }
            }
            return currentValue;
        }

        private static int GetAdjacentSum(Point currentPosition, Dictionary<Point, int> positions)
        {
            var topLeft = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X - 1, currentPosition.Y - 1));
            var topCentre = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X, currentPosition.Y - 1));
            var topRight = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X + 1, currentPosition.Y - 1));
            var left = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X - 1, currentPosition.Y));
            var right = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X + 1, currentPosition.Y));
            var bottomLeft = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X - 1, currentPosition.Y + 1));
            var bottomCentre = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X, currentPosition.Y + 1));
            var bottomRight = positions.FirstOrDefault(p => p.Key == new Point(currentPosition.X + 1, currentPosition.Y + 1));

            return topLeft.Value + topCentre.Value + topRight.Value + left.Value + right.Value + bottomLeft.Value + bottomCentre.Value + bottomRight.Value;
        }

        public static void Run()
        {
            Console.WriteLine();
            var day = MethodBase.GetCurrentMethod().DeclaringType.Name;
            Console.WriteLine(day);
            try
            {
                Int32.TryParse(File.ReadAllText($"{day}.txt"), out int input);
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
