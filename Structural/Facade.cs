/*
Facade Pattern, karmaşık bir sistemi basit bir arayüzle dış dünyaya sunarak
kullanımı kolaylaştırır. Alt sistemlerin detaylarını gizler ve istemciye
tek giriş noktası sağlar.
*/

namespace Facade
{

    public class SaveSystem
    {
        public void Load()
        {

        }
        public void Save()
        {

        }
    }

    public class WorldSystem
    {
        public void LoadMap()
        {

        }

        public void SaveMap()
        {

        }
    }

    public class AudioSystem
    {
        private float volume;
        public void SetVolume(float volume)
        {
            this.volume = volume;
        }
    }



    public class StartGameFacade
    {
        private readonly SaveSystem saveSystem;
        private readonly AudioSystem audioSystem;
        private readonly WorldSystem worldSystem;

        public StartGameFacade(SaveSystem saveSystem, AudioSystem audioSystem, WorldSystem worldSystem)
        {
            this.saveSystem = saveSystem;
            this.audioSystem = audioSystem;
            this.worldSystem = worldSystem;
        }

        public void StartGame()
        {
            saveSystem.Load();
            worldSystem.LoadMap();
            audioSystem.SetVolume(1);
            //...
        }
    }
}



public class Program
{
    public static void Main()
    {
        StartGameFacade startGameFacade = new StartGameFacade(new SaveSystem(), new AudioSystem(), new WorldSystem());

        startGameFacade.StartGame();

        Console.ReadKey();
    }
}
