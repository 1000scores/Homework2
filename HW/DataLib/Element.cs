namespace DataLib
{
    public class Element
    {
        public string Name { get; set; }
        public int Year { get; set; }
        public string Month { get; set; }
        public int NumberOfCalls { get; set; }

        public Element(string name, int year, string month, int numberOfCalls)
        {
            Name = name;
            Year = year;
            Month = month;
            NumberOfCalls = numberOfCalls;
        }

    }
}
