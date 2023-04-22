using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransGr8_DD_Test.Services
{
    /// <summary>
    /// Get all users
    /// </summary>
    public class UserService
    {
        /// <summary>
        /// Load user from json file using Newtonsoft Json
        /// </summary>
        /// <returns>List of TransGr8-DD-Test\User</returns>
        public static List<User> GetAll()
        {
            if(!File.Exists("data\\users.json")) return new List<User>();
            List<User> users = new List<User>();
            using (StreamReader r = new StreamReader("data\\users.json"))
            {
                string json = r.ReadToEnd();
                users = JsonConvert.DeserializeObject<List<User>>(json);
            }
            return users;
        }
    }
}
