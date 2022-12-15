using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace LimeTorrentScraper
{
    public class ProgramClass
    {
        public static void Main(string[] args)
        {
            if (args[0] != null)
            {
                string userinput = args[2];
                ScraperClasses scraperClasses = new ScraperClasses();
                List<string> torrentUrls = new List<string>();
                List<string> magnetUrls = new List<string>();
                string magnetUrl;
                string torrentUrl;
                string title = args[2];
                string gameUrl;
                int resnum;
                bool urladded = false;
                //running search
                for (resnum = 1; resnum <= 3; resnum ++)
                {
                    string gameUrlAndTittle = scraperClasses.getResaultUrl(userinput, resnum);

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


                        if (torrentUrl == null && magnetUrl == null)
                        {
                            Console.WriteLine("Could not fetch torrent url and magnet url");
                        }
                        else
                        {
                            torrentUrls.Add(torrentUrl);
                            magnetUrls.Add(magnetUrl);
                            urladded = true;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Error could not fetch game, site structure may changed");
                    }
                }
                if (urladded == true)
                {
                    ScraperClasses.response Output = new ScraperClasses.response();
                    Output.Title = title;
                    Output.URL1 = torrentUrls;
                    Output.URL2 = magnetUrls;
                    string FilePath = args[1];
                    string jsonString = JsonSerializer.Serialize(Output);
                    File.WriteAllText(FilePath, jsonString);
                    string DonePath = args[3];
                    File.WriteAllText(DonePath, "True");
                }
                else
                {
                    ScraperClasses.response Output = new ScraperClasses.response();
                    Output.Title = "error not found";
                    Output.URL1 = new List<string>();
                    Output.URL2 = new List<string>();
                    string FilePath = args[1];
                    string jsonString = JsonSerializer.Serialize(Output);
                    File.WriteAllText(FilePath, jsonString);
                    string DonePath = args[3];
                    File.WriteAllText(DonePath, "True");
                }
            
            }
            else
            {
                Console.WriteLine("Error could not find game without any name, use LimeTorrentScraper.exe /gameName");
            }

        }
    }
}