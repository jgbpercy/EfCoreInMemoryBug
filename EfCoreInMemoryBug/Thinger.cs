using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreInMemoryBug
{
    public class Thinger
    {
        public string Something { get; set; }

        public int Id { get; set; }

        [InverseProperty(nameof(DoDar.Thinger))]
        public List<DoDar> DoDars { get; } = new List<DoDar>();

        public Thinger(string something)
        {
            Something = something;
        }
    }
}
