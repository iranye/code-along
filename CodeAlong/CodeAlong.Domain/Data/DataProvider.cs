using CodeAlong.Domain.Data.Models;

namespace CodeAlong.Domain.Data
{
    public interface IDataProvider
    {
        Task<IEnumerable<Reference>?> GetAllAsync();
        string JsonFileName { get; set; }
        string JsonFileFullPath { get; }
    }

    public class DataProvider : IDataProvider
    {
        private string localStorageFilePath = @"..\..\Data";
        private string storageFileName = @"CodeAlongReferences.json";

        public string JsonFileName
        {
            get
            {
                return storageFileName;
            }
            set
            {
                if (value is not null)
                {
                    storageFileName = value;
                }
            }
        }

        public string JsonFileFullPath
        {
            get
            {
                var onedrivePath = Environment.GetEnvironmentVariable("ONEDRIVE");
                if (String.IsNullOrWhiteSpace(onedrivePath))
                {
                    var localPath = Path.Combine(localStorageFilePath, JsonFileName);
                    return Path.GetFullPath(localPath);
                }

                var cloudFilePath = onedrivePath + @"\Data\" + JsonFileName;

                return Path.GetFullPath(cloudFilePath);
            }
        }
        public async Task<IEnumerable<Reference>?> GetAllAsync()
        {
            // Simulate asynchronous data fetching
            await Task.Delay(100);
            return ReadFromFile();
        }

        private IList<Reference> ReadFromFile()
        {
            var defaultList = new List<Reference>
            {
                new Reference { Id = 1, Title = "HF Design Patterns", Description = "Design Patterns Book" },
                new Reference { Id = 2, Title = "Just_Use_Postgres", Description = "Just_Use_Postgres Book" },
            };
            var jsonFilePath = JsonFileFullPath;
            if (!File.Exists(jsonFilePath))
            {
                return defaultList;
            }
            var jsonString = File.ReadAllText(jsonFilePath);
            if (!String.IsNullOrWhiteSpace(jsonString))
            {
                System.Text.Json.JsonSerializer.Deserialize<IList<Reference>>(jsonString);
            }
            return defaultList;
        }
    }
}
