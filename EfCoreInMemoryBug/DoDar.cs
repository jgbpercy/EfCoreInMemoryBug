using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace EfCoreInMemoryBug
{
    public class DoDar
    {
        public int Id { get; set; }

        public int ThingerId { get; set; }

        private Thinger? _thinger;

        [ForeignKey(nameof(ThingerId))]
        public Thinger Thinger
        {
            set => _thinger = value;
            get => _thinger ?? throw new InvalidOperationException();
        }
    }
}
