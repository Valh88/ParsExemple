namespace ParsExemple
{
    public class Api
    {
        public static string base_url = "https://novosibirsk.rus-buket.ru/";
        private Dictionary<string, int> param = new() { { "page", 1 } };
        public Api(int page)
        {
            // string data = await Request.GetHtml($"{base_url}?PAGEN_1={page}");
            // Parser parser = new Parser(data);
            // parser.GetData();
            param["page"] = page;
        }

        public string GetUrl()
        {
            return $"{base_url}cvety?page={param["page"]}";
        }
    }
}

