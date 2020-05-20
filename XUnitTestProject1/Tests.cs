using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace EfCoreInMemoryBug
{
    public class Tests
    {
        [Fact(DisplayName = "InMemory - parameterless ctor - works")]
        public async void InMemoryParamlessCtor()
        {
            var options = new DbContextOptionsBuilder<TheDbContext>().UseInMemoryDatabase("parameterless ctor").Options;

            var context = new TheDbContext(options);

            var projectModels = await context.Thingers
                .Select(t => new ProjectedModels { Something = t.Something, NumberOfDoDars = t.DoDars.Count })
                .ToArrayAsync();
        }

        [Fact(DisplayName = "InMemory - ctor params - errors")]
        public async Task InMemoryCtorParams()
        {
            var options = new DbContextOptionsBuilder<TheDbContext>().UseInMemoryDatabase("ctor params").Options;

            var context = new TheDbContext(options);

            var projectModels = await context.Thingers
                .Select(t => new ProjectedModels(t.Something, t.DoDars.Count))
                .ToArrayAsync();
        }

        [Fact(DisplayName =  "InMemory - string ctor param - errors")]
        public async Task InMemoroyOneCtorParam()
        {
            var options = new DbContextOptionsBuilder<TheDbContext>().UseInMemoryDatabase("string ctor param").Options;

            var context = new TheDbContext(options);

            var projectModels = await context.Thingers
                .Select(t => new ProjectedModels(t.Something) { NumberOfDoDars = t.DoDars.Count })
                .ToArrayAsync();
        }

        [Fact(DisplayName = "InMemory - count ctor param - errors")]
        public async Task InMemoroyStringCtorParam()
        {
            var options = new DbContextOptionsBuilder<TheDbContext>().UseInMemoryDatabase("count ctor param").Options;

            var context = new TheDbContext(options);

            var projectModels = await context.Thingers
                .Select(t => new ProjectedModels(t.DoDars.Count) { Something = t.Something })
                .ToArrayAsync();
        }

        [Fact(DisplayName = "Sqlite - ctor params - works")]
        public async Task SqlLiteCtorParams()
        {
            using var connection = new SqliteConnection("Filename=:memory:");

            connection.Open();

            var options = new DbContextOptionsBuilder<TheDbContext>().UseSqlite(connection).Options;

            var context = new TheDbContext(options);

            context.Database.EnsureCreated();

            var projectModels = await context.Thingers
                .Select(t => new ProjectedModels(t.Something, t.DoDars.Count))
                .ToArrayAsync();
        }
    }
}
