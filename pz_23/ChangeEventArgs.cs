using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pz_23
{
    internal class ChangeEventArgs : EventArgs
    {
        public string Advertisement {  get; set; }

        public ChangeEventArgs(string advertisement)
        {
            Advertisement = advertisement;
        }

        public override string ToString()
        {
            return Advertisement;
        }
    }
}
