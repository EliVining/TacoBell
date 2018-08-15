using System;
using System.Linq;
using System.IO;
using GeoCoordinatePortable;

namespace LoggingKata
{
    class Program
    {
        static readonly ILog logger = new TacoLogger();
        const string csvPath = "TacoBell-US-AL.csv";

        static void Main(string[] args)
        {
            logger.LogInfo("Log initialized");
            var lines = File.ReadAllLines(csvPath);
            logger.LogInfo($"Lines: {lines}");
            var parser = new TacoParser();
            var locations = lines.Select(parser.Parse);
            double distance = 0;
            double maxDistance = 0;
            string TacoBellLocation1 = "";
            string TacoBellLocation2 = "";

            foreach (var line in locations)
            {
                GeoCoordinate corA = new GeoCoordinate();
                corA.Latitude = line.Location.Latitude;
                corA.Longitude = line.Location.Longitude;
                foreach (var line2 in locations)
                {
                    GeoCoordinate corB = new GeoCoordinate();
                    corB.Latitude = line2.Location.Latitude;
                    corB.Longitude = line2.Location.Longitude;
                    distance = corA.GetDistanceTo(corB);
                    if (maxDistance < distance)
                    {
                        TacoBellLocation1 = line.Name;
                        TacoBellLocation2 = line2.Name;
                        maxDistance = distance;

                    }
                   
                    
                    // TODO:  Find the two Taco Bells in Alabama that are the furthest from one another.
                    // HINT:  You'll need two nested forloops
                }
            }
            Console.WriteLine(TacoBellLocation1 + " " + TacoBellLocation2);
            Console.WriteLine(maxDistance);
            Console.ReadLine();

        }
    }
}