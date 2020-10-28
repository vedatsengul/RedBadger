using System;
using System.Collections.Generic;
using System.Text;

namespace RedBadger.Model.Models
{
    public class Robot
    {
        public int X { get; set; }
        public int Y { get; set; }
        public string Direction { get; set; }
        public bool IsLost { get; set; }
        public string PrintLocation()
        {
            return X + " " + Y + " " + Direction + (IsLost ? " LOST" : string.Empty);
        }
    }
}
