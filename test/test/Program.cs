/*
 * Created by SharpDevelop.
 * User: Nikita
 * Date: 03.12.2016
 * Time: 18:30
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Reflection;
namespace test
{
    class Program
    {
        static String[] slogan = new string[5] { "Why am I here?", "You should go for a walk", "I bet you have other things to do", "wow much text so console", "What have I done..." };

        static void TextToColor(string name)
        {
            switch (name)
            {
                case "red":
                    Console.ForegroundColor = ConsoleColor.Red;
                    break;
                case "blue":
                    Console.ForegroundColor = ConsoleColor.Blue;
                    break;
                case "green":
                    Console.ForegroundColor = ConsoleColor.Green;
                    break;
            }
        }
        public class Exec
        {
            public void help(string arg)
            {
                Console.WriteLine("Type 'methodlist' for list of all commands\n\nhere are some of them\n\nmelody 123-321 - plays numbers as tunes. Use '-' for pause");
            }
            public void melody(string arg)
            {
                for (int i = 0; i < arg.Length; i++)
                    if(arg[i]!='-')
                        Console.Beep(20 * Convert.ToInt32(arg[i]), 200);
                    else
                        System.Threading.Thread.Sleep(100);
            }
            public void breakout(string arg)
            {
                bool playing = true, up = true, left = true;
                int x = 10, y = 5;
                bool[,] map = new bool[10, 5];
                while (playing)
                {
                    System.Threading.Thread.Sleep(100);
                    Console.Clear();
                    for (int X = 0; X < 10; X++)
                        for (int Y = 0; Y < 5; Y++)
                            if (!map[X, Y])
                            {
                                Console.SetCursorPosition(X, Y);
                                Console.Write("█");
                            }
                    if (left && x > 0)
                        x--;
                    else
                        left = false;
                    if (!left && x < 10)
                        x++;
                    else
                        left = true;

                    if (up && y > 0)
                        y--;
                    else
                        up = false;
                    if (!up && y < 10)
                        y++;
                    else
                        up = true;

                    Console.SetCursorPosition(x,y);
                    Console.Write("0");
                }
            }
            public void newyear(string arg)
            {
                Console.WriteLine((new DateTime(DateTime.Today.Year,12,31) - DateTime.Today).Days + " days until new year");
            }
            public void methodlist(string arg)
            {
                Type type = typeof(Exec);
                foreach (var method in type.GetMethods())
                {
                    Console.WriteLine(method.Name);
                }
            }
            public void intro(string arg)
            {
                Random rand = new Random();
                TextToColor(arg.ToLower());
                Console.WriteLine("\n" +
                              "      _______ _____  _____ _______\n" +
                              "     /__  __// ___/ / ___//__  __/\n" +
                              "       / /  / ___/ /__  /   / /\n" +
                              "      /_/  /____/ /____/   /_/\n     " +
                              slogan[rand.Next(0, 5)]);
                Console.ResetColor();

            }
            public void color(string arg)
            {
                TextToColor(arg.ToLower());
            }
            public void clear(string arg)
            {
                Console.Clear();
            }
            public void echo(string arg)
            {
                try
                {
                    for (int i = 0; i < Convert.ToInt32(arg.Split('*')[1]); i++)
                        Console.WriteLine(arg.Split('*')[0]);
                }
                catch
                {
                    Console.WriteLine(arg);
                }
            }
            public static void Main(string[] args)
            {
                Random rand = new Random();
                Console.WriteLine("\n" +
                              "      _______ _____  _____ _______\n" +
                              "     /__  __// ___/ / ___//__  __/\n" +
                              "       / /  / ___/ /__  /   / /\n" +
                              "      /_/  /____/ /____/   /_/\n     " +
                              slogan[rand.Next(0, 5)] + "\n\n type 'help' for help");
                // TODO: Implement Functionality Here
                while (true)
                {
                    Console.Write("\n>");
                    string s = Console.ReadLine() + " ";
                    if (s != " ")
                    {
                        Type type = typeof(Exec);
                        MethodInfo method = type.GetMethod(s.Split(' ')[0]);
                        Exec c = new Exec();
                        try
                        {
                            method.Invoke(c, new Object[1] { s.Split(' ')[1] });
                        }
                        catch
                        {
                            Console.WriteLine("Invalid request");                            
                        }
                    }

                }
                Console.Write("\n     Press any key to continue . . . ");
                Console.ReadKey(true);
            }
        }
    }
}