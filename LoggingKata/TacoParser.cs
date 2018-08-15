namespace LoggingKata
{
    /// <summary>
    /// Parses a POI file to locate all the Taco Bells
    /// </summary>
    public class TacoParser
    {
        readonly ILog logger = new TacoLogger();
        
        public ITrackable Parse(string line)
        {
            

            // Take your line and use line.Split(',') to split it up into an array of strings, separated by the char ','
            var cells = line.Split(',');

            // If your array.Length is less than 3, something went wrong
            if (cells.Length < 3)
            {
                return null;
            }

            string Lat = cells[0];
            string Lon = cells[1];
            string City = cells[2];

            Point TacoLocation = new Point();
            TacoLocation.Latitude = double.Parse(Lat);
            TacoLocation.Longitude = double.Parse(Lon);

            TacoBell TacoBellStore1 = new TacoBell();
            TacoBellStore1.Name = City;
            TacoBellStore1.Location = TacoLocation;

            return TacoBellStore1;






            // Do not fail if one record parsing fails, return null
            // TODO Implement

            // grab the latitude from your array at index 0
            // grab the longitude from your array at index 1
            // grab the name from your array at index 2

            // Your going to need to parse your string as a `double`
            // which is similar to parsing a string as an `int`

            // You'll need to create a TacoBell class
            // that conforms to ITrackable

            // Then, you'll need an instance of the TacoBell class
            // With the name and point set correctly

            // Then, return the instance of your TacoBell class
            // Since it conforms to ITrackable
        }
    }
}