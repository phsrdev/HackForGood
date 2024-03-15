using System.Text.RegularExpressions;

namespace MiPark
{
    public static class Methods
    {
        public static async Task<bool> LoginUserAsync(string username, string password)
        {
            // Aqui você implementaria a lógica para verificar as credenciais do usuário
            // Por enquanto, vamos simular um usuário e senha corretos para fins de demonstração
            bool isValidUser = username == "demo" && password == "demo123";

            // Simular uma operação assíncrona, como uma chamada de API
            await Task.Delay(1000); // Aguarda 1 segundo

            return isValidUser;
        }

        public static bool AuthenticateUser(string email, string password)
        {
            using (var dbContext = new DataBase())
            {
                // Retrieve the hashed password from the database
                var user = dbContext.Users.SingleOrDefault(e => e.Email == email);

                if (user != null)
                {
                    // Decrypt the hashed password using BCrypt
                    bool isPasswordMatch = BCrypt.Net.BCrypt.Verify(password, user.Password);

                    return isPasswordMatch;
                }
                else { return false; }
            }
        }

        public static bool AuthenticateDebug(string email, string password)
        {
            if (email == "adm@gmail.com" && password == "adm")
                return true;
            else
                return false;
        }

        public static string GetUserId(string email)
        {
            using (var dbContext = new DataBase())
            {
                // Retrieve the user based on the provided username
                var user = dbContext.Users.SingleOrDefault(u => u.Email == email);

                return user.Email;
            }
        }

        public static string GetUserName(string email)
        {
            using (var dbContext = new DataBase())
            {
                // Retrieve the user based on the provided username
                var user = dbContext.Users.SingleOrDefault(u => u.Email == email);

                return user.Username;
            }
        }


        public static bool PlateExists(string plate)
        {
            using (var dbContext = new DataBase())
            {
                // Check if plate already exists on DataBase
                return dbContext.Cars.Any(c => c.Plate == plate);
            }
        }

        public static bool IsUserAndCarRegistered(string userID, string plate)
        {
            using (var dbContext = new DataBase())
            {
                // Check if plate and car already registered on the DataBase
                return dbContext.UserCars.Any(uc => uc.UserID == userID && uc.Plate == plate);
            }
        }

        public static bool IsEmailExists(string email)
        {
            using (var dbContext = new DataBase())
            {
                // Check if any user with the provided email exists in the database
                return dbContext.Users.Any(u => u.Email == email);
            }
        }

        public static bool IsDNIUnqiue(string dni)
        {
            using (var dbContext = new DataBase())
            {
                // Check if any user with the provided email exists in the database
                return dbContext.Users.Any(u => u.DNI == dni);
            }
        }
    
    }
}