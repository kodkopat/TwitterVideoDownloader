using PuppeteerSharp;
using System.Diagnostics;

namespace TwitterVideoDownloader
{
    public class Program
    {
        private static List<string> videoList = new List<string>();

        static async Task Main(string[] args)
        {
            string tweetAddress;
            do
            {
                Console.WriteLine("Enter the tweet address (or type 'exit' to quit):");
                tweetAddress = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(tweetAddress) || tweetAddress.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                await EnableRequestInterception(tweetAddress);
                ProcessVideoLinks();

            } while (true);
        }

        private static async Task EnableRequestInterception(string tweetAdres)
        {
            await new BrowserFetcher().DownloadAsync();
            var browser = await Puppeteer.LaunchAsync(new LaunchOptions
            {
                Headless = true
            });
            var page = await browser.NewPageAsync();

            // Enable request interception
            await page.SetRequestInterceptionAsync(true);
            page.Request += (sender, e) =>
            {
                //Console.WriteLine(e.Request.Url);
                if (e.Request.Url.StartsWith("https://video.twimg.com/ext_tw_video"))
                {
                    videoList.Add(e.Request.Url);
                }
                e.Request.ContinueAsync();
            };
            await page.GoToAsync(tweetAdres);
            await page.WaitForTimeoutAsync(5000);
            await browser.CloseAsync();
        }

        private static void ProcessVideoLinks()
        {
            foreach (var item in videoList.Distinct())
            {
                Console.WriteLine(item);
                string ffmpegPath = @"./ffmpeg/ffmpeg";
                string arguments = $"-i \"{item}\" {Guid.NewGuid().ToString().Replace("-", "")}.mp4";
                Process.Start(new ProcessStartInfo
                {
                    FileName = ffmpegPath,
                    Arguments = arguments,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    UseShellExecute = false,
                    CreateNoWindow = true
                });
            }
        }
    }

}
