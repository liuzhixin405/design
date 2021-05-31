namespace MarvellousWorks.PracticalPattern.Concept.Operator
{
    public class Season
    {
        public static readonly string[] Seasons =
            new string[] { "Spring", "Summer", "Autumn", "Winter" };
        private int current;
        public Season() { current = default(int); }
        public override string ToString() { return Seasons[current]; }

        public static Season operator ++(Season season)
        {
            season.current = (season.current + 1) % 4;
            return season;
        }
        public static implicit operator string(Season season) { return season.ToString(); }
    }
}
