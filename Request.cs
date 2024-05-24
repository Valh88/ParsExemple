
namespace ParsExemple;

public class Request
{
    static HttpClient client = new HttpClient { Timeout = TimeSpan.FromSeconds(10) };

    public static async Task<string> GetHtml(string url)
    {
        return await client.GetStringAsync(url);
    }

}
