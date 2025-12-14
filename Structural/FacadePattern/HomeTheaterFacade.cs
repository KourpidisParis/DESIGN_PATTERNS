using System;

namespace DesignPatterns.Structural.FacadePattern
{
    /// <summary>
    /// Facade - Provides a simple interface to the complex home theater system
    /// </summary>
    public class HomeTheaterFacade
    {
        private TV _tv;
        private SoundSystem _soundSystem;
        private DVDPlayer _dvdPlayer;
        private Lights _lights;
        private Projector _projector;

        public HomeTheaterFacade()
        {
            _tv = new TV();
            _soundSystem = new SoundSystem();
            _dvdPlayer = new DVDPlayer();
            _lights = new Lights();
            _projector = new Projector();
        }

        public void WatchMovie(string movie)
        {
            Console.WriteLine("\n🎬 Getting ready to watch a movie...\n");

            _lights.Dim(10);
            _projector.TurnOn();
            _projector.SetInput("HDMI 1");
            _projector.SetWideScreenMode();
            _soundSystem.TurnOn();
            _soundSystem.SetInput("DVD");
            _soundSystem.SetVolume(50);
            _soundSystem.SetSurroundSound();
            _dvdPlayer.TurnOn();
            _dvdPlayer.InsertDVD(movie);
            _dvdPlayer.Play();

            Console.WriteLine("\n✅ Movie is now playing! Enjoy!\n");
        }

        public void EndMovie()
        {
            Console.WriteLine("\n🛑 Shutting down movie mode...\n");

            _dvdPlayer.Stop();
            _dvdPlayer.Eject();
            _dvdPlayer.TurnOff();
            _soundSystem.TurnOff();
            _projector.TurnOff();
            _lights.TurnOn();

            Console.WriteLine("\n✅ Movie ended. All systems shut down.\n");
        }

        public void WatchTV()
        {
            Console.WriteLine("\n📺 Setting up for TV watching...\n");

            _lights.Dim(30);
            _tv.TurnOn();
            _tv.SetInput("Cable");
            _tv.AdjustSettings();
            _soundSystem.TurnOn();
            _soundSystem.SetInput("TV");
            _soundSystem.SetVolume(30);

            Console.WriteLine("\n✅ TV is ready! Enjoy your show!\n");
        }

        public void EndTV()
        {
            Console.WriteLine("\n🛑 Turning off TV mode...\n");

            _tv.TurnOff();
            _soundSystem.TurnOff();
            _lights.TurnOn();

            Console.WriteLine("\n✅ TV mode ended.\n");
        }
    }
}