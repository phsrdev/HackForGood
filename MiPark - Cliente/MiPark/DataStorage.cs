//using Android.Content;
using Microsoft.EntityFrameworkCore;
using System
/* Alteração não mesclada do projeto 'MiPark (net8.0-android)'
Antes:
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Após:
using System.IO;
using System.Linq;
using System.Text;
*/

/* Alteração não mesclada do projeto 'MiPark (net8.0-windows10.0.19041.0)'
Antes:
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Após:
using System.IO;
using System.Linq;
using System.Text;
*/

/* Alteração não mesclada do projeto 'MiPark (net8.0-ios)'
Antes:
using System.Linq;
using System.Text;
using System.Threading.Tasks;
Após:
using System.IO;
using System.Linq;
using System.Text;
*/
.Text.Json;
/* Alteração não mesclada do projeto 'MiPark (net8.0-android)'
Antes:
using System.IO;
Após:
using System.Threading.Tasks;
*/

/* Alteração não mesclada do projeto 'MiPark (net8.0-windows10.0.19041.0)'
Antes:
using System.IO;
Após:
using System.Threading.Tasks;
*/

/* Alteração não mesclada do projeto 'MiPark (net8.0-ios)'
Antes:
using System.IO;
Após:
using System.Threading.Tasks;
*/



namespace MiPark
{
    public static class DataStorage
    {
        private static string GetClientFilePath(string username)
        {
            return Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), $"{username}_client_data.json");
        }

        public static async Task SaveClientDataAsync(Client client)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string json = JsonSerializer.Serialize(client, options);

            string clientFilePath = GetClientFilePath(client.Username);

            await File.WriteAllTextAsync(clientFilePath, json);
        }

        public static async Task<Client> LoadClientDataAsync(string username)
        {
            string clientFilePath = GetClientFilePath(username);

            if (File.Exists(clientFilePath))
            {
                string json = await File.ReadAllTextAsync(clientFilePath);
                return JsonSerializer.Deserialize<Client>(json);
            }

            // Retorna null ou lança uma exceção se o cliente não for encontrado
            return null;
        }


        // Register the new User on the DataBase
        public static string PasswordManager(string email, string username, string surname, string hashedPassword, string phoneNumber, string dni)
        {
            using (var dbContext = new DataBase())
            {


                var user = new User
                {
                    Email = email,
                    Username = username,
                    Surname = surname,
                    Password = hashedPassword,
                    // Date
                    PhoneNumber = phoneNumber,
                    DNI = dni,
                };

                dbContext.Users.Add(user);
                dbContext.SaveChanges();
                
                return email;
            }
        }

        public static void RegisterCar (Car car)
        {
            using (var DbContext = new DataBase())
            {
                DbContext.Cars.Add(car);
                DbContext.SaveChanges();
            }
        }

        public static void RegisterUserCar(UserCar userCar)
        {
            using (var DbContext = new DataBase())
            {
                DbContext.UserCars.Add(userCar);
                DbContext.SaveChanges();
            }
        }

        public static User getUser(string email)
        {
            using (var DbContext = new DataBase())
            {
                var user = DbContext.Users.FirstOrDefault(u => u.Email == email);
                return user;
            }
        }
    }
}
