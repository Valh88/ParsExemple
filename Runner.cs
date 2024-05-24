using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ParsExemple
{
    public class Runner
    {
        private List<Api> urls = new();
        public String fileName { get; set; }
        public Runner(List<int> pages, String fileName)
        {
            this.fileName = fileName;
            foreach (var page in pages)
            {
                urls.Add(new Api(page));
            }
        }

        public async Task GoWork()
        {
            Console.WriteLine($"Starting {fileName}");
            var tasks = new List<Task>();
            foreach (var url in urls)
            {
                var html = await Request.GetHtml(url.GetUrl());
                var parser = new Parser(html);
                parser.RunParsing();
                tasks.Add(WriteAsync(parser.Data));
            }
            await Task.WhenAll(tasks);
        }

        private async Task WriteAsync(List<(string, string, string)> contents)
        {
            using (StreamWriter writer = new StreamWriter(this.fileName, append: true, Encoding.UTF8))
            {
                foreach (var content in contents)
                {
                    await writer.WriteLineAsync(content.Item1 + "|" + content.Item2 + "|" + content.Item3);
                }
            }
        }
    }
}

