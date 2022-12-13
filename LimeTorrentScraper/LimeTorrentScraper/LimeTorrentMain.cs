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
            if (args[0] != null)
            {
                string userinput = args[0];
                ScraperClasses scraperClasses = new ScraperClasses();
                //running search
                string gameUrlAndTittle = scraperClasses.getResaultUrl(userinput);
                string gameUrl;
                string magnetUrl;
                string torrentUrl;
                string title;

                if (gameUrlAndTittle != null)
                {
                    //Getting url of searched game from string with name and url in ""
                    gameUrl = gameUrlAndTittle.Remove(gameUrlAndTittle.LastIndexOf('"') + 1);
                    gameUrl = gameUrl.Replace(char.ToString('"'), string.Empty);
                    gameUrl = gameUrl.Remove(0, 1);

                    //Getting game title of searched game from string with name and url in""
                    title = gameUrlAndTittle.Substring(gameUrlAndTittle.LastIndexOf('"'));
                    title = title.Remove(0, 1);

                    //Getting game's link from game url
                    torrentUrl = scraperClasses.getTorrentUrl(gameUrl);
                    magnetUrl = scraperClasses.getMagnetUrl(gameUrl);

                    if (torrentUrl != null && magnetUrl != null)
                    {
                        if (title == null)
                        {
                            title = userinput;
                        }
                        //make response pbp
                    }
                    else if (torrentUrl == null && magnetUrl != null)
                    {
                        //make response without torrentUrl for pbp
                    }
                    else if (torrentUrl != null && magnetUrl != null)
                    {
                        //make respomse without magnetUrl for pbp
                    }
                    else
                    {
                        Console.WriteLine("Could not fetch torrent url and magnet url");
                    }

                }
                else
                {
                    Console.WriteLine("Error could not fetch game, site structure may changed");
                }
            }
            else
            {
                Console.WriteLine("Error could not find game without any name, use LimeTorrentScraper.exe /gameName");
            }

        }
    }
}