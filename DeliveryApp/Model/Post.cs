using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeliveryApp.Model
{
    public class Post
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }


        public static async Task<bool> Login(string email, string password)
        {
            bool result = false;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                result = false;
            else
            {
                var user = (await AzureHelper.MobileService.GetTable<Post>().Where(u => u.Email == email).ToListAsync()).FirstOrDefault();

                if (user == null) result = false;
                else if (user.Password == password) result = true;
                else result = false;
            }
            return result;
        }

        public static async Task<bool> Register(string email, string password, string confirmPassword)
        {
            bool result = false;

            if (!string.IsNullOrEmpty(password))
            {
                if (password == confirmPassword)
                {
                    var user = new Post()
                    {
                        Email = email,
                        Password = password
                    };

                    await AzureHelper.Insert<Post>(user);
                    result = true;
                }
            }


            return result;
        }


    }

}
