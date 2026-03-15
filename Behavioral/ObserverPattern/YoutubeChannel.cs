using System;
using System.Collections.Generic;

namespace DesignPatterns.Behavioral.ObserverPattern
{
    /// <summary>
    /// Concrete Subject - YouTube channel that notifies subscribers
    /// </summary>
    public class YouTubeChannel : ISubject
    {
        private List<IObserver> _subscribers;
        private string _channelName;
        private string _latestVideo;

        public YouTubeChannel(string channelName)
        {
            _channelName = channelName;
            _subscribers = new List<IObserver>();
        }

        public void Attach(IObserver observer)
        {
            _subscribers.Add(observer);
            Console.WriteLine($"✅ New subscriber added to {_channelName}");
        }

        public void Detach(IObserver observer)
        {
            _subscribers.Remove(observer);
            Console.WriteLine($"❌ Subscriber removed from {_channelName}");
        }

        public void Notify()
        {
            Console.WriteLine($"\n📢 {_channelName} is notifying {_subscribers.Count} subscribers...");
            foreach (var subscriber in _subscribers)
            {
                subscriber.Update(_latestVideo);
            }
        }

        public void UploadVideo(string videoTitle)
        {
            Console.WriteLine($"\n🎬 {_channelName} uploaded new video: \"{videoTitle}\"");
            _latestVideo = videoTitle;
            Notify();
        }
    }
}