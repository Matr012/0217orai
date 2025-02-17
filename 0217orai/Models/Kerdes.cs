using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0217orai.Models
{
    internal class Kerdes
    {
        public string KerdesSzovege { get; set; }
        public string ValaszA { get; set; }
        public string ValaszB { get; set; }
        public string ValaszC { get; set; }
        public int HelyesValasz { get; set; }
       

        public Kerdes(string kerdesSzovege, string valasza, string valaszb, string valaszc, int helyesValasz)
        {
            KerdesSzovege = kerdesSzovege;
            ValaszA = valasza;
            ValaszB = valaszb;
            ValaszC = valaszc;
            HelyesValasz = helyesValasz;
            
        }
    }

}
