﻿using System;

namespace P01_EventImplementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();
            Handler handler = new Handler();
            
            dispatcher.NameChange += handler.OnDispatcherNameChange;

            string input;
            while((input = Console.ReadLine()) != "End")
            {
                dispatcher.Name = input;
            }
        }
    }
}
