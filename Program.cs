using ProgrammingTestTetris.GameLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingTestTetris
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // init our UI Handler
            IUIHandler uiHandler = new ConsoleUIHandler();
            //preparing Console  
            //Game Header
            uiHandler.tellUser(@"Press:
[d]   Move Right
[a]   Move Left
[w]   Turn Clockwise
[s]   Turn CounterClockwise");
            // Start game
            uiHandler.onStart();
            // handle user choices
            while (uiHandler.handleUsreInput(convertToKeyEnum(Console.ReadKey(true).Key)))
                ;
            uiHandler.onGameFinish();
            // game finished
            Console.Clear();
            Console.WriteLine("Game finished bro!");
        }
        //
        static Utilities.Key convertToKeyEnum(ConsoleKey _key)
        {
            switch (_key)
            {
                case ConsoleKey.A:
                    return Utilities.Key.Left;
                case ConsoleKey.D:
                    return Utilities.Key.Right;
                case ConsoleKey.W:
                    return Utilities.Key.ROTATE_LEFT;
                case ConsoleKey.S:
                    return Utilities.Key.ROTATE_RIGHT;
                default:
                    return Utilities.Key.INVALID;

            }
        }

    }
}
