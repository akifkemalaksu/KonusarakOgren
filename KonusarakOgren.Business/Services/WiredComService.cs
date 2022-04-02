using HtmlAgilityPack;
using KonusarakOgren.Business.Constants;
using KonusarakOgren.Entities.ResponseModels;
using System;

namespace KonusarakOgren.Business.Services
{
    public static class WiredComService
    {
        public static List<TopicFromWebResponseModel> GetMostTopics()
        {
            List<TopicFromWebResponseModel> topics = new List<TopicFromWebResponseModel>();

            var web = new HtmlWeb();
            var doc = web.Load(Urls.WiredCom);

            var mostRecentdiv = doc.DocumentNode.SelectNodes("//div[@class='summary-list__items']")[1];
            var summaryDivs = mostRecentdiv.SelectNodes("div[@data-section-title]");

            foreach (var summaryDiv in summaryDivs)
            {
                var a = summaryDiv.ChildNodes[0].ChildNodes.First();

                string path = a.GetAttributeValue("href", String.Empty);

                topics.Add(GetTopicInfo(path));
            }

            return topics;
        }

        public static TopicFromWebResponseModel GetTopicInfo(string path)
        {
            var web = new HtmlWeb();

            var insideTopic = web.Load($"{Urls.WiredCom}{path}");

            var h1 = insideTopic.DocumentNode.SelectSingleNode("//h1");

            var article = insideTopic.DocumentNode.SelectSingleNode("//article");

            var title = h1.InnerText;
            var paragraph = string.Join("\n", article.SelectNodes("//p").Select(p => p.InnerText));

            return new TopicFromWebResponseModel()
            {
                Title = title,
                UrlPath = path,
                Content = paragraph
            };
        }
    }
}