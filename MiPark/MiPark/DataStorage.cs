using System.Collections.Generic;
using Newtonsoft.Json;
using Microsoft.Maui.Storage;
using System.IO;
using System.Threading.Tasks;
using System.Xml;

namespace MiPark
{
    public static class DataStorage
    {
        private static string GetFilePath() => Path.Combine(FileSystem.AppDataDirectory, "owners.json");

        public static async Task SaveOwnerDataAsync(Owner owner)
        {
            List<Owner> owners;
            var filePath = GetFilePath();

            if (File.Exists(filePath))
            {
                var existingData = await File.ReadAllTextAsync(filePath);
                owners = JsonConvert.DeserializeObject<List<Owner>>(existingData) ?? new List<Owner>();
            }
            else
            {
                owners = new List<Owner>();
            }

            var existingOwner = owners.Find(o => o.DNI == owner.DNI);
            if (existingOwner != null)
            {
                owners.Remove(existingOwner);
            }

            owners.Add(owner);

            var newData = JsonConvert.SerializeObject(owners, Newtonsoft.Json.Formatting.Indented);
            await File.WriteAllTextAsync(filePath, newData);
        }

        public static async Task<Owner?> LoadOwnerDataAsync(string dni)
        {
            var filePath = GetFilePath();
            if (File.Exists(filePath))
            {
                var data = await File.ReadAllTextAsync(filePath);
                var owners = JsonConvert.DeserializeObject<List<Owner>>(data);
                return owners?.Find(o => o.DNI == dni);
            }

            return null;
        }
    }
}
