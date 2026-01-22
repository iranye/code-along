using CodeAlong.Domain.Data.Models;
using System.Security.Cryptography;
using System.Xml;

namespace CodeAlong.Domain.Data
{
    public interface IDataProvider
    {
        Task<IEnumerable<Reference>?> GetAllAsync();
        string JsonFileName { get; set; }
        string JsonFileFullPath { get; }
        void Delete(int id);
        void Save(Reference reference);
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

        public void Delete(int id)
        {
            var coffees = ReadFromFile();
            if (coffees is null)
            {
                return;
            }

            var existing = coffees.SingleOrDefault(f => f.Id == id);
            if (existing != null)
            {
                coffees.Remove(existing);
                SaveToFile(coffees);
            }
        }

        public void Save(Reference reference)
        {
            if (reference.Id <= 0)
            {
                InsertReference(reference);
            }
            else
            {
                UpdateReference(reference);
            }
        }

        private void UpdateReference(Reference reference)
        {
            var items = ReadFromFile();
            if (items is null)
            {
                return;
            }
            var existing = items.FirstOrDefault(f => f.Id == reference.Id);
            if (existing != null)
            {
                var indexOfExisting = items.IndexOf(existing);
                items.Insert(indexOfExisting, reference);
                items.Remove(existing);
                SaveToFile(items);
            }
        }

        private void InsertReference(Reference reference)
        {
            var references = ReadFromFile();
            if (references is null || String.IsNullOrWhiteSpace(reference.Title) || references.Any(m => m?.Title?.ToLower() == reference.Title?.ToLower()))
            {
                // TODO: Log message here
                return;
            }
            var maxReferenceId = references.Count == 0 ? 0 : references.Max(f => f.Id);
            reference.Id = maxReferenceId + 1;
            // var newReference = new Reference(maxReferenceId + 1, coffee.Title, coffee.Description);
            references.Add(reference);
            SaveToFile(references);
        }

        private void SaveToFile(IList<Reference> referencesList)
        {
            string json = System.Text.Json.JsonSerializer.Serialize(referencesList, new System.Text.Json.JsonSerializerOptions { WriteIndented = true });
            try
            {
                File.WriteAllText(JsonFileFullPath, json);
            }
            catch (Exception ex)
            {
                var message = ex.Message;
            }
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
