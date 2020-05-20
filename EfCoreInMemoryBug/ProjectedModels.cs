namespace EfCoreInMemoryBug
{
    public class ProjectedModels
    {
        public string Something { get; set; }

        public int NumberOfDoDars { get; set; }

        public ProjectedModels() { }

        public ProjectedModels(string something)
        {
            Something = something;
        }

        public ProjectedModels(int numberOfDoDars)
        {
            NumberOfDoDars = numberOfDoDars;
        }

        public ProjectedModels(
            string something,
            int numberOfDoDars)
        {
            Something = something;
            NumberOfDoDars = numberOfDoDars;
        }
    }
}
