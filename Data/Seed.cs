using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using DatingApp.API.Data;
using Models;
using Newtonsoft.Json;

namespace Data
{
    public class Seed
    {
        public static void SeedUsers(DataContext context)
        {
            if (!context.DbUsers.Any())
            {
                var userData = File.ReadAllText("Data/UserSeedData.json");
                var users = JsonConvert.DeserializeObject<List<DbUser>>(userData);
                foreach (var user in users)
                {
                    byte[] passHash, passSalt;
                    CreatePasswordHash("password", out passHash, out passSalt);

                    user.PasswordHash = passHash;
                    user.PasswordSalt = passSalt;
                    user.UserName = user.UserName.ToLower();

                    context.DbUsers.Add(user);
                }

                context.SaveChanges();
            }
        }
        private static void CreatePasswordHash(string password, out byte[] passHash, out byte[] passSalt)
        {
            using (var hmac = new HMACSHA512())
            {
                passSalt = hmac.Key;
                passHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

    }
}