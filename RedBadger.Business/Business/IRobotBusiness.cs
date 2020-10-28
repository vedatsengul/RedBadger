using RedBadger.Model.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace RedBadger.Business.Business
{
    public interface IRobotBusiness
    {
        void MoveRobot(Mars planet, Robot robot, string command);
    }
}
