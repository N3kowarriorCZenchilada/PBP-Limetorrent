using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeTorrentScraper
{
    public class ProgramClass
    {
        public static void Main(string[] args)
        {
            string gameUrl;
            string tittle;
            
            string userinput = args[0];
            ScraperClasses scraperRun = new ScraperClasses();
            string gameUrlAndTittle = scraperRun.getResaultUrl(userinput);
            //gameUrl = gameUrlAndTittle.Remove(gameUrlAndTittle.LastIndexOf(dunno)+1);
            //gameUrl = gameUrl.Remove(0, 1)
        }
    }
}