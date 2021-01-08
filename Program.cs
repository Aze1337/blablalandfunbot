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
            Blablaland acc = new Blablaland("O8H9kQDYeA5p6Ub7xd1tmPmF3qGymmWhqRlwjA1nUsa2az7N"); // the cookie named BBL_AUTH_SESSION
        }
    }
}
