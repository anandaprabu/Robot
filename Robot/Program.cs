using System;

class ToyRobotSimulator
{
    static void Main()
    {
        ToyRobot robot = new ToyRobot();

        while (true)
        {
            Console.Write("Enter command: ");
            string input = Console.ReadLine().Trim().ToUpper();

            if (input == "EXIT")
            {
                break;
            }

            string[] commandParts = input.Split(' ');

            if (commandParts.Length > 0)
            {
                string command = commandParts[0];

                switch (command)
                {
                    case "PLACE":
                        if (commandParts.Length == 4)
                        {
                            int x, y;
                            if (int.TryParse(commandParts[1], out x) && int.TryParse(commandParts[2], out y))
                            {
                                robot.Place(x, y, commandParts[3]);
                            }
                            else
                            {
                                Console.WriteLine("Invalid PLACE command. Please use: PLACE X Y F");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid PLACE command. Please use: PLACE X Y F");
                        }
                        break;

                    case "MOVE":
                        robot.Move();
                        break;

                    case "LEFT":
                        robot.Left();
                        break;

                    case "RIGHT":
                        robot.Right();
                        break;

                    case "REPORT":
                        robot.Report();
                        break;

                    default:
                        Console.WriteLine("Invalid command. Valid commands: PLACE, MOVE, LEFT, RIGHT, REPORT, EXIT");
                        break;
                }
            }
        }
    }
}

class ToyRobot
{
    private int x;
    private int y;
    private string direction;
    private static readonly int tableSize = 5;

    public void Place(int newX, int newY, string newDirection)
    {
        if (IsValidPosition(newX, newY))
        {
            x = newX;
            y = newY;
            direction = newDirection;
        }
        else
        {
            Console.WriteLine("Invalid placement. Robot must be placed within the 5x5 tabletop.");
        }
    }

    public void Move()
    {
        int newX = x;
        int newY = y;

        switch (direction)
        {
            case "N":
                newY++;
                break;

            case "S":
                newY--;
                break;

            case "E":
                newX++;
                break;

            case "W":
                newX--;
                break;
        }

        if (IsValidPosition(newX, newY))
        {
            x = newX;
            y = newY;
        }
        else
        {
            Console.WriteLine("Invalid move. Robot must stay within the 5x5 tabletop.");
        }
    }

    public void Left()
    {
        switch (direction)
        {
            case "N":
                direction = "W";
                break;

            case "S":
                direction = "E";
                break;

            case "E":
                direction = "N";
                break;

            case "W":
                direction = "S";
                break;
        }
    }

    public void Right()
    {
        switch (direction)
        {
            case "N":
                direction = "E";
                break;

            case "S":
                direction = "W";
                break;

            case "E":
                direction = "S";
                break;

            case "W":
                direction = "N";
                break;
        }
    }

    public void Report()
    {
        Console.WriteLine($"Robot is at ({x},{y}) facing {direction}");
    }

    private bool IsValidPosition(int newX, int newY)
    {
        return newX >= 0 && newX < tableSize && newY >= 0 && newY < tableSize;
    }
}




