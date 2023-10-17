using PuppeteerSharp;

namespace TwitterVideoDownloader
{
    public class TweetVideoDownloader
    {
        // Fetch video links from the given tweet address
        public async Task<List<string>> FetchVideoLinksFromTweet(string tweetAddress)
        {
            var videoList = new List<string>();
            await new BrowserFetcher().DownloadAsync();

            var browser = await Puppeteer.LaunchAsync(new LaunchOptions { Headless = true });
            var page = await browser.NewPageAsync();

            // Enable request interception
            await page.SetRequestInterceptionAsync(true);
            page.Request += (sender, e) =>
            {
                if (e.Request.Url.StartsWith("https://video.twimg.com/ext_tw_video"))
                {
                    videoList.Add(e.Request.Url);
                }
                e.Request.ContinueAsync();
            };

            await page.GoToAsync(tweetAddress);
            await page.WaitForTimeoutAsync(5000);
            await browser.CloseAsync();

            return videoList.Distinct().ToList();
        }

        // Download videos using the video links
        public void DownloadVideos(List<string> videoLinks)
        {
            foreach (var link in videoLinks)
            {
                Console.WriteLine($"downloading video: {link}");
                FFmpegUtility.DownloadVideo(link);
            }
        }
    }
}