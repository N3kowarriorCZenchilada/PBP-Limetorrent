using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LimeTorrentScraper
{
    internal class LimeTorrentScraper : Project_Black_Pearl.SDK.PBPPlugin
    {
        public string Title => "LimeTorrent";
        public string Type => "Binary";
        
        public bool isPrefetch => false;
        public string FirstPayloadScraper => "";
        public string FirstPayloadType => "Binary";
        public string ScraperPath => Path.Combine(InfoPath.PBPExtensions, "LimeTorrentScraper\\LimeTorrent.exe");
        public string URL1Image => InfoPath.PBPImages + "TorrentImg.png";
        public string URL1Type => "";
        public string URL1Validator => "";
        public string URL2Image => InfoPath.PBPImages+ "MagnetImg.png";
        public string URL2Type => "";
        public string URL2Validator => "";
        public string URL3Image => "";
        public string URL3Type => "";
        public string URL3Validator => "";
        public string URL4Image => "";
        public string URL4Type => "";
        public string URL4Validator => "";
    }
    public class InfoPath
    {
        public static string systempath = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        public static string PBPExtensions = Path.Combine(systempath, "Project Black Pearl\\Extensions\\Scrapers");
        public static string PBPImages = Path.Combine(systempath, "Project Black Pearl\\Extensions\\Images\\");
    }
}