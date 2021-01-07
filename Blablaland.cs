using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.IO;

namespace ConsoleApp1
{
    class Blablaland
    {
        private string sessionId; // sessionId 
        private CookieContainer cookies = new CookieContainer();
        private Random randomNum = new Random();
        public Blablaland(string authCookie)
        {
            Cookie cookie = new Cookie("BBL_AUTH_SESSION", authCookie);
            cookie.Domain = "blablaland.fun";
            cookies.Add(cookie);
            GetSessionId();




            while (true)
            {
                ChangeSkin();
                System.Threading.Thread.Sleep(1000);
            }
        }

        private void GetSessionId()
        {
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://blablaland.fun/");
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";
            req.CookieContainer = cookies;


            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string response = reader.ReadToEnd();
                    int position = response.IndexOf("sessionId");
                    position = response.IndexOf(":", position);
                    position = response.IndexOf('"', position) + 1;
                    int secondPos = response.IndexOf('"', position);
                    sessionId = response.Substring(position, (secondPos - position));
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void ChangeSkin()
        {
            int randomSkinId = Convert.ToInt32(StreamManip.skins[randomNum.Next(0,StreamManip.skins.Count)]);
            HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create("https://blablaland.fun/scripts/profil/setSkinData.php?SKINID=" + randomSkinId + "&SESSION=" + sessionId + "&CACHE=1609802541237&SKINCOLOR=%3BQFZHFQMD");
            req.Method = "GET";
            req.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/87.0.4280.88 Safari/537.36";
            req.CookieContainer = cookies;
            req.Referer = "https://blablaland.fun/account?p=1";
            req.Headers.Add("X-Requested-With", "ShockwaveFlash/32.0.0.465");
            req.Proxy = new WebProxy(StreamManip.proxies[randomNum.Next(0, StreamManip.proxies.Count)]);
            req.Timeout = 3000;
            try
            {
                HttpWebResponse resp = (HttpWebResponse)req.GetResponse();
                using (StreamReader reader = new StreamReader(resp.GetResponseStream()))
                {
                    string response = reader.ReadToEnd();
                    if (response.Contains("RESULT=1"))
                    {
                        Console.WriteLine("changed skin to " + randomSkinId);
                    }
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

    }
}
