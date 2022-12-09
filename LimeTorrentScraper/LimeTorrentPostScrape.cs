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
            string userinput = args[0];
            ScraperClasses scraperClasses = new ScraperClasses();

            //running search
            string gameUrlAndTittle = scraperClasses.getResaultUrl(userinput);
            string gameUrl;
            string magnetUrl;
            string torrentUrl;  
            string title;

            //Getting url of searched game from string with name and url in ""
            gameUrl = gameUrlAndTittle.Remove(gameUrlAndTittle.LastIndexOf('"') + 1);
            gameUrl = gameUrl.Replace(char.ToString('"'), string.Empty);
            gameUrl = gameUrl.Remove(0, 1);
            
            //Getting game title of searched game form string with name and url in""
            title = gameUrlAndTittle.Substring(gameUrlAndTittle.LastIndexOf('"'));
            title = title.Remove(0, 1);

            //Getting game's link from game url
            torrentUrl = scraperClasses.getTorrentUrl(gameUrl);
            magnetUrl = scraperClasses.getMagnetUrl(gameUrl);


        
        }
    }
}