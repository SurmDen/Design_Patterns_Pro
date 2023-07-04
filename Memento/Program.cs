using System;
using System.Collections;
using System.Collections.Generic;

namespace Memento
{
    public class Hero
    {
        private int bullets = 10;
        private int lives = 10;

        public void Shoot()
        {
            if (bullets != 0)
            {
                bullets--;
                Console.WriteLine($"you make a shoot, you have {bullets} bullets and {lives} lives");
            }
            else
            {
                Console.WriteLine("Bullets finished!!!");
            }
        }

        public HeroMemento SaveState()
        {
            return new HeroMemento(bullets, lives);
        }

        public void GetState(HeroMemento memento)
        {
            bullets = memento.Bullets;
            lives = memento.Lives;
        } 
    }

    public class HeroMemento
    {
        public int Bullets { get; private set; }
        public int Lives { get; private set; }

        public HeroMemento(int bullets, int lives)
        {
            Bullets = bullets;
            Lives = lives;
        }
    }

    public class GameSaver
    {
        public Stack<HeroMemento> States { get;private set; }

        public GameSaver()
        {
            States = new Stack<HeroMemento>();
        }

        public void SaveGame(HeroMemento memento)
        {
            States.Push(memento);
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Hero hero = new Hero();

            hero.Shoot();
            hero.Shoot();
            GameSaver saver = new GameSaver();
            saver.SaveGame(hero.SaveState());
            hero.Shoot();
            hero.Shoot();
            hero.GetState(saver.States.Pop());
            hero.Shoot();

            Console.ReadLine();
        }
    }
}
