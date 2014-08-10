using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ConvertorClient
{
    public class cRates
    {
        public string Prefix { get; set; }
        public double Amount { get; set; }
        
        public cRates()
        {
            Prefix = null;
            Amount = 0.0;
           
        }
    }
}