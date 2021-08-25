using System;

namespace FactoryMethodPatternConsole
{
    //Product
    public interface ITransport
    {
        string Name();
        bool Send();
    }

    //Concrete Product
    public class Plane : ITransport
    {
        public string Name()
        {
            return this.GetType().Name;
        }

        public bool Send()
        {
            //logica trasporto aereo
            return true;
        }
    }

    //Concrete Product
    public class Truck : ITransport
    {
        public string Name()
        {
            return this.GetType().Name;
        }

        public bool Send()
        {
            //logica trasporto camion
            return true;
        }
    }

    //Concrete Product
    public class Ship : ITransport
    {
        public string Name()
        {
            return this.GetType().Name;
        }

        public bool Send()
        {
            //logica trasporto camion
            return true;
        }
    }

    //Creator
    public abstract class Logistics
    {
        public abstract ITransport CreateTransport();

        public void ManageShip()
        {
            var transport = CreateTransport();

            Console.WriteLine($"Delivered with {transport.Name()}");

            transport.Send();
        }
    }

    //Concrete Creator
    public class AirLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Plane();
        }
    }

    //Concrete Creator
    public class RoadLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Truck();
        }
    }

    //Concrete Creator
    public class SeaLogistics : Logistics
    {
        public override ITransport CreateTransport()
        {
            return new Ship();
        }
    }

    public class LogisticsManager
    {
        public Logistics CreateLogistics(string logisticType)
        {
            Logistics logistics = null;

            if (logisticType.Equals("air", StringComparison.OrdinalIgnoreCase))
            {
                logistics = new AirLogistics();
            }
            else if (logisticType.Equals("road", StringComparison.OrdinalIgnoreCase))
            {
                logistics = new RoadLogistics();
            }
            else if (logisticType.Equals("sea", StringComparison.OrdinalIgnoreCase))
            {
                logistics = new SeaLogistics();
            }
            else
            {
                throw new Exception("Invalid logistic type");
            }

            return logistics;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(@"
 ____          __     __  _                                     _            ____                        
|  _ \    ___  \ \   / / | |       ___    __ _   _ __   _ __   (_)  _ __    / ___|                       
| | | |  / _ \  \ \ / /  | |      / _ \  / _` | | '__| | '_ \  | | | '_ \  | |  _                        
| |_| | |  __/   \ V /   | |___  |  __/ | (_| | | |    | | | | | | | | | | | |_| |                       
|____/   \___|    \_/    |_____|  \___|  \__,_| |_|    |_| |_| |_| |_| |_|  \____|                       
                                                                                                         
 _                       _         _     _                  ____                  _                      
| |       ___     __ _  (_)  ___  | |_  (_)   ___   ___    / ___|   _   _   ___  | |_    ___   _ __ ___  
| |      / _ \   / _` | | | / __| | __| | |  / __| / __|   \___ \  | | | | / __| | __|  / _ \ | '_ ` _ \ 
| |___  | (_) | | (_| | | | \__ \ | |_  | | | (__  \__ \    ___) | | |_| | \__ \ | |_  |  __/ | | | | | |
|_____|  \___/   \__, | |_| |___/  \__| |_|  \___| |___/   |____/   \__, | |___/  \__|  \___| |_| |_| |_|
                 |___/                                              |___/                                
                ");

            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Gray;

            LogisticsManager manager = new LogisticsManager();

            while (true)
            {
                Console.Write("Choose \"air\" | \"road\" | \"sea\" logistics type: ");

                var input = Console.ReadLine();
                if (input.Equals("close", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }

                try
                {
                    Logistics logistics = manager.CreateLogistics(input);
                    Console.Write(" - ");
                    logistics.ManageShip();
                }
                catch (Exception e)
                {
                    Console.WriteLine(" - " + e.Message);
                }
            }

            Console.Write("Goodbye...");
            Console.ReadKey();
        }
    }
}
