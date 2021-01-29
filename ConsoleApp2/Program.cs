using System;

namespace ConsoleApp2
{
    public class Dinosaur
    {
        public int LevelOfLife { get; set; } = 20;
        public int Count { get; set; }
        public bool BigJumb { get; set; }
        public bool Jump { get; set; }
        public bool JumpBelow { get; set; }
        public RoadObstacle Obstacle { get; set; }
    }
    public enum RoadObstacle
    {
        Cactus,
        Spade,
        BigCactus

    }
    public enum DayOrNight
    {
        Day,
        Night
    }
    public class Game
    {
        public DayOrNight DayOrNight { get; set; } = DayOrNight.Day;
        public Dinosaur Dinosaur { get; set; }
        public RoadObstacle Obstacle;
        public void StartGame(Dinosaur dinosaur, RoadObstacle obstacle)
        {
            Dinosaur = dinosaur;
            Obstacle = obstacle;

            if (obstacle == RoadObstacle.Cactus)
            {
                if (dinosaur.Jump || dinosaur.BigJumb)
                {
                    dinosaur.Count += 5;

                    if (dinosaur.Count >= 40)
                    {
                        Console.WriteLine("YOU WIN");
                    }
                }
                else if (dinosaur.JumpBelow == true)
                {
                    dinosaur.LevelOfLife -= 5;
                    if (dinosaur.LevelOfLife <= 0)
                    {
                        Console.WriteLine("YOU LOSE");
                    }
                }
            }
            if (obstacle == RoadObstacle.BigCactus)
            {
                if (dinosaur.Jump || dinosaur.JumpBelow)
                {
                    dinosaur.LevelOfLife -= 5;

                    if (dinosaur.LevelOfLife <= 0)
                    {
                        Console.WriteLine("YOU LOSE");
                    }
                }
                else if (dinosaur.BigJumb)
                {
                    dinosaur.Count += 5;

                    if (dinosaur.Count >= 40)
                    {
                        Console.WriteLine("YOU WIN");
                    }
                }

            }
            if (obstacle == RoadObstacle.Spade)
            {
                if (dinosaur.JumpBelow || dinosaur.BigJumb)
                {
                    dinosaur.Count += 5;

                    if (dinosaur.Count >= 40)
                    {
                        Console.WriteLine("YOU WIN");
                    }
                }
                else
                {
                    dinosaur.LevelOfLife -= 5;

                    if (dinosaur.LevelOfLife <= 0)
                    {
                        Console.WriteLine("YOU LOSE");
                    }
                }
            }
            if (dinosaur.Count % 30 == 0 || dinosaur.Count % 35 == 0 || dinosaur.Count % 40 == 0 || dinosaur.Count % 45 == 0 || dinosaur.Count % 50 == 0 || dinosaur.Count % 55 == 0 || dinosaur.Count % 60 == 0)
            {
                DayOrNight = DayOrNight.Night;
            }
            else
            {
                DayOrNight = DayOrNight.Day;
            }
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            StartGame();
        }

        static void StartGame()
        {
            const string jump = "jump";
            const string bigJumb = "bigJump";
            const string jumpBelow = "jumpBelow";
            string decision;

            Dinosaur dinosaur = new Dinosaur();
            Game game = new Game();
            Random rand = new Random();

            int number = rand.Next(0, 3);

            var k = (RoadObstacle)number;

            Console.WriteLine($"{(RoadObstacle)number} is coming");

            decision = Console.ReadLine();

            if (decision == jump)
            {
                dinosaur.Jump = true;
            }
            else if (decision == bigJumb)
            {
                dinosaur.BigJumb = true;
            }
            else if (decision == jumpBelow)
            {
                dinosaur.JumpBelow = true;
            }

            game.StartGame(dinosaur, k);

            dinosaur.Jump = false;
            dinosaur.JumpBelow = false;
            dinosaur.BigJumb = false;

            if (dinosaur.LevelOfLife == 0)
            {
                Console.WriteLine($"game ended, your score is + {dinosaur.Count}");
            }
            else
            {
                StartGame();
            }
        }
    }
}
