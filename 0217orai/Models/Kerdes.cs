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
        public string HelyesValasz { get; set; }
       
        public string? FelhValasz { get; set; }

        public Kerdes(string kerdesSzovege, string valasza, string valaszb, string valaszc, string helyesValasz)
        {
            KerdesSzovege = kerdesSzovege;
            ValaszA = valasza;
            ValaszB = valaszb;
            ValaszC = valaszc;
            HelyesValasz = helyesValasz;
            
        }
        public bool ValaszEllenorzes()
        {
            if (FelhValasz == null)
            {
                return false;
            }
            if (FelhValasz == HelyesValasz)
            {
                return true;
            }
            return false;
        }
    }

}
