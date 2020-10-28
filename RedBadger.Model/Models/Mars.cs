using System;
using System.Collections.Generic;
using System.Text;

namespace RedBadger.Model.Models
{
    public class Mars
    {
        public int X { get; set; }
        public int Y { get; set; }

        private HashSet<string> _scentCheck;

        public HashSet<string> ScentCheck
        {
            get
            {
                if (_scentCheck == null)
                {
                    _scentCheck = new HashSet<string>();
                }
                return _scentCheck;
            }
        }
    }
}
