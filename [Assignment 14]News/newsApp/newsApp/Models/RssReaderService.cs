using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Xml.Linq;

namespace newsApp.Models
{
    public class RssReaderService
    {
        private readonly string _tuoiTreRssUrl = "https://tuoitre.vn/rss/the-gioi.rss"; 

        public async Task<List<RSS>> GetTuoiTreNews()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(_tuoiTreRssUrl);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                return ParseRssFeed(content);
            }
            else
            {
                
                throw new Exception($"Failed to fetch RSS feed: {response.StatusCode}");
            }
        }

        private List<RSS> ParseRssFeed(string content)
        {


            var doc = XDocument.Parse(content);
            var channel = doc.Descendants("channel").FirstOrDefault();

            if (channel == null)
            {
                return new List<RSS>();
            }

            var sources = new List<RSS>();
            var source = new RSS
            {
                SourceName = channel.Element("title")?.Value,
                URL = channel.Element("link")?.Value,
                Created_At = ParseDateTime(channel.Element("pubDate")?.Value), 
                Updated_At = null, 
            };

            var items = channel.Descendants("item");

            sources.Add(source);
            return sources;
        }

        private DateTime? ParseDateTime(string dateString)
        {

            if (DateTime.TryParse(dateString, out var date))
            {
                return date;
            }
            return null;
        }
    }
}