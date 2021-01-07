using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = "Blablaland skin changer by nikolatesla";
            StreamManip.LoadSkins();
            StreamManip.LoadProxies();
            Blablaland acc = new Blablaland("kyOkvtElyaD9Wu55UsA6twBB7MEds6t8phtnFT77c615BQP1"); // the cookie named BBL_AUTH_SESSION
        }
    }
}
