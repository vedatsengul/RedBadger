using RedBadger.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBadger.Business.Business
{
    public class RobotBusiness : IRobotBusiness
    {
        public void MoveRobot(Mars planet, Robot robot, string command)
        {
            if (robot.IsLost)
            {
                return;
            }

            switch (command)
            {
                case "R":
                    RotateRight(robot);
                    break;
                case "L":
                    RotateLeft(robot);
                    break;
                case "F":
                    MoveForward(planet, robot);
                    break;
                default:
                    throw new Exception("Unknown Command");
            }
        }

        #region Move Robot

        private void MoveForward(Mars planet, Robot robot)
        {
            switch (robot.Direction)
            {
                case "N":
                    MoveNorth(planet, robot);
                    break;
                case "W":
                    MoveWest(planet, robot);
                    break;
                case "S":
                    MoveSouth(planet, robot);
                    break;
                case "E":
                    MoveEast(planet, robot);
                    break;
                default:
                    throw new Exception("Unknown Direction");
            }
        }

        private void MoveNorth(Mars planet, Robot robot)
        {
            int newY = robot.Y + 1;

            if (planet.ScentCheck.Contains(robot.X + "," + newY))
            {
                return;
            }

            if (newY > planet.Y)
            {
                planet.ScentCheck.Add(robot.X + "," + newY);
                robot.IsLost = true;
                return;
            }

            robot.Y = newY;
        }

        private void MoveWest(Mars planet, Robot robot)
        {
            int newX = robot.X - 1;

            if (planet.ScentCheck.Contains(newX + "," + robot.Y))
            {
                return;
            }

            if (newX < 0)
            {
                planet.ScentCheck.Add(newX + "," + robot.Y);
                robot.IsLost = true;
                return;
            }

            robot.X = newX;
        }

        private void MoveSouth(Mars planet, Robot robot)
        {
            int newY = robot.Y - 1;

            if (planet.ScentCheck.Contains(robot.X + "," + newY))
            {
                return;
            }

            if (newY < 0)
            {
                planet.ScentCheck.Add(robot.X + "," + newY);
                robot.IsLost = true;
                return;
            }

            robot.Y = newY;
        }

        private void MoveEast(Mars planet, Robot robot)
        {
            int newX = robot.X + 1;

            if (planet.ScentCheck.Contains(newX + "," + robot.Y))
            {
                return;
            }

            if (newX > planet.X)
            {
                planet.ScentCheck.Add(newX + "," + robot.Y);
                robot.IsLost = true;
                return;
            }

            robot.X = newX;
        }

        #endregion

        private void RotateLeft(Robot robot)
        {
            switch (robot.Direction)
            {
                case "N":
                    robot.Direction = "W";
                    break;
                case "W":
                    robot.Direction = "S";
                    break;
                case "S":
                    robot.Direction = "E";
                    break;
                case "E":
                    robot.Direction = "N";
                    break;
                default:
                    throw new Exception("Unknown Direction");
            }
        }

        private void RotateRight(Robot robot)
        {
            switch (robot.Direction)
            {
                case "N":
                    robot.Direction = "E";
                    break;
                case "E":
                    robot.Direction = "S";
                    break;
                case "S":
                    robot.Direction = "W";
                    break;
                case "W":
                    robot.Direction = "N";
                    break;
                default:
                    throw new Exception("Unknown Direction");
            }
        }
    }
}
