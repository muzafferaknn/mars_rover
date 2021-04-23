using System;
using System.Collections.Generic;

namespace Mars_Rover
{
    class Program
    {
        static void Main(string[] args)
        {
            Coordinates upper_right = new Coordinates();
            Console.Write("Enter upper-right coordinates : ");
            string start_position = Console.ReadLine();
            if (start_position.Split(' ').Length == 2)
            {
                upper_right.X = Convert.ToInt32(start_position.Split(' ')[0]);
                upper_right.Y = Convert.ToInt32(start_position.Split(' ')[1]);
            }
            else
            {
                Console.WriteLine("Wrong coordinates");
                return;
            }
            Console.WriteLine("--------------------- ~ ---------------------");
            while (true)
            {
                Console.Write("Enter rover coordination and position : ");
                string rover = Console.ReadLine();
                Console.Write("Enter rover's orientation : ");
                string orientation = Console.ReadLine();
                if (rover.Split(' ').Length == 3)
                {
                    RoverPosition position = new RoverPosition();
                    position.X = Convert.ToInt32(rover.Split(' ')[0]);
                    position.Y = Convert.ToInt32(rover.Split(' ')[1]);
                    position.Direction = (EnumDirection)Enum.Parse(typeof(EnumDirection), rover.Split(' ')[2].ToUpper());


                    position = Calculate.CalculateNewPosition(upper_right, position, orientation.ToUpper());

                    if (position.X < 0 || position.Y < 0 || position.X > upper_right.X || position.Y > upper_right.Y)
                        Console.WriteLine($"Rover position must be between (0,0) and ({upper_right.X},{upper_right.Y})");
                    else
                        Console.WriteLine($"New coordination and position : ({position.X},{position.Y}) {position.Direction}");
                }
                else
                {
                    Console.WriteLine("Wrong coordination and position");
                    return;
                }
                Console.WriteLine("--------------------- ~ ---------------------");

            }
        }
    }
}
