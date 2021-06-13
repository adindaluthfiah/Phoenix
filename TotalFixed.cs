using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBisnis
{
   public class TotalFixed
    {
        private double _fixed;

        public double Fixed
        {
           get{return _fixed; }
           set{_fixed = value;}
        }
        public TotalFixed() { }
    }
}
