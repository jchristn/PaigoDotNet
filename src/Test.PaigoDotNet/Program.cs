namespace Test
{
    using System;
    using System.Collections.Generic;
    using System.Net.Security;
    using GetSomeInput;
    using PaigoDotNet;
    using SerializationHelper;

    public static class Program
    {
        private static bool _RunForever = true;
        private static string _ClientId = null;
        private static string _ClientSecret = null;
        private static PaigoClient _Client = null;

        public static void Main(string[] args)
        {
            _ClientId =     Inputty.GetString("Client ID      :", null, false);
            _ClientSecret = Inputty.GetString("Client secret  :", null, false);

            _Client = new PaigoClient(_ClientId, _ClientSecret);

            while (_RunForever)
            {
                string userInput = Inputty.GetString("Command [?/help]:", null, false);

                switch (userInput)
                {
                    case "q":
                        _RunForever = false;
                        break;
                    case "?":
                        Menu();
                        break;
                    case "cls":
                        Console.Clear();
                        break;

                    case "auth":
                        Authenticate();
                        break;
                    case "get dim":
                        GetDimensions();
                        break;
                    case "get offerings":
                        GetOfferings();
                        break;
                    case "collect usage":
                        CollectUsage();
                        break;
                }
            }
        }

        private static void Menu()
        {
            Console.WriteLine("");
            Console.WriteLine("Available command");
            Console.WriteLine("  q               Quit");
            Console.WriteLine("  ?               Help, this menu");
            Console.WriteLine("  cls             Clear the screen");
            Console.WriteLine("  auth            Authenticate");
            Console.WriteLine("  get dim         Retrieve all dimensions");
            Console.WriteLine("  get offerings   Retrieve all offerings");
            Console.WriteLine("  collect usage   Collect usage data");
            Console.WriteLine("");
        }

        private static void EnumerateResult(object obj)
        {
            if (obj == null)
            {
                Console.WriteLine("");
                Console.WriteLine("(null)");
                Console.WriteLine("");
            }
            else
            {
                Console.WriteLine("");
                Console.WriteLine(Serializer.SerializeJson(obj, true));
                Console.WriteLine("");
            }
        }

        private static void Authenticate()
        {
            try
            {
                _Client.Authenticate().Wait();
                Console.WriteLine("");
                Console.WriteLine("Success");
                Console.WriteLine("");
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine(e.ToString());
                Console.WriteLine("");
            }
        }

        private static void GetDimensions()
        {
            try
            {
                List<Dimension> dimensions = _Client.GetDimensions().Result;
                EnumerateResult(dimensions);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine(e.ToString());
                Console.WriteLine("");
            }
        }

        private static void GetOfferings()
        {
            try
            {
                List<Offering> offerings = _Client.GetOfferings().Result;
                EnumerateResult(offerings);
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine(e.ToString());
                Console.WriteLine("");
            }
        }

        private static void CollectUsage()
        {
            CollectUsageRequest req = new CollectUsageRequest
            {
                DimensionId = Inputty.GetString("Dimension ID :", null, false),
                CustomerId  = Inputty.GetString("Customer ID  :", null, false),
                Value       = Inputty.GetString("Value        :", "1", false)
            };

            try
            {
                _Client.CollectUsage(req).Wait();
            }
            catch (Exception e)
            {
                Console.WriteLine("");
                Console.WriteLine(e.ToString());
                Console.WriteLine("");
            }
        }
    }
}