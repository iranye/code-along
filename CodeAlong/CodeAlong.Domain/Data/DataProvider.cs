using CodeAlong.Domain.Data.Models;

namespace CodeAlong.Domain.Data
{
    public interface IDataProvider
    {
        Task<IEnumerable<Reference>?> GetAllAsync();
    }

    public class DataProvider : IDataProvider
    {
        public async Task<IEnumerable<Reference>?> GetAllAsync()
        {
            // Simulate asynchronous data fetching
            await Task.Delay(100);
            return new List<Reference>
            {
                new Reference { Id = 1, Title = "HF Design Patterns", Description = "Design Patterns Book" },
                new Reference { Id = 2, Title = "Just_Use_Postgres", Description = "Just_Use_Postgres Book" },
            };
        }
    }
}
