using System;

namespace KonusarakOgren.Business.Constants
{
    public static class Messages
    {
        public static readonly string UserNotFound = "User is not found.";
        public static readonly string WrongPassword = "Password is wrong.";
        public static readonly string UsernameIsUsing = "This username is using.";

        /*

         var url = "https://www.wired.com/";
            var web = new HtmlWeb();
            var doc = web.Load(url);
            var summaryDiv = doc.DocumentNode.SelectSingleNode("//div[@class='SummaryCollageEightGridItemList-drfwxm kcItAB']");
            //var aElements = summaryDiv.SelectNodes("//a[@class='SummaryItemHedLink-cgPsOZ cnoEIb summary-item-tracking__hed-link summary-item__hed-link']");
            var aElements = summaryDiv.SelectNodes("//a[@data-recirc-pattern='summary-item']");
            foreach (var a in aElements.Take(5))
            {
                string link = a.GetAttributeValue("href", String.Empty);

                var insideTopic = web.Load($"{url}{a.GetAttributeValue("href", String.Empty)}");

                var article = insideTopic.DocumentNode.SelectSingleNode("//article");

                var pElements = article.SelectNodes("//p");

                foreach (var p in pElements)
                {
                    var text = p.InnerText;
                }
            }

         */
    }
}