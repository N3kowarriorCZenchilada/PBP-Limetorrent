using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace LimeTorrentScraper
{
    public class ScraperClasses
    {
        public string getResaultUrl(string userInput)
        {

            userInput = userInput.Replace(" ", "-");
            string defaultSearchUrl = "https://www.limetorrents.lol/search/games";
            string searchUrl = defaultSearchUrl + userInput;
            HtmlWeb Web = new HtmlWeb();
            var Doc = Web.Load(searchUrl);
            var Note = Doc.DocumentNode.SelectNodes("/html/body/div/div[6]/div[1]/table[2]/tbody/tr[2]/td[1]/div[1]/a[2]");
            string gameUrlAndTitle = Note.ToString();
            gameUrlAndTitle = gameUrlAndTitle.Substring(gameUrlAndTitle.Length-4);
            gameUrlAndTitle = gameUrlAndTitle.Remove(0, 8);
            gameUrlAndTitle = gameUrlAndTitle.Replace(">", string.Empty);

            return gameUrlAndTitle; 
        }
        
        //xpath 1 Game      /html/body/div/div[6]/div[1]/table[2]/tbody/tr[2]/td[1]/div[1]/a[2]
        //xpath 2 Torrent   /html/body/div/div[6]/div[1]/div[1]/div[1]/div/div[2]/div/p/a
        //xpath 3 Magnet    /html/body/div/div[6]/div[1]/div[1]/div[1]/div/div[4]/div/p/a

    }
}