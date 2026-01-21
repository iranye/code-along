using CodeAlong.Domain.Data.Models;

namespace CodeAlong.Domain.Data
{
    public interface IDataProvider
    {
        Task<IEnumerable<Pattern>?> GetAllAsync();
    }

    public class DataProvider : IDataProvider
    {
        public async Task<IEnumerable<Pattern>?> GetAllAsync()
        {
            // Simulate asynchronous data fetching
            await Task.Delay(100);
            return new List<Pattern>
            {
                new Pattern { Id = 1, Title = "Pattern 1", Description = "Description 1" },
                new Pattern { Id = 2, Title = "Pattern 2", Description = "Description 2" },
            };
        }
    }
}
