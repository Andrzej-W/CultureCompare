using CultureCompare.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CultureCompare.Client
{
    public class TwoCultures
    {
        public CultureDTO server;
        public CultureDTO client;
        public bool visible;
        public TwoCultures(CultureDTO server, CultureDTO client)
        {
            this.server = server;
            this.client = client;
        }
    }
}
