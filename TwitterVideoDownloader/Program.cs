namespace TwitterVideoDownloader
{
    public class Program
    {
        static async Task Main(string[] args)
        {
            var downloader = new TweetVideoDownloader();
            string tweetAddress;

            do
            {
                Console.Write("Enter the tweet address (or type 'exit' to quit):");
                tweetAddress = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(tweetAddress) || tweetAddress.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                var videoLinks = await downloader.FetchVideoLinksFromTweet(tweetAddress);
                downloader.DownloadVideos(videoLinks);

            } while (true);
        }
    }
}
