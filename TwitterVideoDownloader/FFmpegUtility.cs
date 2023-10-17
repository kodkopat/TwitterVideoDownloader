using System.Diagnostics;

namespace TwitterVideoDownloader
{
    public static class FFmpegUtility
    {
        // Use FFmpeg to download the video
        public static void DownloadVideo(string videoUrl)
        {
            string ffmpegPath = @"./ffmpeg/ffmpeg";
            string arguments = $"-i \"{videoUrl}\" {Guid.NewGuid().ToString().Replace("-", "")}.mp4";

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
