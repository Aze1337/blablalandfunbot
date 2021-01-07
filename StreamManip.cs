using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleApp1
{
    class StreamManip
    {
        public static List<string> proxies = new List<string>();
        public static List<string> skins = new List<string>();



        public static void LoadProxies()
        {
            using (StreamReader reader = new StreamReader("proxies.txt"))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    proxies.Add(line);
                }
                Console.WriteLine("Successfully loaded " + proxies.Count + " proxies");
            }
        }


        public static void LoadSkins()
        {
            using (StreamReader reader = new StreamReader("skins.txt"))
            {
                string line = "";
                while ((line = reader.ReadLine()) != null)
                {
                    skins.Add(line);
                }
                Console.WriteLine("Successfully loaded " + skins.Count + " skins");
            }
        }




       
    }
}
