using System.Numerics;
using HtmlAgilityPack;

namespace ParsExemple
{
    public class Parser
    {
        // string Html;
        private HtmlDocument dom = new();
        private List<(string, string, string)> data = new();

        public Parser(string html)
        {
            this.dom.LoadHtml(html);
        }

        public string GetTitle()
        {
            return dom.DocumentNode.SelectSingleNode("//h1").InnerText;
        }

        public void RunParsing()
        {
            HtmlNodeCollection nodes = dom.DocumentNode.SelectNodes("//div[@class='col-xs-6 col-sm-4 catalog-row__col js_catalog__cell js_product-card-box']");
            foreach (var item in nodes)
            {
                // string name, price, description;
                // var nameNodes = item.SelectNodes(".//a[@class='rb-product-card__name js_rb-product-card__name js_product-card__link']");
                // foreach (var nameNode in nameNodes)
                // {   
                //     name = nameNode.InnerText;
                // }
                // var priceNodes = item.SelectNodes(".//a[@class='rb-product-card__price-box ']");
                // foreach (var priceNode in priceNodes)
                // {   
                //     price = priceNode.InnerText;
                // }
                var nameNode = item.SelectSingleNode(".//a[@class='rb-product-card__name js_rb-product-card__name js_product-card__link']");
                string name = nameNode != null ? nameNode.InnerText.Trim() : "null";

                var priceNodes = item.SelectSingleNode(".//div[@class='rb-product-card__price-box ']");
                string price = priceNodes != null ? priceNodes.InnerText.Trim() : "null";

                var descriptionNode = item.SelectSingleNode(".//div[@class='product-card__consist']");
                string description = descriptionNode != null ? descriptionNode.InnerText.Trim() : "null";

                data.Add((name, price, description));
            }
        }

        public List<(string, string, string)> Data
        {
            get { return data; }
        }
    }
}

