using NUnit.Framework;
using RedBadger.Business.Business;
using RedBadger.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBadger.Test
{
    public class RobotBusinessTest
    {
        [Test]
        public void MoveRobot_ShouldMove()
        {
            var robotBusiness = new RobotBusiness();
            Mars planet = new Mars()
            {
                X = 5,
                Y = 3
            };

            Robot robot1 = new Robot()
            {
                X = 1,
                Y = 1,
                Direction = "E"
            };

            robotBusiness.MoveRobot(planet, robot1, "R");
            robotBusiness.MoveRobot(planet, robot1, "F");
            robotBusiness.MoveRobot(planet, robot1, "R");
            robotBusiness.MoveRobot(planet, robot1, "F");
            robotBusiness.MoveRobot(planet, robot1, "R");
            robotBusiness.MoveRobot(planet, robot1, "F");
            robotBusiness.MoveRobot(planet, robot1, "R");
            robotBusiness.MoveRobot(planet, robot1, "F");

            Robot robot2 = new Robot()
            {
                X = 3,
                Y = 2,
                Direction = "N"
            };

            robotBusiness.MoveRobot(planet, robot2, "F");
            robotBusiness.MoveRobot(planet, robot2, "R");
            robotBusiness.MoveRobot(planet, robot2, "R");
            robotBusiness.MoveRobot(planet, robot2, "F");
            robotBusiness.MoveRobot(planet, robot2, "L");
            robotBusiness.MoveRobot(planet, robot2, "L");
            robotBusiness.MoveRobot(planet, robot2, "F");
            robotBusiness.MoveRobot(planet, robot2, "F");
            robotBusiness.MoveRobot(planet, robot2, "R");
            robotBusiness.MoveRobot(planet, robot2, "R");
            robotBusiness.MoveRobot(planet, robot2, "F");
            robotBusiness.MoveRobot(planet, robot2, "L");
            robotBusiness.MoveRobot(planet, robot2, "L");

            Robot robot3 = new Robot()
            {
                X = 0,
                Y = 3,
                Direction = "W"
            };

            robotBusiness.MoveRobot(planet, robot3, "L");
            robotBusiness.MoveRobot(planet, robot3, "L");
            robotBusiness.MoveRobot(planet, robot3, "F");
            robotBusiness.MoveRobot(planet, robot3, "F");
            robotBusiness.MoveRobot(planet, robot3, "F");
            robotBusiness.MoveRobot(planet, robot3, "L");
            robotBusiness.MoveRobot(planet, robot3, "F");
            robotBusiness.MoveRobot(planet, robot3, "L");
            robotBusiness.MoveRobot(planet, robot3, "F");
            robotBusiness.MoveRobot(planet, robot3, "L");

            Assert.IsTrue("1 1 E" == robot1.PrintLocation());
            Assert.IsTrue("3 3 N LOST" == robot2.PrintLocation());
            Assert.IsTrue("2 3 S" == robot3.PrintLocation());
        }
    }
}
