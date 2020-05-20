namespace EfCoreInMemoryBug
{
    public class ProjectedModel
    {
        public string Something { get; set; }

        public int NumberOfDoDars { get; set; }

        public ProjectedModel() { }

        public ProjectedModel(string something)
        {
            Something = something;
        }

        public ProjectedModel(int numberOfDoDars)
        {
            NumberOfDoDars = numberOfDoDars;
        }

        public ProjectedModel(
            string something,
            int numberOfDoDars)
        {
            Something = something;
            NumberOfDoDars = numberOfDoDars;
        }
    }
}
