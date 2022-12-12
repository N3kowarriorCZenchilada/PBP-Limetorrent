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
        //Hotovo - Done
        public string getResaultUrl(string userInput)
        {

            userInput = userInput.Replace(" ", "-");
            string defaultSearchUrl = "https://www.limetorrents.lol/search/games";
            string searchUrl = defaultSearchUrl + userInput;
            HtmlWeb Web = new HtmlWeb();
            var Doc = Web.Load(searchUrl);
            var Note = Doc.DocumentNode.SelectNodes("/html/body/div/div[6]/div[1]/table[2]/tbody/tr[2]/td[1]/div[1]/a[2]");
            if (Note != null)
            {
                string gameUrlAndTitle = Note.ToString();
                gameUrlAndTitle = gameUrlAndTitle.Substring(gameUrlAndTitle.Length - 4);
                gameUrlAndTitle = gameUrlAndTitle.Remove(0, 8);
                gameUrlAndTitle = gameUrlAndTitle.Replace(">", string.Empty);
                Console.WriteLine("if no error passed getting game url was succesfull ");
                return gameUrlAndTitle;
            }
            else
            {
                return null;
            }
        
        }

        //V úpravách - In development
        public string getTorrentUrl(string gameUrl)
        {
            string defaultLimeTorrentUrl = "https://www.limetorrents.lol/";
            string searchUrl = defaultLimeTorrentUrl + gameUrl;
            HtmlWeb Web = new HtmlWeb();
            var Doc = Web.Load(searchUrl);
            var Note = Doc.DocumentNode.SelectNodes("/html/body/div/div[6]/div[1]/div[1]/div[1]/div/div[2]/div/p/a");
            if (Note != null)
            {
                string torrentLink = Note.ToString();
                torrentLink = torrentLink.Remove(0, 8);
                torrentLink = torrentLink.Remove(torrentLink.Length - 20);
                torrentLink = torrentLink.Replace(char.ToString('"'), string.Empty);
                return torrentLink;
            }
            else
            {
                return null;
            }
        }
        public string getMagnetUrl(string gameUrl)
        {
            string defaultLimeTorrentUrl = "https://www.limetorrents.lol/";
            string searchUrl = defaultLimeTorrentUrl + gameUrl;
            HtmlWeb Web = new HtmlWeb();
            var Doc = Web.Load(searchUrl);
            var Note = Doc.DocumentNode.SelectNodes("/html/body/div/div[6]/div[1]/div[1]/div[1]/div/div[4]/div/p/a");
            if (Note != null)
            {
                string magnetLink = Note.ToString();
                magnetLink = magnetLink.Remove(0, 8);
                magnetLink = magnetLink.Remove(magnetLink.Length - 21);
                magnetLink = magnetLink.Replace(char.ToString('"'), string.Empty);
                return magnetLink;
            }
            else
            {
                return null;
            }
        }


        //LimeTorrent xpaths 
        //xpath 1 Game      /html/body/div/div[6]/div[1]/table[2]/tbody/tr[2]/td[1]/div[1]/a[2]
        //xpath 2 Torrent   /html/body/div/div[6]/div[1]/div[1]/div[1]/div/div[2]/div/p/a
        //xpath 3 Magnet    /html/body/div/div[6]/div[1]/div[1]/div[1]/div/div[4]/div/p/a

    }
}