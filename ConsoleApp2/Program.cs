using System;

namespace ConsoleApp2
{
    class Dinosaur
    {
        public int level_of_life { get; set; } = 20;
        public int count { get; set; }
        public bool big_jump { get; set; } = false;
        public bool jump { get; set; } = false;
        public bool jump_below { get; set; } = false;
        public obstacle_on_road obstacle;
    }
   public enum obstacle_on_road { cactus, spade, big_cactus }
     enum day_or_night {day, night}
    class game
    {
        public day_or_night day_or_night { get; set; } = day_or_night.day;
        public Dinosaur dinosaur;
        public obstacle_on_road obstacle;
        public void game_started(Dinosaur dinosaur ,obstacle_on_road obstacle)
        {
            this.dinosaur = dinosaur;
            this.obstacle = obstacle;
            if(obstacle==obstacle_on_road.cactus)
            {
                if(dinosaur.jump==true || dinosaur.big_jump==true)
                {
                    dinosaur.count += 5;
                    if (dinosaur.count >= 40)
                    {
                        Console.WriteLine("YOU WIN");
                    }
                }
               else if(dinosaur.jump_below==true)
                {
                    dinosaur.level_of_life -= 5;
                    if(dinosaur.level_of_life<=0)
                    {
                        Console.WriteLine("YOU LOSE");
                    }
                }
            }
            if(obstacle==obstacle_on_road.big_cactus)
            {
             if(dinosaur.jump==true || dinosaur.jump_below==true)
                {
                    dinosaur.level_of_life -= 5;
                    if (dinosaur.level_of_life <= 0)
                    {
                        Console.WriteLine("YOU LOSE");
                    }
                }
             else if(dinosaur.big_jump==true)
                {
                    dinosaur.count += 5;
                    if (dinosaur.count >= 40)
                    {
                        Console.WriteLine("YOU WIN");
                    }
                }

            }
            if(obstacle==obstacle_on_road.spade)
            {
                if(dinosaur.jump_below==true || dinosaur.big_jump==true)
                {
                    dinosaur.count += 5;
                    if (dinosaur.count >= 40)
                    {
                        Console.WriteLine("YOU WIN");
                    }
                }
                else
                {
                    dinosaur.level_of_life -= 5;
                    if (dinosaur.level_of_life <= 0)
                    {
                        Console.WriteLine("YOU LOSE");
                    }
                }
            }
            if(dinosaur.count%30==0 || dinosaur.count % 35 == 0 || dinosaur.count % 40 == 0 || dinosaur.count % 45 == 0 || dinosaur.count % 50 == 0 || dinosaur.count % 55 == 0 || dinosaur.count % 60 == 0 )
            {
                day_or_night = day_or_night.night;
            }
            else
            {
                day_or_night = day_or_night.day;
            }
            
        }

    }
    class Program
    {
        static void Main(string[] args)
        {
           
            string jump = "jump";
            string big_jump = "big_jump";
            string jump_below = "jump_below";
            string decision;
           
            Dinosaur dinosaur = new Dinosaur();
            game game = new game();
            Random rand = new Random();
        gamestarted:
            int number = rand.Next(0, 3);
            var k = (obstacle_on_road)number;
            Console.WriteLine((obstacle_on_road)number+" "+"is coming");
            decision = Console.ReadLine();
            if(decision==jump)
            {
                dinosaur.jump = true;
            }
            if (decision == big_jump)
            {
                dinosaur.big_jump = true;
            }
            if (decision == jump_below)
            {
                dinosaur.jump_below = true;
            }
            game.game_started(dinosaur, k);
            dinosaur.jump = false;
            dinosaur.jump_below = false;
            dinosaur.big_jump = false;
            
            if (dinosaur.level_of_life == 0 )
            {
                Console.WriteLine("game ended, " + "your score is +{ 0} ", dinosaur.count);
            }
            else
            {
                goto gamestarted;
            }
            
        }
    }
}
