using System;
using System.Collections.Generic;
using System.Text;

namespace Mars_Rover
{
    public class Coordinates
    {
        public int X { get; set; }
        public int Y { get; set; }
    }
    public class RoverPosition : Coordinates
    {
        public EnumDirection Direction { get; set; }

        public RoverPosition()
        {
            X = 0;
            Y = 0;
            Direction = EnumDirection.N;
        }
    }
    public enum EnumDirection
    {
        N,
        S,
        E,
        W
    }

    public static class Calculate
    {
        private static RoverPosition MoveForward(RoverPosition position)
        {
            switch (position.Direction)
            {
                case EnumDirection.N:
                    position.Y += 1;
                    break;
                case EnumDirection.S:
                    position.Y -= 1;
                    break;
                case EnumDirection.E:
                    position.X += 1;
                    break;
                case EnumDirection.W:
                    position.X -= 1;
                    break;
                default:
                    break;
            }
            return position;
        }
        private static RoverPosition RotateL(RoverPosition position)
        {
            switch (position.Direction)
            {
                case EnumDirection.N:
                    position.Direction = EnumDirection.W;
                    break;
                case EnumDirection.S:
                    position.Direction = EnumDirection.E;
                    break;
                case EnumDirection.E:
                    position.Direction = EnumDirection.N;
                    break;
                case EnumDirection.W:
                    position.Direction = EnumDirection.S;
                    break;
                default:
                    break;
            }
            return position;
        }
        private static RoverPosition RotateR(RoverPosition position)
        {
            switch (position.Direction)
            {
                case EnumDirection.N:
                    position.Direction = EnumDirection.E;
                    break;
                case EnumDirection.S:
                    position.Direction = EnumDirection.W;
                    break;
                case EnumDirection.E:
                    position.Direction = EnumDirection.S;
                    break;
                case EnumDirection.W:
                    position.Direction = EnumDirection.N;
                    break;
                default:
                    break;
            }
            return position;
        }
        public static RoverPosition CalculateNewPosition(Coordinates _startPosition, RoverPosition roverPosition, string orientation)
        {
            foreach (var item in orientation)
            {
                switch (item)
                {
                    case 'L':
                        roverPosition = RotateL(roverPosition);
                        break;
                    case 'R':
                        roverPosition = RotateR(roverPosition);
                        break;
                    case 'M':
                        roverPosition = MoveForward(roverPosition);
                        break;
                    default:
                        Console.WriteLine("Wrong character");
                        break;
                }
            }
            return roverPosition;
        }
    }
}
