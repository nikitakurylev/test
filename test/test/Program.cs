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
        public class Exec
        {
            public void intro(string arg)
            {
                String[] slogan = new string[5] { "Why am I here?", "You should go for a walk", "I bet you have other things to do", "wow much text so console", "What have I done..." };
                Random rand = new Random();
                switch (arg.ToLower())
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
                switch (arg.ToLower())
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
        }

        public static void Main(string[] args)
        {
            Exec exec = new Exec();
            exec.intro("");
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