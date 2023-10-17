# Twitter Video Downloader

A simple tool that allows users to download videos from Twitter tweets using PuppeteerSharp and FFmpeg.

## Prerequisites

Before running the application, you must:

1. Download `ffmpeg.exe` from the official FFmpeg website: [FFmpeg Official Download](https://ffmpeg.org/download.html).
2. After downloading, copy the `ffmpeg.exe` file to the ffmpeg directory of the solution (as shown in the provided directory structure).

## Directory Structure

Refer to the following structure for placement of `ffmpeg.exe`:


├── TwitterVideoDownloader

│ ├── Dependencies

│ ├── ffmpeg/ffmpeg.exe <---- Place the downloaded ffmpeg.exe here

│ ├── FFmpegUtility.cs

│ ├── Program.cs

│ └── TweetVideoDownloader.cs


## How to Use

1. Clone the repository: `git clone  https://github.com/kodkopat/TwitterVideoDownloader.git`.
2. Navigate to the solution directory: `cd TwitterVideoDownloader`.
3. Ensure `ffmpeg.exe` is placed in the correct location as per the directory structure above.
4. Build and run the solution.
5. Follow the on-screen prompts to provide the tweet address and start downloading videos.

## Features

- Fetch video links from the provided tweet address.
- Download videos using FFmpeg utility.
- User-friendly console interface.

## Contributing

Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.
