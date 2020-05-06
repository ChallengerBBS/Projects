﻿using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using Logger.Factories;
using Logger.Models.Interfaces;

namespace Logger.Core
{
    public class Engine
    {
        private ILogger logger;
        private ErrorFactory errorFactory;

        private Engine()
        {
            this.errorFactory=new ErrorFactory();
            
        }
        public Engine(ILogger logger)
        :this()
        {
            this.logger = logger;
        }

        public void Run()
        {
            string command = Console.ReadLine();

            while (command != "END")
            {
                string[] errorArgs = command
                    .Split("|")
                    .ToArray();

                string level = errorArgs[0];
                string date = errorArgs[1];
                string message = errorArgs[2];

                IError error;

                try
                {
                    error = this.errorFactory.GetError(date, level, message);
                    this.logger.Log(error);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    
                }
                command = Console.ReadLine();
            }

            Console.WriteLine(this.logger.ToString());
        }
    }
}